using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor
{
    internal partial class JanelaVisualizarSolicitacoes : Form
    {
        public JanelaVisualizarSolicitacoes(Usuario usuario, TipoSolicitacao tipoSolicitacao)
        {
            this.usuario = usuario;
            InitializeComponent();
            if (usuario is Diretor diretor)
            {
                if (tipoSolicitacao is TipoSolicitacao.MudarAcervoLivro)
                {
                    dgvSolicitacoes.DataSource = SolicitacoesData.SelecionarMudancaAcervo();
                }
                else
                {
                    dgvSolicitacoes.DataSource = SolicitacoesData.SelecionarRequisicaoLivros();
                }

                dgvSolicitacoes.Height = this.ClientSize.Height / 2;
                dgvSolicitacoes.CellDoubleClick += (sender, e) => MostrarDetalhes((ISolicitacao)dgvSolicitacoes.SelectedRows[0].DataBoundItem);
            }
            
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeDataGridViews(TipoSolicitacao solicitacao)
        {
            

        }

        private void MostrarDetalhes(ISolicitacao solicitacao)
        {
            JanelaDetalhesSolicitacao detalhes = new JanelaDetalhesSolicitacao(solicitacao);
            detalhes.ShowDialog();
        }
    }
}
