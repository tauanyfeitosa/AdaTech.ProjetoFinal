using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views
{
    partial class TelaPrincipal
    {
        private bool confirmacaoSaidaExibida = false;
        private Label lblBemVindo;
        private Usuario usuarioLogado;
        private TelaPrincipalController telaPrincipalController;
        private Button bntVisualizarReservas = new Button();
        private int largura;
        private int altura;
        private Panel painelLogin;
        private Button bntVisualizarAlunos;
        private Button bntVisualizarProfessores;
        private Button btnCarregarCSVUsuario;
        private Button btnCarregarCSVEmprestimos;
        private Button btnCarregarCSVReserva;
        private Button btnVisualizarEmprestimos;
        private Button btnIniciarEmprestimo;
        private Button bntDevolverLivro;
        private Button btnCarregarCSVLivro;
        private Button btnVisualizarLivros;
        private Button btnSolicitarLivros;
        private Button btnVisualizarSolicitacoesLivrosNovos;
        private Button btnSolicitarMudarAcervo;
        private Button btnVisualizarSolicitacoesAcervos;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private Panel InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = $"Tela Principal - {telaPrincipalController.FiltrarLogin()}";

            painelLogin = new Panel();
            painelLogin.Size = new Size(largura - 200, altura - 200);
            painelLogin.Location = new Point((largura - painelLogin.Width) / 2, (altura - painelLogin.Height) - 200);
            painelLogin.BackColor = Color.LightGray;
            painelLogin.BorderStyle = BorderStyle.FixedSingle;
            painelLogin.Anchor = AnchorStyles.Left;
            painelLogin.AutoScroll = true;

            bntVisualizarReservas.Size = new Size(150, 20);
            bntVisualizarReservas.Location = new Point(20, 20);
            bntVisualizarReservas.Anchor = AnchorStyles.Right;
            bntVisualizarReservas.Text = "Visualizar Reservas";
            bntVisualizarReservas.Click += OnClickVisualizarReservas;

            bntVisualizarAlunos = new Button();
            bntVisualizarAlunos.Size = new Size(150, 20);
            bntVisualizarAlunos.Location = new Point(20, 50);
            bntVisualizarAlunos.Anchor = AnchorStyles.Right;
            bntVisualizarAlunos.Text = "Visualizar Alunos";
            bntVisualizarAlunos.Click += OnClickVisualizarAlunos;

            bntVisualizarProfessores = new Button();
            bntVisualizarProfessores.Size = new Size(150, 20);
            bntVisualizarProfessores.Location = new Point(20, 80);
            bntVisualizarProfessores.Anchor = AnchorStyles.Right;
            bntVisualizarProfessores.Text = "Visualizar Professores";
            bntVisualizarProfessores.Click += OnClickVisualizarProfessores;

            btnCarregarCSVUsuario = new Button();
            btnCarregarCSVUsuario.Size = new Size(300, 50);
            btnCarregarCSVUsuario.Location = new Point(20, 150);
            btnCarregarCSVUsuario.Anchor = AnchorStyles.Right;
            btnCarregarCSVUsuario.Text = "Carregar CSV - Usuários Comunidade Acadêmica";
            btnCarregarCSVUsuario.Click += OnClickCarregarCSV_CA;

            btnCarregarCSVEmprestimos = new Button();
            btnCarregarCSVEmprestimos.Size = new Size(300, 50);
            btnCarregarCSVEmprestimos.Location = new Point(20, 220);
            btnCarregarCSVEmprestimos.Anchor = AnchorStyles.Right;
            btnCarregarCSVEmprestimos.Text = "Carregar CSV - Emprestimos";
            btnCarregarCSVEmprestimos.Click += OnClickCarregarCSV_Emprestimo;

            btnCarregarCSVReserva = new Button();
            btnCarregarCSVReserva.Size = new Size(300, 50);
            btnCarregarCSVReserva.Location = new Point(20, 290);
            btnCarregarCSVReserva.Anchor = AnchorStyles.Right;
            btnCarregarCSVReserva.Text = "Carregar CSV - Reserva Livro";
            btnCarregarCSVReserva.Click += OnClickCarregarCSV_ReservaLivro;

            btnVisualizarEmprestimos = new Button();
            btnVisualizarEmprestimos.Size = new Size(150, 20);
            btnVisualizarEmprestimos.Location = new Point(20, 110);
            btnVisualizarEmprestimos.Anchor = AnchorStyles.Right;
            btnVisualizarEmprestimos.Text = "Visualizar Empréstimos";
            btnVisualizarEmprestimos.Click += OnClickVisualizarEmprestimos;

            btnIniciarEmprestimo = new Button();
            btnIniciarEmprestimo.Size = new Size(150, 20);
            btnIniciarEmprestimo.Location = new Point(20, 360);
            btnIniciarEmprestimo.Anchor = AnchorStyles.Right;
            btnIniciarEmprestimo.Text = "Iniciar Empréstimo";
            btnIniciarEmprestimo.Click += OnClickIniciarEmprestimo;

            bntDevolverLivro = new Button();
            bntDevolverLivro.Size = new Size(150, 20);
            bntDevolverLivro.Location = new Point(20, 400);
            bntDevolverLivro.Anchor = AnchorStyles.Right;
            bntDevolverLivro.Text = "Devolução";
            bntDevolverLivro.Click += OnClickDevolverLivro;

            btnCarregarCSVLivro = new Button();
            btnCarregarCSVLivro.Size = new Size(300, 50);
            btnCarregarCSVLivro.Location = new Point(20, 80);
            btnCarregarCSVLivro.Anchor = AnchorStyles.Right;
            btnCarregarCSVLivro.Text = "Carregar CSV - Adicionar Livro";
            btnCarregarCSVLivro.Click += OnClickCarregarCSVLivro;

            btnVisualizarLivros = new Button();
            btnVisualizarLivros.Size = new Size(150, 20);
            btnVisualizarLivros.Location = new Point(20, 50);
            btnVisualizarLivros.Anchor = AnchorStyles.Right;
            btnVisualizarLivros.Text = "Visualizar Livros";
            btnVisualizarLivros.Click += OnClickVisualizarLivros;

            btnSolicitarLivros = new Button();
            btnSolicitarLivros.Size = new Size(150, 20);
            btnSolicitarLivros.Location = new Point(20, 150);
            btnSolicitarLivros.Anchor = AnchorStyles.Right;
            btnSolicitarLivros.Text = "Solicitar Novos Livros";
            btnSolicitarLivros.Click += OnClickSolicitarLivros;

            btnVisualizarSolicitacoesLivrosNovos = new Button();
            btnVisualizarSolicitacoesLivrosNovos.AutoSize = true;
            btnVisualizarSolicitacoesLivrosNovos.Location = new Point(20, 180);
            btnVisualizarSolicitacoesLivrosNovos.Anchor = AnchorStyles.Left;
            btnVisualizarSolicitacoesLivrosNovos.Text = "Visualizar Solicitações de Lotes";
            btnVisualizarSolicitacoesLivrosNovos.Click += OnClickVisualizarSolicitacoesLivros;

            btnSolicitarMudarAcervo = new Button();
            btnSolicitarMudarAcervo.Size = new Size(150, 20);
            btnSolicitarMudarAcervo.Location = new Point(20, 210);
            btnSolicitarMudarAcervo.Anchor = AnchorStyles.Right;
            btnSolicitarMudarAcervo.Text = "Solicitar Mudar de Acervo";
            btnSolicitarMudarAcervo.Click += OnClickSolicitarMudarAcervo;

            btnVisualizarSolicitacoesAcervos = new Button();
            btnVisualizarSolicitacoesAcervos.AutoSize = true;
            btnVisualizarSolicitacoesAcervos.Location = new Point(20, 240);
            btnVisualizarSolicitacoesAcervos.Anchor = AnchorStyles.Left;
            btnVisualizarSolicitacoesAcervos.Text = "Visualizar Solicitações de Mudança de Acervo";
            btnVisualizarSolicitacoesAcervos.Click += OnClickVisualizarSolicitacoesAcervo;

            lblBemVindo = new Label();
            lblBemVindo.Text = $"Bem-vindo, {usuarioLogado.NomeCompleto}\nCargo: {telaPrincipalController.FiltrarLogin()} ";
            lblBemVindo.BackColor = Color.Transparent;
            lblBemVindo.ForeColor = Color.Black;
            lblBemVindo.AutoSize = true;
            lblBemVindo.Font = new Font("Arial", 20, FontStyle.Bold);
            lblBemVindo.Location = new System.Drawing.Point((largura - painelLogin.Width) / 2, 20);

            Button btnLogout = new Button();
            btnLogout.Size = new Size(100, 30);
            btnLogout.Location = new Point(painelLogin.Width + 100, painelLogin.Height + 100);
            btnLogout.Text = "Logout";
            btnLogout.Click += OnClickLogout;

            Controls.Add(lblBemVindo);
            Controls.Add(btnLogout);

            return painelLogin;
        }

        #endregion
    }
}