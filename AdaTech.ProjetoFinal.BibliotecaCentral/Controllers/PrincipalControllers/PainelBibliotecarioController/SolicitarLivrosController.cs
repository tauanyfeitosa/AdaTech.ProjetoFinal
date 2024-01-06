using System;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController
{
    internal class SolicitarLivrosController
    {
        private JanelaSolicitarLivros view;
        private Usuario usuarioLogado;

        public SolicitarLivrosController(JanelaSolicitarLivros view, Usuario usuario)
        {
            this.view = view;
            this.usuarioLogado = usuario;
        }

        internal void BtnSolicitarClick()
        {
            Livro livroSelecionado = (Livro)view.CmbLivro.SelectedItem;
            TipoAcervoLivro tipoAcervoSelecionado = (TipoAcervoLivro)view.CmbTipoAcervo.SelectedItem;
            string descricao = view.TxtDescricao.Text;

            if (usuarioLogado is Bibliotecario bibliotecario)
            {
                SolicitacoesData.CriarSolicitacao(TipoSolicitacao.RequisicaoLivro, livroSelecionado, tipoAcervoSelecionado, descricao, bibliotecario);
                MessageBox.Show("Solicitação criada com sucesso!");
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Você não tem permissão para criar solicitações.");
            }
        }

        private void LimparFormulario()
        {
            view.CmbLivro.SelectedIndex = -1;
            view.CmbTipoAcervo.SelectedIndex = 0; 
            view.TxtDescricao.Text = string.Empty;
        }
    }

}
