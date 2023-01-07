using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain
{
    public partial class domainScript : Form
    {
        readonly Connector Connector = new Connector("Domain.listaLocalidades.csv");
        public domainScript()
        {
            InitializeComponent();
            System.Windows.Forms.Form wait = new Form();
            wait.Text = "Espere";
        }

        private void PopulateTreeView(TreeView treeView, IEnumerable<UnidadeOrganizacional> paths, char pathSeparator)
        {
            TreeNode lastNode = null;
            string subPathAgg;
            foreach (string path in paths.Select(ou => ou.fullContainer))
            {
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            lastNode = treeView.Nodes.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
            }
            treeView.Sort();
        }


        private void domainScript_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker) delegate {
                PopulateTreeView(arvoreOU, Connector.retornaLista(), '\\'); });
            
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                btAdicionar.Enabled = false;
                consoleLog.Text = "Adicionando equipamento ao domínio, por favor aguarde";
                var retorno = Connector.AdicionaDominio(Connector.retornaLista().Find(o => o.fullContainer.Equals(arvoreOU.SelectedNode.FullPath)).distinguishedName);
                consoleLog.Text = retorno;
            }
            catch (NullReferenceException)
            {
                consoleLog.Text = "O equipamento deve ser inserido em uma OU dentro de Computers.";
            }
            finally
            {
                btAdicionar.Enabled = true;
            }
        }
    }
}
