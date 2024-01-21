using System;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController
{
    internal class SolicitarMudarAcervoController
    {
        private JanelaSolicitarMudarAcervo view;

        public SolicitarMudarAcervoController(JanelaSolicitarMudarAcervo view)
        {
            this.view = view;
        }

        internal void AtualizarComboBoxTipoAcervo()
        {
            if (view.CmbLivro != null && view.CmbTipoAcervo != null)
            {
                view.CmbTipoAcervo.Items.Clear();

                foreach (TipoAcervoLivro tipo in Enum.GetValues(typeof(TipoAcervoLivro)))
                {
                    view.CmbTipoAcervo.Items.Add(tipo);
                }

                if (view.CmbLivro.SelectedItem != null)
                {
                    Livro livroSelecionado = (Livro)view.CmbLivro.SelectedItem;
                    TipoAcervoLivro tipoAcervoLivro = livroSelecionado.TipoAcervoLivro;

                    view.CmbTipoAcervo.Items.Remove(tipoAcervoLivro);

                    if (view.CmbTipoAcervo.Items.Count > 0)
                    {
                        view.CmbTipoAcervo.SelectedIndex = 0;
                    }
                }
            }
        }

    }
}
