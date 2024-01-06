using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor
{
    internal partial class JanelaVisualizarSolicitacoes : Form
    {
        private DataGridView dgvMudancaAcervo;
        private DataGridView dgvRequisicaoLivros;
        private Usuario usuario;

        public JanelaVisualizarSolicitacoes(Usuario usuario, TipoSolicitacao tipoSolicitacao)
        {
            this.usuario = usuario;
            if (usuario is Diretor diretor)
                InitializeDataGridViews(tipoSolicitacao);
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeDataGridViews(TipoSolicitacao solicitacao)
        {
            Controls.Clear();
            if (solicitacao == TipoSolicitacao.MudarAcervoLivro)
            {
                dgvMudancaAcervo = new DataGridView();
                dgvMudancaAcervo.Dock = DockStyle.Top;
                dgvMudancaAcervo.Height = this.ClientSize.Height / 2;
                dgvMudancaAcervo.AutoGenerateColumns = true;
                dgvMudancaAcervo.ReadOnly = true;
                dgvMudancaAcervo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvMudancaAcervo.DataSource = SolicitacoesData.SelecionarMudancaAcervo();

                dgvMudancaAcervo.CellDoubleClick += (sender, e) => MostrarDetalhes((ISolicitacao)dgvMudancaAcervo.SelectedRows[0].DataBoundItem);

                Controls.Add(dgvMudancaAcervo);
            }
            else
            {
                dgvRequisicaoLivros = new DataGridView();
                dgvRequisicaoLivros.Dock = DockStyle.Top;
                dgvRequisicaoLivros.Height = this.ClientSize.Height / 2;
                dgvRequisicaoLivros.AutoGenerateColumns = true;
                dgvRequisicaoLivros.ReadOnly = true;
                dgvRequisicaoLivros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvRequisicaoLivros.DataSource = SolicitacoesData.SelecionarRequisicaoLivros();

                dgvRequisicaoLivros.CellDoubleClick += (sender, e) => MostrarDetalhes((ISolicitacao)dgvRequisicaoLivros.SelectedRows[0].DataBoundItem);

                Controls.Add(dgvRequisicaoLivros);
            }

        }

        private void MostrarDetalhes(ISolicitacao solicitacao)
        {
            JanelaDetalhesSolicitacao detalhes = new JanelaDetalhesSolicitacao(solicitacao);
            detalhes.ShowDialog();
        }
    }
}
