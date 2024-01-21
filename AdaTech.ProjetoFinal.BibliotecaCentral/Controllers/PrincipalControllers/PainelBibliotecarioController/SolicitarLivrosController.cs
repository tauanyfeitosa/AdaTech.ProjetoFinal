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

        internal void LimparFormulario()
        {
            view.CmbLivro.SelectedIndex = -1;
            view.CmbTipoAcervo.SelectedIndex = 0; 
            view.TxtDescricao.Text = string.Empty;
        }
    }

}
