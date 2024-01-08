using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    partial class JanelaVisualizarMudancaAcervo
    {
        private DataGridView dgvSolicitacoes;
        private Usuario usuario;
        private VisualizarMudancaAcervoController controller;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvSolicitacoes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSolicitacoes
            // 
            this.dgvSolicitacoes.ColumnHeadersHeight = 34;
            this.dgvSolicitacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSolicitacoes.Location = new System.Drawing.Point(0, 0);
            this.dgvSolicitacoes.Name = "dgvSolicitacoes";
            this.dgvSolicitacoes.ReadOnly = true;
            this.dgvSolicitacoes.RowHeadersWidth = 62;
            this.dgvSolicitacoes.Size = new System.Drawing.Size(800, 450);
            this.dgvSolicitacoes.TabIndex = 0;
            // 
            // JanelaVisualizarMudancaAcervo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvSolicitacoes);
            this.Name = "JanelaVisualizarMudancaAcervo";
            this.Text = "Janela Visualizar Mudanca de Acervo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}