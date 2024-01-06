using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    internal partial class JanelaSolicitarLivros : Form
    {
        private Label lblLivro;
        private ComboBox cmbLivro; 
        private Label lblTipoAcervo;
        private ComboBox cmbTipoAcervo;  
        private Label lblDescricao;
        private TextBox txtDescricao;
        private Button btnSolicitar;
        private Usuario usuarioLogado;
        private SolicitarLivrosController controller;

        internal Button BtnSolicitar
        {
            get { return btnSolicitar; }
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

        public JanelaSolicitarLivros(Usuario usuario)
        {
            InitializeComponent();
            controller = new SolicitarLivrosController(this, usuario);
            InitializeFormControls();
        }

        private void InitializeFormControls()
        {
            lblLivro = new Label();
            lblLivro.Text = "Livro:";
            lblLivro.Location = new System.Drawing.Point(20, 20);

            cmbLivro = new ComboBox();  
            cmbLivro.DisplayMember = "TituloIsbn";  
            cmbLivro.ValueMember = "Isbn";  
            cmbLivro.DataSource = LivroData.ObterLivros();  
            cmbLivro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLivro.Location = new System.Drawing.Point(120, 20);
            cmbLivro.Width = 400;

            lblTipoAcervo = new Label();
            lblTipoAcervo.Text = "Tipo de Acervo:";
            lblTipoAcervo.Location = new System.Drawing.Point(20, 60);

            cmbTipoAcervo = new ComboBox();
            cmbTipoAcervo.DataSource = Enum.GetValues(typeof(TipoAcervoLivro))
                .Cast<TipoAcervoLivro>()
                .Where(value => value != TipoAcervoLivro.EmManutencao && value != TipoAcervoLivro.Indisponivel && value != TipoAcervoLivro.Inativo)
                .ToList();
            cmbTipoAcervo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoAcervo.Location = new System.Drawing.Point(120, 60);

            lblDescricao = new Label();
            lblDescricao.Text = "Descrição:";
            lblDescricao.Location = new System.Drawing.Point(20, 100);

            txtDescricao = new TextBox();
            txtDescricao.Multiline = true;
            txtDescricao.Location = new System.Drawing.Point(120, 100);
            txtDescricao.Width = 200;
            txtDescricao.Height = 80;

            btnSolicitar = new Button();
            btnSolicitar.Text = "Solicitar Reposição";
            btnSolicitar.Location = new System.Drawing.Point(120, 200);
            btnSolicitar.Click += BtnSolicitar_Click;

            Controls.Add(lblLivro);
            Controls.Add(cmbLivro);
            Controls.Add(lblTipoAcervo);
            Controls.Add(cmbTipoAcervo);
            Controls.Add(lblDescricao);
            Controls.Add(txtDescricao);
            Controls.Add(btnSolicitar);
        }

        private void BtnSolicitar_Click(object sender, EventArgs e)
        {
            controller.BtnSolicitarClick();
        }
    }
}
