using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    internal partial class JanelaVisualizarSolicitacoesLivros : Form
    {
        private DataGridView dgvSolicitacoes;
        private Usuario usuario;
        private VisualizarSolicitacoesLivrosController controller;

        public JanelaVisualizarSolicitacoesLivros(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
            InitializeDataGridView();
            controller = new VisualizarSolicitacoesLivrosController(this, usuario);
            CarregarSolicitacoes();
        }

        internal DataGridView DgvSolicitacoes
        {
            get { return dgvSolicitacoes; }
        }

        private void InitializeDataGridView()
        {
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


        private void CarregarSolicitacoes()
        {
            controller.CarregarSolicitacoes();
        }

        private void CarregarTipoAcervo()
        {

        }
    }
}
