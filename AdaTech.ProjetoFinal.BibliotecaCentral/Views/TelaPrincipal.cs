using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Utilities;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views
{
    internal partial class TelaPrincipal : Form
    {
        private bool _confirmacaoSaidaExibida = false;
        private Label _lblBemVindo;
        private Usuario _usuarioLogado;
        private TelaPrincipalController _telaPrincipalController;
        private Button _bntVisualizarReservas = new Button();


        internal TelaPrincipal(Usuario usuario)
        {
            Load += OnLoad;
            FormClosing += OnFormClosing;
            this._usuarioLogado = usuario;
            this._telaPrincipalController = new TelaPrincipalController(usuario);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            int larguraTela = this.ClientSize.Width;
            int alturaTela = this.ClientSize.Height;

            SelecionarInterface(_telaPrincipalController.FiltrarLogin(), InitializeTela(larguraTela, alturaTela));
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !_confirmacaoSaidaExibida)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _confirmacaoSaidaExibida = true;
                    Application.Exit();
                }
            }
        }

        private Panel InitializeTela(int largura, int altura)
        {
            var painelLogin = new Panel();
            painelLogin.Size = new Size(largura - 200, altura - 200);
            painelLogin.Location = new Point((largura - painelLogin.Width) / 2, (altura - painelLogin.Height) / 2);
            painelLogin.BackColor = Color.LightGray;
            painelLogin.BorderStyle = BorderStyle.FixedSingle;
            painelLogin.Anchor = AnchorStyles.None;
            painelLogin.AutoScroll = true;

            _bntVisualizarReservas.Size = new Size(150, 20);
            _bntVisualizarReservas.Location = new Point(20, 20);
            _bntVisualizarReservas.Anchor = AnchorStyles.Right;
            _bntVisualizarReservas.Text = "Visualizar Reservas";
            _bntVisualizarReservas.Click += OnClickVisualizarReservas;

            _lblBemVindo = new Label();
            _lblBemVindo.Text = $"Bem-vindo, {_usuarioLogado.NomeCompleto}\nCargo: {_telaPrincipalController.FiltrarLogin()} " ;
            _lblBemVindo.BackColor = Color.Transparent;
            _lblBemVindo.ForeColor = Color.Black;
            _lblBemVindo.AutoSize = true;
            _lblBemVindo.Font = new Font("Arial", 20, FontStyle.Bold);
            _lblBemVindo.Location = new System.Drawing.Point((largura - painelLogin.Width)/2, 20);

            Button btnLogout = new Button();
            btnLogout.Size = new Size(100, 30);
            btnLogout.Location = new Point(painelLogin.Width + 100, painelLogin.Height + 100);
            btnLogout.Text = "Logout";
            btnLogout.Click += OnClickLogout;

            Controls.Add(_lblBemVindo);
            Controls.Add(btnLogout);

            return painelLogin;
        }

        private void SelecionarInterface(string tipoUsuarioLogado, Panel painel)
        {
            switch (tipoUsuarioLogado)
            {
                case "Atendente":
                    painel = CriarPainelAtendente(painel);
                    break;
                case "Bibliotecário":
                    painel = CriarPainelBibliotecario(painel);
                    break;
                case "Diretor":
                    painel = CriarPainelDiretor(painel);
                    break;
                case "Professor":
                case "Aluno":
                    painel = CriarPainelComunidadeAcademica(painel);
                    break;
            }

            if (painel != null)
            {
                Controls.Add(painel);
            }
        }

        #region Lógica Painel Atendente
        private Panel CriarPainelAtendente(Panel painelAtendente)
        {
            painelAtendente.Controls.Clear();

            #region Botão VizualizarAlunos

            Button bntVisualizarAlunos = new Button();
            bntVisualizarAlunos.Size = new Size(150, 20);
            bntVisualizarAlunos.Location = new Point(20, 50);
            bntVisualizarAlunos.Anchor = AnchorStyles.Right;
            bntVisualizarAlunos.Text = "Visualizar Alunos";
            bntVisualizarAlunos.Click += OnClickVisualizarAlunos;

            #endregion

            #region Botão VisualizarProfessores

            Button bntVisualizarProfessores = new Button();
            bntVisualizarProfessores.Size = new Size(150, 20);
            bntVisualizarProfessores.Location = new Point(20, 80);
            bntVisualizarProfessores.Anchor = AnchorStyles.Right;
            bntVisualizarProfessores.Text = "Visualizar Professores";
            bntVisualizarProfessores.Click += OnClickVisualizarProfessores;

            #endregion

            #region Botão Carregar CSV Comunidade Academica

            Button btnCarregarCSV = new Button();
            btnCarregarCSV.Size = new Size(300, 50);
            btnCarregarCSV.Location = new Point(20, 150);
            btnCarregarCSV.Anchor = AnchorStyles.Right;
            btnCarregarCSV.Text = "Carregar CSV - Usuários Comunidade Acadêmica";
            btnCarregarCSV.Click += OnClickCarregarCSV_CA;

            #endregion

            #region Botão Carregar CSV Emprestimos

            Button btnCarregarCSVEmprestimos = new Button();
            btnCarregarCSVEmprestimos.Size = new Size(300, 50);
            btnCarregarCSVEmprestimos.Location = new Point(20, 220);
            btnCarregarCSVEmprestimos.Anchor = AnchorStyles.Right;
            btnCarregarCSVEmprestimos.Text = "Carregar CSV - Emprestimos";
            btnCarregarCSVEmprestimos.Click += OnClickCarregarCSV_Emprestimo;


            #endregion

            #region Botão Carregar CSV ReservaLivro

            Button btnCarregarCSVReserva = new Button();
            btnCarregarCSVReserva.Size = new Size(300, 50);
            btnCarregarCSVReserva.Location = new Point(20, 290);
            btnCarregarCSVReserva.Anchor = AnchorStyles.Right;
            btnCarregarCSVReserva.Text = "Carregar CSV - Reserva Livro";
            btnCarregarCSVReserva.Click += OnClickCarregarCSV_ReservaLivro;

            #endregion

            #region Botão Visualizar Emprestimos

            Button btnVisualizarEmprestimos = new Button();
            btnVisualizarEmprestimos.Size = new Size(150, 20);
            btnVisualizarEmprestimos.Location = new Point(20,110);
            btnVisualizarEmprestimos.Anchor = AnchorStyles.Right;
            btnVisualizarEmprestimos.Text = "Visualizar Empréstimos";
            btnVisualizarEmprestimos.Click += OnClickVisualizarEmprestimos;

            #endregion

            #region Botão Iniciar Emprestimo

            Button btnIniciarEmprestimo = new Button();
            btnIniciarEmprestimo.Size = new Size(150, 20);
            btnIniciarEmprestimo.Location = new Point(20, 360);
            btnIniciarEmprestimo.Anchor = AnchorStyles.Right;
            btnIniciarEmprestimo.Text = "Iniciar Empréstimo";
            btnIniciarEmprestimo.Click += OnClickIniciarEmprestimo; 

            #endregion

            painelAtendente.Controls.Add(bntVisualizarAlunos);
            painelAtendente.Controls.Add(bntVisualizarProfessores);
            painelAtendente.Controls.Add(btnCarregarCSV);
            painelAtendente.Controls.Add(btnCarregarCSVEmprestimos);
            painelAtendente.Controls.Add(btnCarregarCSVReserva);
            painelAtendente.Controls.Add(btnVisualizarEmprestimos);
            painelAtendente.Controls.Add(_bntVisualizarReservas);
            painelAtendente.Controls.Add(btnIniciarEmprestimo);

            return painelAtendente;
        }


        #region OnClick de Atendente
        private void OnClickVisualizarAlunos(object sender, EventArgs e)
        {
            JanelaVisualizarAlunos visualizarAlunos = new JanelaVisualizarAlunos();
            visualizarAlunos.ShowDialog();

        }

        private void OnClickVisualizarProfessores(object sender, EventArgs e)
        {
            JanelaVisualizarProfessores visualizarProfessores = new JanelaVisualizarProfessores();
            visualizarProfessores.ShowDialog();
        }

        private void OnClickVisualizarEmprestimos(object sender, EventArgs e)
        {
            JanelaVisualizarEmprestimos visualizarEmprestimos = new JanelaVisualizarEmprestimos();
            visualizarEmprestimos.ShowDialog();
        }

        private void OnClickCarregarCSV_CA(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos CSV|*.csv|Todos os Arquivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivoCSV = openFileDialog.FileName;

                string diretorioDoAplicativo = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Data");

                string caminhoArquivoTxt = Path.Combine(diretorioDoAplicativo, "ComunidadeAcademica.txt");

                _telaPrincipalController.CarregarCSV(caminhoArquivoCSV, caminhoArquivoTxt, _usuarioLogado, "ComunidadeAcademica");

            }
        }

        private void OnClickCarregarCSV_Emprestimo(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos TXT|*.txt|Todos os Arquivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivoCSV = openFileDialog.FileName;

                string diretorioDoAplicativo = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Data");

                string caminhoArquivoTxt = Path.Combine(diretorioDoAplicativo, "Emprestimo.txt");

                _telaPrincipalController.CarregarCSV(caminhoArquivoCSV, caminhoArquivoTxt, _usuarioLogado, "Emprestimo");

            }
        }

        private void OnClickCarregarCSV_ReservaLivro(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos TXT|*.txt|Todos os Arquivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivoCSV = openFileDialog.FileName;

                string diretorioDoAplicativo = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Data");

                string caminhoArquivoTxt = Path.Combine(diretorioDoAplicativo, "Reservas.txt");

                _telaPrincipalController.CarregarCSV(caminhoArquivoCSV, caminhoArquivoTxt, _usuarioLogado, "ReservaLivro");

            }
        }

        private void OnClickIniciarEmprestimo(object sender, EventArgs e)
        {
            JanelaIniciarEmprestimo janelaIniciarEmprestimo = new JanelaIniciarEmprestimo();
            janelaIniciarEmprestimo.ShowDialog();
        }
        #endregion

        #endregion


        #region Lógica Painel Bibliotecário
        private Panel CriarPainelBibliotecario(Panel painelBibliotecario)
        {
            painelBibliotecario.Controls.Clear();

            #region Botão Carregar CSV Livro

            Button btnCarregarCSV = new Button();
            btnCarregarCSV.Size = new Size(300, 50);
            btnCarregarCSV.Location = new Point(20, 80);
            btnCarregarCSV.Anchor = AnchorStyles.Right;
            btnCarregarCSV.Text = "Carregar CSV - Adicionar Livro";
            btnCarregarCSV.Click += OnClickCarregarCSVLivro;

            #endregion

            #region Botão Visualizar Livros

            Button btnVisualizarLivros = new Button();
            btnVisualizarLivros.Size = new Size(150, 20);
            btnVisualizarLivros.Location = new Point(20, 50);
            btnVisualizarLivros.Anchor = AnchorStyles.Right;
            btnVisualizarLivros.Text = "Visualizar Livros";
            btnVisualizarLivros.Click += OnClickVisualizarLivros;

            #endregion

            #region Botão Solicitar Livros

            Button btnSolicitarLivros = new Button();
            btnSolicitarLivros.Size = new Size(150, 20);
            btnSolicitarLivros.Location = new Point(20, 150);
            btnSolicitarLivros.Anchor = AnchorStyles.Right;
            btnSolicitarLivros.Text = "Solicitar Novos Livros";
            btnSolicitarLivros.Click += OnClickSolicitarLivros; 

            #endregion



            painelBibliotecario.Controls.Add(btnCarregarCSV);
            painelBibliotecario.Controls.Add(btnVisualizarLivros);
            painelBibliotecario.Controls.Add(btnSolicitarLivros);

            return painelBibliotecario;
        }

        #region OnClick de Bibliotecario

        private void OnClickCarregarCSVLivro(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos TXT|*.txt|Todos os Arquivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivoCSV = openFileDialog.FileName;

                string diretorioDoAplicativo = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Data");

                string caminhoArquivoTxt = Path.Combine(diretorioDoAplicativo, "Livros.txt");

                _telaPrincipalController.CarregarCSV(caminhoArquivoCSV, caminhoArquivoTxt, _usuarioLogado);

            }
        }

        private void OnClickVisualizarLivros(object sender, EventArgs e)
        {
            JanelaVisualizarLivros visualizarLivros = new JanelaVisualizarLivros();
            visualizarLivros.ShowDialog();
        }

        private void OnClickSolicitarLivros (object sender, EventArgs e)
        {
            JanelaSolicitarLivros solicitarLivros = new JanelaSolicitarLivros (_usuarioLogado);
            solicitarLivros.ShowDialog();
        }

        #endregion
        #endregion


        #region Lógica Painel Diretor
        private Panel CriarPainelDiretor(Panel painelDiretor)
        {
            painelDiretor.Controls.Clear();

            Button btnAdicionarFuncionarios = new Button();
            btnAdicionarFuncionarios.Size = new Size(150, 20);
            btnAdicionarFuncionarios.Location = new Point(20, 50);
            btnAdicionarFuncionarios.Anchor = AnchorStyles.Right;
            btnAdicionarFuncionarios.Text = "Adicionar Funcionários - CSV";
            btnAdicionarFuncionarios.Click += OnClickAdicionarFuncionarios;

            Button btnVisualizarFuncionarios = new Button();
            btnVisualizarFuncionarios.Size = new Size(150, 20);
            btnVisualizarFuncionarios.Location = new Point(20, 80);
            btnVisualizarFuncionarios.Anchor = AnchorStyles.Right;
            btnVisualizarFuncionarios.Text = "Visualizar Funcionários";
            btnVisualizarFuncionarios.Click += OnClickVisualizarFuncionarios;

            painelDiretor.Controls.Add(btnAdicionarFuncionarios);
            painelDiretor.Controls.Add(btnVisualizarFuncionarios);

            painelDiretor.Controls.Add(_bntVisualizarReservas);

            return painelDiretor;
        }
        private void OnClickVisualizarReservas(object sender, EventArgs e)
        {
            JanelaVisualizaReserva janelaVisualizaReserva = new JanelaVisualizaReserva();
            janelaVisualizaReserva.ShowDialog();
        }


        private void OnClickAdicionarFuncionarios(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos CSV|*.csv|Todos os Arquivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivoCSV = openFileDialog.FileName;

                string diretorioDoAplicativo = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Data");

                string caminhoArquivoTxt = Path.Combine(diretorioDoAplicativo, "Funcionarios.txt");

                _telaPrincipalController.CarregarCSV(caminhoArquivoCSV, caminhoArquivoTxt, _usuarioLogado);

            }
        }

        private void OnClickVisualizarFuncionarios(object sender, EventArgs e)
        {
            JanelaVisualizarFuncionarios visualizarFuncionarios = new JanelaVisualizarFuncionarios();
            visualizarFuncionarios.ShowDialog();
        }

        #endregion


        #region Lógica Painel Comunidade Acadêmica
        private Panel CriarPainelComunidadeAcademica(Panel painelComunidadeAcademica)
        {
            ComunidadeAcademica professor = UsuarioData.SelecionarComunidadeAcademica(_usuarioLogado.Login);
            professor.AtribuirNovaSenha();

            painelComunidadeAcademica.Controls.Clear();

            return painelComunidadeAcademica;
        }
        #endregion

        private void OnClickLogout(object sender, EventArgs e)
        {
            _confirmacaoSaidaExibida = true;
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.Show();

            this.Close();
        }
    }
}
