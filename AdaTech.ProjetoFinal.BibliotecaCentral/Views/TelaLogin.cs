using System;
using System.Drawing;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views;
using System.Collections.Generic;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    public partial class TelaLogin : Form
    {

        [STAThread]
        public static void Main(string[] args)
        {
            LivroData.CarregarLivros();
            UsuarioData.CarregarUsuarios();
            EmprestimoData.CarregarEmprestimos();
            ReservaLivroData.CarregarReservas();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaLogin());
        }

        public TelaLogin()
        {
            Load += OnLoad;
            FormClosing += OnFormClosing;
            this.controller = new TelaInicialController(this);

            InitializeComponent();

        }


        private void OnLoad(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            largura = this.ClientSize.Width;
            altura = this.ClientSize.Height;
        }


        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
           Application.Exit();
        }

        private void OnClickEntrar(object sender, EventArgs e)
        {
            string usuarioDigitado = txtUsuario.Text;
            string senhaDigitada = txtSenha.Text;

            if (controller.ValidaLogin())
            {
                if (controller.RealizarLogin())
                {
                    this.Hide();
                    var telaPrincipal = new TelaPrincipal(UsuarioData.SelecionarUsuario(usuarioDigitado));
                    telaPrincipal.Show();
                }
            }
        }
    }
}
