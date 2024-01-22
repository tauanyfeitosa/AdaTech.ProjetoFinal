using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;
using System;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    internal partial class JanelaSolicitarMudarAcervo : Form
    {
        public JanelaSolicitarMudarAcervo(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
            btnSolicitar.Click += BtnSolicitar_Click;
            cmbLivro.SelectedIndexChanged += CmbLivro_SelectedIndexChanged;
            controller = new SolicitarMudarAcervoController(this);
            CarregarLivros();
        }

        private void BtnSolicitar_Click(object sender, EventArgs e)
        {
            try
            {
                Livro livroSelecionado = (Livro)CmbLivro.SelectedItem;
                TipoAcervoLivro tipoAcervoSelecionado = (TipoAcervoLivro)CmbTipoAcervo.SelectedItem;
                string descricao = TxtDescricao.Text;

                if (Usuario is Bibliotecario bibliotecario)
                {
                    if (SolicitacoesData.CriarSolicitacao(TipoSolicitacao.MudarAcervoLivro, livroSelecionado, tipoAcervoSelecionado, descricao, bibliotecario))
                    {
                        MessageBox.Show("Solicitação de mudança de acervo criada com sucesso!");
                        LimparFormulario();
                    } 
                }
                else
                {
                    MessageBox.Show("Você não tem permissão para criar solicitações.");
                }
            } catch
            {
                MessageBox.Show("Erro ao criar solicitação.");
            }
            
        }

        internal void LimparFormulario()
        {
            cmbLivro.SelectedIndex = -1;
            cmbTipoAcervo.Items.Clear();
            txtDescricao.Text = string.Empty;
        }

        private void CarregarLivros()
        {
            cmbLivro.DataSource = LivroData.ObterLivros();
        }

        private void CmbLivro_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.AtualizarComboBoxTipoAcervo();
        }
    }

}
