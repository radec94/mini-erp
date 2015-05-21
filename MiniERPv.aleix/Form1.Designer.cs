namespace MiniERP
{
    partial class frmERP
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.arxiuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articlesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.proveïdorsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.incorporarComandaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recepcionarAlbaràToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveïdorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articlesPendentsPerProveïdorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valoracióStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.llistatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articlesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.articlesPendentsDeRebreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estocValoratToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveïdorsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arxiuToolStripMenuItem,
            this.llistatsToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(451, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // arxiuToolStripMenuItem
            // 
            this.arxiuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarToolStripMenuItem,
            this.exportarToolStripMenuItem});
            this.arxiuToolStripMenuItem.Name = "arxiuToolStripMenuItem";
            this.arxiuToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.arxiuToolStripMenuItem.Text = "Arxiu";
            // 
            // importarToolStripMenuItem
            // 
            this.importarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articlesToolStripMenuItem1,
            this.proveïdorsToolStripMenuItem1,
            this.incorporarComandaToolStripMenuItem,
            this.recepcionarAlbaràToolStripMenuItem});
            this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
            this.importarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importarToolStripMenuItem.Text = "Importar";
            // 
            // articlesToolStripMenuItem1
            // 
            this.articlesToolStripMenuItem1.Name = "articlesToolStripMenuItem1";
            this.articlesToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.articlesToolStripMenuItem1.Text = "Articles";
            this.articlesToolStripMenuItem1.Click += new System.EventHandler(this.articlesToolStripMenuItem1_Click);
            // 
            // proveïdorsToolStripMenuItem1
            // 
            this.proveïdorsToolStripMenuItem1.Name = "proveïdorsToolStripMenuItem1";
            this.proveïdorsToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.proveïdorsToolStripMenuItem1.Text = "Proveïdors";
            // 
            // incorporarComandaToolStripMenuItem
            // 
            this.incorporarComandaToolStripMenuItem.Name = "incorporarComandaToolStripMenuItem";
            this.incorporarComandaToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.incorporarComandaToolStripMenuItem.Text = "Incorporar Comanda";
            // 
            // recepcionarAlbaràToolStripMenuItem
            // 
            this.recepcionarAlbaràToolStripMenuItem.Name = "recepcionarAlbaràToolStripMenuItem";
            this.recepcionarAlbaràToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.recepcionarAlbaràToolStripMenuItem.Text = "Recepcionar Albarà";
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proveïdorsToolStripMenuItem,
            this.articlesToolStripMenuItem,
            this.articlesPendentsPerProveïdorToolStripMenuItem,
            this.valoracióStockToolStripMenuItem});
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportarToolStripMenuItem.Text = "Exportar";
            this.exportarToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
            // 
            // proveïdorsToolStripMenuItem
            // 
            this.proveïdorsToolStripMenuItem.Name = "proveïdorsToolStripMenuItem";
            this.proveïdorsToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.proveïdorsToolStripMenuItem.Text = "Proveïdors";
            // 
            // articlesToolStripMenuItem
            // 
            this.articlesToolStripMenuItem.Name = "articlesToolStripMenuItem";
            this.articlesToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.articlesToolStripMenuItem.Text = "Articles";
            // 
            // articlesPendentsPerProveïdorToolStripMenuItem
            // 
            this.articlesPendentsPerProveïdorToolStripMenuItem.Name = "articlesPendentsPerProveïdorToolStripMenuItem";
            this.articlesPendentsPerProveïdorToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.articlesPendentsPerProveïdorToolStripMenuItem.Text = "Articles Pendents Per Proveïdor";
            // 
            // valoracióStockToolStripMenuItem
            // 
            this.valoracióStockToolStripMenuItem.Name = "valoracióStockToolStripMenuItem";
            this.valoracióStockToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.valoracióStockToolStripMenuItem.Text = "Valoració Stock";
            this.valoracióStockToolStripMenuItem.Click += new System.EventHandler(this.valoracióStockToolStripMenuItem_Click);
            // 
            // llistatsToolStripMenuItem
            // 
            this.llistatsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articlesToolStripMenuItem2,
            this.articlesPendentsDeRebreToolStripMenuItem,
            this.estocValoratToolStripMenuItem,
            this.proveïdorsToolStripMenuItem2});
            this.llistatsToolStripMenuItem.Name = "llistatsToolStripMenuItem";
            this.llistatsToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.llistatsToolStripMenuItem.Text = "Llistats";
            // 
            // articlesToolStripMenuItem2
            // 
            this.articlesToolStripMenuItem2.Name = "articlesToolStripMenuItem2";
            this.articlesToolStripMenuItem2.Size = new System.Drawing.Size(215, 22);
            this.articlesToolStripMenuItem2.Text = "Articles";
            // 
            // articlesPendentsDeRebreToolStripMenuItem
            // 
            this.articlesPendentsDeRebreToolStripMenuItem.Name = "articlesPendentsDeRebreToolStripMenuItem";
            this.articlesPendentsDeRebreToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.articlesPendentsDeRebreToolStripMenuItem.Text = "Articles Pendents De Rebre";
            // 
            // estocValoratToolStripMenuItem
            // 
            this.estocValoratToolStripMenuItem.Name = "estocValoratToolStripMenuItem";
            this.estocValoratToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.estocValoratToolStripMenuItem.Text = "Estoc Valorat";
            // 
            // proveïdorsToolStripMenuItem2
            // 
            this.proveïdorsToolStripMenuItem2.Name = "proveïdorsToolStripMenuItem2";
            this.proveïdorsToolStripMenuItem2.Size = new System.Drawing.Size(215, 22);
            this.proveïdorsToolStripMenuItem2.Text = "Proveïdors";
            // 
            // frmERP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 173);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmERP";
            this.Text = "MINI ERP - BY DAM";
            this.Load += new System.EventHandler(this.frmERP_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem arxiuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articlesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem proveïdorsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem incorporarComandaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveïdorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recepcionarAlbaràToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem llistatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articlesPendentsDeRebreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estocValoratToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveïdorsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem articlesPendentsPerProveïdorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valoracióStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articlesToolStripMenuItem2;
    }
}

