
namespace Domain
{
    partial class domainScript
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(domainScript));
            this.arvoreOU = new System.Windows.Forms.TreeView();
            this.consoleLog = new System.Windows.Forms.TextBox();
            this.lbLocalidade = new System.Windows.Forms.Label();
            this.lbLog = new System.Windows.Forms.Label();
            this.btAdicionar = new System.Windows.Forms.Button();
            this.lbDataUpd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // arvoreOU
            // 
            this.arvoreOU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.arvoreOU.Location = new System.Drawing.Point(13, 26);
            this.arvoreOU.Name = "arvoreOU";
            this.arvoreOU.Size = new System.Drawing.Size(359, 300);
            this.arvoreOU.TabIndex = 0;
            // 
            // consoleLog
            // 
            this.consoleLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleLog.Enabled = false;
            this.consoleLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleLog.Location = new System.Drawing.Point(12, 384);
            this.consoleLog.Multiline = true;
            this.consoleLog.Name = "consoleLog";
            this.consoleLog.Size = new System.Drawing.Size(360, 71);
            this.consoleLog.TabIndex = 2;
            // 
            // lbLocalidade
            // 
            this.lbLocalidade.AutoSize = true;
            this.lbLocalidade.Location = new System.Drawing.Point(12, 10);
            this.lbLocalidade.Name = "lbLocalidade";
            this.lbLocalidade.Size = new System.Drawing.Size(96, 13);
            this.lbLocalidade.TabIndex = 3;
            this.lbLocalidade.Text = "Informar localidade";
            this.lbLocalidade.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbLog
            // 
            this.lbLog.AutoSize = true;
            this.lbLog.Location = new System.Drawing.Point(12, 362);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(25, 13);
            this.lbLog.TabIndex = 4;
            this.lbLog.Text = "Log";
            this.lbLog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btAdicionar
            // 
            this.btAdicionar.Location = new System.Drawing.Point(125, 332);
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.Size = new System.Drawing.Size(150, 40);
            this.btAdicionar.TabIndex = 5;
            this.btAdicionar.Text = "Ingressar no domínio";
            this.btAdicionar.UseVisualStyleBackColor = true;
            this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
            // 
            // lbDataUpd
            // 
            this.lbDataUpd.AutoSize = true;
            this.lbDataUpd.Location = new System.Drawing.Point(10, 462);
            this.lbDataUpd.Name = "lbDataUpd";
            this.lbDataUpd.Size = new System.Drawing.Size(166, 13);
            this.lbDataUpd.TabIndex = 6;
            this.lbDataUpd.Text = "Data de atualização: 03/09/2021";
            // 
            // domainScript
            // 
            this.AcceptButton = this.btAdicionar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(384, 481);
            this.Controls.Add(this.lbDataUpd);
            this.Controls.Add(this.btAdicionar);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.lbLocalidade);
            this.Controls.Add(this.consoleLog);
            this.Controls.Add(this.arvoreOU);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(404, 524);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(404, 524);
            this.Name = "domainScript";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "domainScript";
            this.Load += new System.EventHandler(this.domainScript_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView arvoreOU;
        private System.Windows.Forms.TextBox consoleLog;
        private System.Windows.Forms.Label lbLocalidade;
        private System.Windows.Forms.Label lbLog;
        private System.Windows.Forms.Button btAdicionar;
        private System.Windows.Forms.Label lbDataUpd;
    }
}

