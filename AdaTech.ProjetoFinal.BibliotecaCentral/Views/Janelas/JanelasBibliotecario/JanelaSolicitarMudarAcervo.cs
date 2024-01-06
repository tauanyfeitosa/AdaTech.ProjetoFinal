using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController;
using System;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    internal partial class JanelaSolicitarMudarAcervo : Form
    {
        private ComboBox cmbLivro;
        private ComboBox cmbTipoAcervo;
        private TextBox txtDescricao;
        private Button btnSolicitar;
        private Label lblLivro;
        private Label lblTipoAcervo;
        private Label lblDescricao;
        private SolicitarMudarAcervoController controller;
        private Usuario usuario;

        public JanelaSolicitarMudarAcervo(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeButtons();
            controller = new SolicitarMudarAcervoController(this);
        }
        internal Usuario Usuario
        {
            get { return usuario; }
        }

        internal ComboBox CmbLivro
        {
            get { return cmbLivro; }
        }

        internal ComboBox CmbTipoAcervo
        {
            get { return cmbTipoAcervo; }
        }

        internal TextBox TxtDescricao
        {
            get { return txtDescricao; }
        }

        private void InitializeButtons()
        {
            lblLivro = new Label();
            lblLivro.Text = "Livro:";
            lblLivro.Location = new System.Drawing.Point(20, 20);

            cmbLivro = new ComboBox();
            cmbLivro.DisplayMember = "Titulo";
            cmbLivro.ValueMember = "Isbn";
            cmbLivro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLivro.Location = new System.Drawing.Point(120, 20);
            cmbLivro.Width = 200;
            cmbLivro.SelectedIndexChanged += CmbLivro_SelectedIndexChanged;

            lblTipoAcervo = new Label();
            lblTipoAcervo.Text = "Tipo de Acervo:";
            lblTipoAcervo.Location = new System.Drawing.Point(20, 60);

            cmbTipoAcervo = new ComboBox();
            cmbTipoAcervo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoAcervo.Location = new System.Drawing.Point(120, 60);
            cmbTipoAcervo.Width = 200;

            lblDescricao = new Label();
            lblDescricao.Text = "Descrição:";
            lblDescricao.Location = new System.Drawing.Point(20, 100);

            txtDescricao = new TextBox();
            txtDescricao.Multiline = true;
            txtDescricao.Location = new System.Drawing.Point(120, 100);
            txtDescricao.Width = 200;
            txtDescricao.Height = 80;

            btnSolicitar = new Button();
            btnSolicitar.Text = "Solicitar Mudança de Acervo";
            btnSolicitar.Location = new System.Drawing.Point(20, 200);
            btnSolicitar.Click += BtnSolicitar_Click;

            Controls.Add(lblLivro);
            Controls.Add(cmbLivro);
            Controls.Add(lblTipoAcervo);
            Controls.Add(cmbTipoAcervo);
            Controls.Add(lblDescricao);
            Controls.Add(txtDescricao);
            Controls.Add(btnSolicitar);
        }

        private void CmbLivro_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.AtualizarComboBoxTipoAcervo();
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
    }
}
