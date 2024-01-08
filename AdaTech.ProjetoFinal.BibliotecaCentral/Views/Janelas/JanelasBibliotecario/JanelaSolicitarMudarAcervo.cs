using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
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
            controller = new SolicitarMudarAcervoController(this);
            CarregarLivros();
        }

        private void BtnSolicitar_Click(object sender, EventArgs e)
        {
            controller.BtnSolicitarClick();
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
