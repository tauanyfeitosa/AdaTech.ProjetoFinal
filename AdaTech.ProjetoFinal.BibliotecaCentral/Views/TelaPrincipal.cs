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
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor;

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

            #region Botão Carregar CSV

            Button btnCarregarCSV = new Button();
            btnCarregarCSV.Size = new Size(300, 50);
            btnCarregarCSV.Location = new Point(20, 110);
            btnCarregarCSV.Anchor = AnchorStyles.Right;
            btnCarregarCSV.Text = "Carregar CSV - Usuários Comunidade Acadêmica";
            btnCarregarCSV.Click += OnClickCarregarCSVCA;

            #endregion

            #region Botão Visualizar Emprestimos

            Button btnVisualizarEmprestimos = new Button();
            btnVisualizarEmprestimos.Size = new Size(150, 20);
            btnVisualizarEmprestimos.Location = new Point(20, 180);
            btnVisualizarEmprestimos.Anchor = AnchorStyles.Right;
            btnVisualizarEmprestimos.Text = "Visualizar Empréstimos";
            btnVisualizarEmprestimos.Click += OnClickVisualizarEmprestimos;

            #endregion

            painelAtendente.Controls.Add(bntVisualizarAlunos);
            painelAtendente.Controls.Add(bntVisualizarProfessores);
            painelAtendente.Controls.Add(btnCarregarCSV);
            painelAtendente.Controls.Add(btnVisualizarEmprestimos);
            painelAtendente.Controls.Add(_bntVisualizarReservas);

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

        private void OnClickCarregarCSVCA(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos CSV|*.csv|Todos os Arquivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivoCSV = openFileDialog.FileName;

                string diretorioDoAplicativo = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Data");

                string caminhoArquivoTxt = Path.Combine(diretorioDoAplicativo, "ComunidadeAcademica.txt");

                _telaPrincipalController.CarregarCSV(caminhoArquivoCSV, caminhoArquivoTxt, _usuarioLogado);

            }
        }
        #endregion

        #endregion


        #region Lógica Painel Bibliotecário
        private Panel CriarPainelBibliotecario(Panel painelBibliotecario)
        {
            painelBibliotecario.Controls.Clear();

            #region Botão Adicionar Livro
            Button btnAdicionarLivro = new Button();    

            Button btnCarregarCSV = new Button();
            btnCarregarCSV.Size = new Size(300, 50);
            btnCarregarCSV.Location = new Point(20, 80);
            btnCarregarCSV.Anchor = AnchorStyles.Right;
            btnCarregarCSV.Text = "Carregar CSV - Adicionar Livro";
            btnCarregarCSV.Click += OnClickCarregarCSVLivro;
            #endregion

            painelBibliotecario.Controls.Add(btnCarregarCSV);
            painelBibliotecario.Controls.Add(_bntVisualizarReservas);


            return painelBibliotecario;
        }
        #region On Click de Bibliotecario

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

            painelDiretor.Controls.Add(btnAdicionarFuncionarios);

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

        #endregion


        #region Lógica Painel Comunidade Acadêmica
        private Panel CriarPainelComunidadeAcademica(Panel painelComunidadeAcademica)
        {
            painelComunidadeAcademica.Controls.Clear();

            Button btnReservarLivro = new Button();
            btnReservarLivro.Size = new Size(300, 50);
            btnReservarLivro.Location = new Point(20, 80);
            btnReservarLivro.Anchor = AnchorStyles.Right;
            btnReservarLivro.Text = "Criar Reserva";
            btnReservarLivro.Click += OnClickReservarLivro;


            Button btnDevolverLivro = new Button();
            btnDevolverLivro.Size = new Size(300, 50);
            btnDevolverLivro.Location = new Point(70, 80);
            btnDevolverLivro.Anchor = AnchorStyles.Right;
            btnDevolverLivro.Text = "Devolver Livro";
            btnDevolverLivro.Click += OnClickDevolverLivro;

            Button btnPedirEmprestimo = new Button();
            btnPedirEmprestimo.Size = new Size(300, 50);
            btnPedirEmprestimo.Location = new Point(20, 135);
            btnPedirEmprestimo.Anchor = AnchorStyles.Right;
            btnPedirEmprestimo.Text = "Solicitar Emprestimo de Livro";
            btnPedirEmprestimo.Click += OnClickPedirEmprestimo;



            return painelComunidadeAcademica;
        }

        private void OnClickPedirEmprestimo(object sender, EventArgs e)
        {
            //Implementar criação da janela Pedir Emprestimo
            throw new NotImplementedException();
        }

        private void OnClickDevolverLivro(object sender, EventArgs e)
        {
            //Implementar criação da janela Devolver Livro
            throw new NotImplementedException();
        }

        private void OnClickReservarLivro(object sender, EventArgs e)
        {
            //Implementar criação da janela criar reserva
            throw new NotImplementedException();
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
