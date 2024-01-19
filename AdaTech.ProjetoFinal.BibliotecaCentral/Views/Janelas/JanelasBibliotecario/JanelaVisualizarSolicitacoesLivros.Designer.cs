using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    partial class JanelaVisualizarSolicitacoesLivros
    {
        private DataGridView dgvSolicitacoes;
        private Usuario usuario;
        private VisualizarSolicitacoesLivrosController controller;
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
            this.Text = "JanelaVisualizarSolicitacoesLivros";

            dgvSolicitacoes = new DataGridView();
            dgvSolicitacoes.Dock = DockStyle.Fill;
            dgvSolicitacoes.ReadOnly = true;
            dgvSolicitacoes.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colunaLivro = new DataGridViewTextBoxColumn();
            colunaLivro.HeaderText = "Livro - Título";
            colunaLivro.DataPropertyName = "LivroTitulo";
            colunaLivro.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSolicitacoes.Columns.Add(colunaLivro);

            DataGridViewTextBoxColumn colunaLivroIsbn = new DataGridViewTextBoxColumn();
            colunaLivroIsbn.HeaderText = "Isbn";
            colunaLivroIsbn.DataPropertyName = "LivroIsbn";
            colunaLivroIsbn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSolicitacoes.Columns.Add(colunaLivroIsbn);

            DataGridViewTextBoxColumn colunaTipoAcervo = new DataGridViewTextBoxColumn();
            colunaTipoAcervo.HeaderText = "Tipo de Acervo";
            colunaTipoAcervo.DataPropertyName = "TipoAcervo";
            colunaTipoAcervo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSolicitacoes.Columns.Add(colunaTipoAcervo);

            DataGridViewTextBoxColumn colunaDescricao = new DataGridViewTextBoxColumn();
            colunaDescricao.HeaderText = "Descrição";
            colunaDescricao.DataPropertyName = "Descricao";
            colunaDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSolicitacoes.Columns.Add(colunaDescricao);

            DataGridViewTextBoxColumn colunaStatus = new DataGridViewTextBoxColumn();
            colunaStatus.HeaderText = "Aprovada";
            colunaStatus.DataPropertyName = "Aprovada";
            colunaStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSolicitacoes.Columns.Add(colunaStatus);

            Controls.Add(dgvSolicitacoes);
        }

        #endregion
    }
}