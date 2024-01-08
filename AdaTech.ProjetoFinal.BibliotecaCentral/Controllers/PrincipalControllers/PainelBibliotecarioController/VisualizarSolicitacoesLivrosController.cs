using System.Collections.Generic;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController
{
    internal class VisualizarSolicitacoesLivrosController
    {
        private JanelaVisualizarSolicitacoesLivros view;
        private Usuario usuario;

        public VisualizarSolicitacoesLivrosController(JanelaVisualizarSolicitacoesLivros view, Usuario usuario)
        {
            this.view = view;
            this.usuario = usuario;
        }


        internal void CarregarSolicitacoes()
        {
            if (usuario is Bibliotecario bibliotecario)
            {
                List<SolicitacaoRequisicaoLivros> solicitacoes = SolicitacoesData.SelecionarRequisicoes(bibliotecario);
                view.DgvSolicitacoes.DataSource = solicitacoes;
            }
            else
            {
                MessageBox.Show("Você não tem as permissões necessárias.");
            }
        }
    }
}
