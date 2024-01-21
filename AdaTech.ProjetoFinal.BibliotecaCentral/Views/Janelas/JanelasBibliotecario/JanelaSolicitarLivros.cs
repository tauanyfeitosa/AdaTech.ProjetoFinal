using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;


namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    internal partial class JanelaSolicitarLivros : Form
    {

        public JanelaSolicitarLivros(Usuario usuario)
        {
            InitializeComponent();
            this.usuarioLogado = usuario;
            cmbTipoAcervo.DataSource = Enum.GetValues(typeof(TipoAcervoLivro))
                .Cast<TipoAcervoLivro>()
                .Where(value => value != TipoAcervoLivro.EmManutencao && value != TipoAcervoLivro.Indisponivel && value != TipoAcervoLivro.Inativo)
                .ToList();

            cmbLivro.DataSource = LivroData.ObterLivros();
            controller = new SolicitarLivrosController(this, usuario);
            btnSolicitar.Click += BtnSolicitar_Click;
        }

        private void BtnSolicitar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(usuarioLogado.GetType().ToString());
            Livro livroSelecionado = (Livro)CmbLivro.SelectedItem;
            TipoAcervoLivro tipoAcervoSelecionado = (TipoAcervoLivro)CmbTipoAcervo.SelectedItem;
            string descricao = TxtDescricao.Text;

            if (usuarioLogado is Bibliotecario bibliotecario)
            {
                if (SolicitacoesData.CriarSolicitacao(TipoSolicitacao.RequisicaoLivro, livroSelecionado, tipoAcervoSelecionado, descricao, bibliotecario))
                {
                    MessageBox.Show("Solicitação criada com sucesso!");
                    controller.LimparFormulario();
                } 
            }
            else
            {
                MessageBox.Show("Você não tem permissão para criar solicitações.");
            }
        }
    }
}
