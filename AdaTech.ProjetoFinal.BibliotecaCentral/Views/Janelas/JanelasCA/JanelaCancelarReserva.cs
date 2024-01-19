using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelComunidadeController;
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
    public partial class JanelaCancelarReserva : Form
    {
        private ComunidadeAcademica _usuarioLogado;
        public event EventHandler CancelarReservaClick;
        private ComboBox cmbReservas;
        private Button btnCancelarReserva;

        internal ComunidadeAcademica UsuarioLogado
        {
            get { return _usuarioLogado; }
            set { _usuarioLogado = value; }
        }

        internal JanelaCancelarReserva(string usuario)
        {
            _usuarioLogado = UsuarioData.SelecionarComunidadeAcademica(usuario);
            InitializeComponent();
            InicializarTela();

            CancelarReservaController controller = new CancelarReservaController(this);
            controller.CarregarReserva();
        }

        private void InicializarTela()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Janela Cancelar Reserva";

            cmbReservas = new ComboBox();
            cmbReservas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReservas.Location = new System.Drawing.Point(20, 20);
            cmbReservas.Size = new System.Drawing.Size(300, 25);
            Controls.Add(cmbReservas);

            Label lblReservas = new Label();
            lblReservas.Text = "Reservas:";
            lblReservas.Location = new System.Drawing.Point(330, 20);
            lblReservas.AutoSize = true;
            Controls.Add(lblReservas);

            btnCancelarReserva = new Button();
            btnCancelarReserva.Text = "Cancelar Reserva";
            btnCancelarReserva.Location = new System.Drawing.Point(20, 330);
            btnCancelarReserva.Size = new System.Drawing.Size(147, 33);
            btnCancelarReserva.Click += (sender, e) => CancelarReservaClick?.Invoke(sender, e);
            Controls.Add(btnCancelarReserva);
        }

        public void MostrarMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }
        internal ComboBox CmbReservas { get => cmbReservas; private set => cmbReservas = value; }
    }
}
