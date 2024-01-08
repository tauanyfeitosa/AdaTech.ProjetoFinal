using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor
{
    partial class JanelaVisualizarSolicitacoes
    {
        private DataGridView dgvSolicitacoes;
        private Usuario usuario;
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "JanelaVisualizarSolicitacoes";

            dgvSolicitacoes = new DataGridView();
            dgvSolicitacoes.Dock = DockStyle.Top;
            dgvSolicitacoes.AutoGenerateColumns = true;
            dgvSolicitacoes.ReadOnly = true;
            dgvSolicitacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Controls.Add(dgvSolicitacoes);
        }

        #endregion
    }
}