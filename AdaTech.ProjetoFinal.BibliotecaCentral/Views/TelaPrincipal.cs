using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views
{
    internal partial class TelaPrincipal : Form
    {
        private Label _lblBemVindo;
        private Usuario _usuarioLogado;
        private TelaPrincipalController _telaPrincipalController;

        internal TelaPrincipal(Usuario usuario)
        {
            Load += OnLoad;
            this._usuarioLogado = usuario;
            this._telaPrincipalController = new TelaPrincipalController(usuario);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            int larguraTela = this.ClientSize.Width;
            int alturaTela = this.ClientSize.Height;

            InitializeTela(larguraTela, alturaTela);
        }

        internal void InitializeTela(int largura, int altura)
        {
            var painelLogin = new Panel();
            painelLogin.Size = new Size(largura - 200, altura - 200);
            painelLogin.Location = new Point((largura - painelLogin.Width) / 2, (altura - painelLogin.Height) / 2);
            painelLogin.BackColor = Color.LightGray;
            painelLogin.BorderStyle = BorderStyle.FixedSingle;
            painelLogin.Anchor = AnchorStyles.None;
            painelLogin.AutoScroll = true;

            _lblBemVindo = new Label();
            _lblBemVindo.Text = $"Bem-vindo, {_usuarioLogado.NomeCompleto}\nCargo:{_telaPrincipalController.FiltrarLogin()} " ;
            _lblBemVindo.BackColor = Color.Transparent;
            _lblBemVindo.ForeColor = Color.Black;
            _lblBemVindo.AutoSize = true;
            _lblBemVindo.Font = new Font("Arial", 30, FontStyle.Bold);
            _lblBemVindo.Location = new System.Drawing.Point((largura / 2), 20);
            
            Controls.Add(_lblBemVindo);
            Controls.Add(painelLogin);
        }       
    }
}
