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

        internal void BtnSolicitarClick()
        {
            Livro livroSelecionado = (Livro)view.CmbLivro.SelectedItem;
            TipoAcervoLivro tipoAcervoSelecionado = (TipoAcervoLivro)view.CmbTipoAcervo.SelectedItem;
            string descricao = view.TxtDescricao.Text;

            if (view.Usuario is Bibliotecario bibliotecario)
            {
                SolicitacoesData.CriarSolicitacao(TipoSolicitacao.MudarAcervoLivro, livroSelecionado, tipoAcervoSelecionado, descricao, bibliotecario);
                MessageBox.Show("Solicitação de mudança de acervo criada com sucesso!");
                view.LimparFormulario();
            }
            else
            {
                MessageBox.Show("Você não tem permissão para criar solicitações.");
            }

            MessageBox.Show("Solicitação de mudança de acervo criada com sucesso!");
            view.LimparFormulario();
        }

        internal void AtualizarComboBoxTipoAcervo()
        {
            view.CmbTipoAcervo.Items.Clear();

            foreach (TipoAcervoLivro tipo in Enum.GetValues(typeof(TipoAcervoLivro)))
            {
                view.CmbTipoAcervo.Items.Add(tipo);
            }

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
