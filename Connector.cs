using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Domain
{
    internal class Connector
    {
        List<UnidadeOrganizacional> unidades = new List<UnidadeOrganizacional>();
        private const string domain = @"";
        private const string login = @"";
        private const string senha = @"";

        private ManagementObject managementObject = new ManagementObject("Win32_ComputerSystem.Name=\"" + Environment.MachineName + "\"");
        private Assembly assembly = Assembly.GetExecutingAssembly();

        public string AdicionaDominio(string ou = @"")
        {
            if (!ou.Contains("OU=Computers")) { return "O equipamento deve ser inserido em uma OU dentro de Computers."; }

            int retorno = 2700;// addDomain(domain, senha, login, ou, "2");

            switch (retorno)
            {
                case 0:
                    addDomain(domain, senha, login, ou, "2");
                    addDomain(domain, senha, login, ou, "1");

                    return $"Sucesso. Conta do equipamento {Environment.MachineName} criada no domínio e ingressado na OU " + unidades.Find(o => o.distinguishedName == ou).nome;
                case 5:
                    return "5 - Acesso Negado, execute como administrador.";
                case 87:
                    return "87 - Parâmetro incorreto. Entre em contato com o responsável";
                case 1326:
                    return "1326 - Erro de login / senha. Entre em contato com o responsável";
                case 2224:
                    return (addDomain(domain, senha, login, ou, "2") == 0 && addDomain(domain, senha, login, ou, "1") == 0) ? $"Sucesso. Conta do equipamento {Environment.MachineName} criada no domínio e ingressado na OU " + unidades.Find(o => o.distinguishedName == ou).nome : "2224 - Equipamento duplicado no domínio. Verifique os dados do equipamento.";
                case 2691:
                    return "2691 - Equipamento já adicionado ao domínio.";
                case 2700:
                    return (addDomain(domain, senha, login, ou, "2") == 0 && addDomain(domain, senha, login, ou, "1") == 0) ? $"Sucesso. Conta do equipamento {Environment.MachineName} criada no domínio e ingressado na OU " + unidades.Find(o => o.distinguishedName == ou).nome : @"2700 - Equipamento em domínio Azure, não foi possível remover automaticamente. Utilize o comando dsregcmd /leave";
                default:
                    return "Erro desconhecido. Entre em contato com o responsável\nCódigo de erro: " + retorno.ToString() + " - FJoinOptions: 3";
            }

        }
        private int addDomain(string domain, string senha, string login, string ou, string options)
        {
            string[] parameters = { domain, senha, login, ou, options };
            int retorno = Convert.ToInt32(managementObject.InvokeMethod("JoinDomainOrWorkgroup", parameters));
            switch (retorno)
            {
                case 0:
                    return 0;
                case 2700:
                    removeDomain();
                    return retorno;
                case 5:
                case 87:
                case 1326:
                case 2224:
                case 2691:
                    return retorno;
                default:
                    return -2;
            }
        }

        private void removeDomain()
        {
            const string REMDOM = "/c dsregcmd /debug /leave";
            System.Diagnostics.Process.Start("CMD.exe", REMDOM);
        }

        public Connector(string arquivo)
        {
            GerarArvore(arquivo);
            ConfiguraDominio();
        }

        private void ConfiguraDominio()
        {
            managementObject.Scope.Options.Authentication = AuthenticationLevel.PacketPrivacy;
            managementObject.Scope.Options.Impersonation = ImpersonationLevel.Impersonate;
            managementObject.Scope.Options.EnablePrivileges = true;
        }

        private void GerarArvore(string arquivo)
        {
            using (Stream stream = assembly.GetManifestResourceStream(arquivo))
            using (var reader = new StreamReader(stream))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Trim('\"');
                    var values = Regex.Split(line, "\",\"");

                    if (!line.Contains(@"OU=Groups") && !line.Contains(@"OU=Users"))
                    {
                        unidades.Add(new UnidadeOrganizacional(values[0], values[1], values[2]));
                    }

                }
            }
        }

        public List<UnidadeOrganizacional> retornaLista()
        {
            return unidades;
        }

    }

    internal class UnidadeOrganizacional
    {
        public string nome { get; set; }
        public string distinguishedName { get; set; }
        public string parentContainer { get; set; }
        public string fullContainer { get; set; }

        public UnidadeOrganizacional(string nome, string distinguishedName, string parentContainer)
        {
            this.nome = nome;
            this.distinguishedName = distinguishedName;
            this.parentContainer = parentContainer;
            CriaContainerFull(parentContainer, nome);
        }

        private void CriaContainerFull(string parentContainer, string nome)
        {
            this.fullContainer = parentContainer + '\\' + nome;
        }

    }
}