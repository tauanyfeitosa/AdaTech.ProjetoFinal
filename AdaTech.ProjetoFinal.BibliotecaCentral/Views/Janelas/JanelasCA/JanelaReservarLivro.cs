using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelComunidadeController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasCA
{
    public partial class JanelaReservarLivro : Form
    {
        private ComboBox cbLivros;
        private Button btnReservar;
        private Label lblMensagem;
        private ComunidadeAcademica _usuarioLogado;

        internal ComunidadeAcademica UsuarioLogado
        {
            get { return _usuarioLogado; }
            set { _usuarioLogado = value;}
        }

        internal Livro LivroSelecionado
        {
            get { return (Livro)cbLivros.SelectedItem; }
        }

        public event EventHandler ReservarClick;
        internal JanelaReservarLivro(string usuario)
        {
            _usuarioLogado = UsuarioData.SelecionarComunidadeAcademica(usuario);
            InitializeComponent();
            InicializarTela();

            ReservarLivroController controller = new ReservarLivroController(this);

            controller.CarregarLivros();
        }

        internal void InicializarTela()
        {
            cbLivros = new ComboBox();
            cbLivros.Location = new System.Drawing.Point(20, 20);
            cbLivros.Size = new System.Drawing.Size(300, 25);
            cbLivros.DropDownStyle = ComboBoxStyle.DropDownList;
            Controls.Add(cbLivros);

            Label lblLivros = new Label();
            lblLivros.Text = "Livros:";
            lblLivros.Location = new System.Drawing.Point(330, 20);
            lblLivros.AutoSize = true;
            Controls.Add(lblLivros);

            btnReservar = new Button();
            btnReservar.Text = "Reservar";
            btnReservar.Location = new System.Drawing.Point(20, 330);
            btnReservar.Click += (sender, e) => ReservarClick?.Invoke(sender, e);
            Controls.Add(btnReservar);

            lblMensagem = new Label();
            lblMensagem.Location = new System.Drawing.Point(20, 520);
            lblMensagem.AutoSize = true;
            Controls.Add(lblMensagem);
        }

        public void MostrarMensagem(string mensagem, char tipo)
        {
            lblMensagem.Text = mensagem;
            if (tipo == 'g')
            {
                lblMensagem.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }
        }
        internal void AtualizarListaLivros(List<Livro> livros)
        {
            cbLivros.DataSource = livros;
            cbLivros.DisplayMember = "Titulo";
            cbLivros.ValueMember = "Isbn";
        }

        public ComboBox LivrosComboBox => cbLivros;
    }
}
