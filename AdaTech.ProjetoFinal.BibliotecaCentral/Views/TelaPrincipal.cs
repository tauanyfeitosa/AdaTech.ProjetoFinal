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
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasCA;

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

            #region Botão Visualizar Solicitações de Livros Novos

            Button btnVisualizarSolicitacoesLivrosNovos = new Button(); 
            btnVisualizarSolicitacoesLivrosNovos.AutoSize = true;
            btnVisualizarSolicitacoesLivrosNovos.Location = new Point(20, 180);
            btnVisualizarSolicitacoesLivrosNovos.Anchor = AnchorStyles.Left;
            btnVisualizarSolicitacoesLivrosNovos.Text = "Visualizar Solicitações de Lotes";
            btnVisualizarSolicitacoesLivrosNovos.Click += OnClickVisualizarSolicitacoesLivros;

            #endregion

            #region Botão Solicitar Mudança de Acervo

            Button btnSolicitarMudarAcervo = new Button();
            btnSolicitarMudarAcervo.Size = new Size(150, 20);
            btnSolicitarMudarAcervo.Location = new Point(20, 210);
            btnSolicitarMudarAcervo.Anchor = AnchorStyles.Right;
            btnSolicitarMudarAcervo.Text = "Solicitar Mudar de Acervo";
            btnSolicitarMudarAcervo.Click += OnClickSolicitarMudarAcervo;

            #endregion

            #region Botão Visualizar Solicitações de Mudanças de Acervo

            Button btnVisualizarSolicitacoesAcervos = new Button();
            btnVisualizarSolicitacoesAcervos.AutoSize = true;
            btnVisualizarSolicitacoesAcervos.Location = new Point(20, 240);
            btnVisualizarSolicitacoesAcervos.Anchor = AnchorStyles.Left;
            btnVisualizarSolicitacoesAcervos.Text = "Visualizar Solicitações de Mudança de Acervo";
            btnVisualizarSolicitacoesAcervos.Click += OnClickVisualizarSolicitacoesAcervo;

            #endregion


            painelBibliotecario.Controls.Add(btnCarregarCSV);
            painelBibliotecario.Controls.Add(btnVisualizarLivros);
            painelBibliotecario.Controls.Add(btnSolicitarLivros);
            painelBibliotecario.Controls.Add(btnVisualizarSolicitacoesLivrosNovos);
            painelBibliotecario.Controls.Add(btnSolicitarMudarAcervo);
            painelBibliotecario.Controls.Add(btnVisualizarSolicitacoesAcervos);

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

        private void OnClickVisualizarSolicitacoesLivros (Object sender, EventArgs e)
        {
            JanelaVisualizarSolicitacoesLivros visualizarSolicitacoesLivros = new JanelaVisualizarSolicitacoesLivros(_usuarioLogado);
            visualizarSolicitacoesLivros.ShowDialog();
        }

        private void OnClickSolicitarMudarAcervo (Object sender, EventArgs e)
        {
            JanelaSolicitarMudarAcervo solicitarMudarAcervo = new JanelaSolicitarMudarAcervo(_usuarioLogado);
            solicitarMudarAcervo.ShowDialog();
        }

        private void OnClickVisualizarSolicitacoesAcervo (Object sender, EventArgs e)
        {
            JanelaVisualizarMudancaAcervo visualizarMudancaAcervo = new JanelaVisualizarMudancaAcervo(_usuarioLogado);
            visualizarMudancaAcervo.ShowDialog();
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

            Button btnVisualizarSolicitacoes = new Button();
            btnVisualizarSolicitacoes.Size = new Size(150, 20);
            btnVisualizarSolicitacoes.Location = new Point(20, 110);
            btnVisualizarSolicitacoes.Anchor = AnchorStyles.Right;
            btnVisualizarSolicitacoes.Text = "Visualizar Solicitacoes";
            btnVisualizarSolicitacoes.Click += OnClickVisualizarSolicitacoes;

            painelDiretor.Controls.Add(btnAdicionarFuncionarios);
            painelDiretor.Controls.Add(btnVisualizarFuncionarios);
            painelDiretor.Controls.Add(btnVisualizarSolicitacoes);

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

        private void OnClickVisualizarSolicitacoes(object sender, EventArgs e)
        {
            using (MessageBoxCustomizada customMessageBox = new MessageBoxCustomizada("Escolha o tipo de solicitação:", "Ver Solicitações de Lote", "Ver Solicitações de Acervo"))
            {
                DialogResult result = customMessageBox.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    MostrarSolicitacoesDeLote();
                }
                else if (result == DialogResult.No)
                {
                    MostrarSolicitacoesDeAcervo();
                }
            }
        }


        private void MostrarSolicitacoesDeAcervo()
        {
            JanelaVisualizarSolicitacoes visualizarSolicitacoes = new JanelaVisualizarSolicitacoes(_usuarioLogado, TipoSolicitacao.MudarAcervoLivro);
            visualizarSolicitacoes.ShowDialog();
        }

        private void MostrarSolicitacoesDeLote()
        {
            JanelaVisualizarSolicitacoes visualizarSolicitacoes = new JanelaVisualizarSolicitacoes(_usuarioLogado, TipoSolicitacao.RequisicaoLivro);
            visualizarSolicitacoes.ShowDialog();
        }



        #endregion


        #region Lógica Painel Comunidade Acadêmica
        private Panel CriarPainelComunidadeAcademica(Panel painelComunidadeAcademica)
        {
            ComunidadeAcademica usuarioCA = UsuarioData.SelecionarComunidadeAcademica(_usuarioLogado.Login);
            if (usuarioCA.TipoUsuario == TipoUsuarioComunidade.Professor)
            {
                usuarioCA.AtribuirNovaSenha();
            }

            painelComunidadeAcademica.Controls.Clear();

            #region Botão VizualizarAcervo

            Button bntVisualizarAcervo = new Button();
            bntVisualizarAcervo.Size = new Size(150, 20);
            bntVisualizarAcervo.Location = new Point(20, 50);
            bntVisualizarAcervo.Anchor = AnchorStyles.Right;
            bntVisualizarAcervo.Text = "Visualizar Acervo";
            bntVisualizarAcervo.Click += OnClickVisualizarAcervo;

            #endregion

            #region Botão ReservarLivro

            Button bntReservar = new Button();
            bntReservar.Size = new Size(150, 20);
            bntReservar.Location = new Point(20, 90);
            bntReservar.Anchor = AnchorStyles.Right;
            bntReservar.Text = "Reservar Livro";
            bntReservar.Click += OnClickReservarLivro;

            #endregion

            #region Botão RenovarLivro

            Button bntRenovar = new Button();
            bntRenovar.Size = new Size(150, 20);
            bntRenovar.Location = new Point(20, 130);
            bntRenovar.Anchor = AnchorStyles.Right;
            bntRenovar.Text = "Renovar Livro";
            bntRenovar.Click += OnClickRenovarLivro;

            #endregion

            #region Botão Multas

            Button bntMultas = new Button();
            bntMultas.Size = new Size(150, 20);
            bntMultas.Location = new Point(20, 170);
            bntMultas.Anchor = AnchorStyles.Right;
            bntMultas.Text = "Pagar Multa";
            bntMultas.Click += OnClickMultas;

            #endregion

            painelComunidadeAcademica.Controls.Add(bntVisualizarAcervo);
            painelComunidadeAcademica.Controls.Add(bntReservar);
            painelComunidadeAcademica.Controls.Add(bntRenovar);
            painelComunidadeAcademica.Controls.Add(bntMultas);

            return painelComunidadeAcademica;
        }
        #endregion

        #region OnClick de CA
        private void OnClickVisualizarAcervo(object sender, EventArgs e)
        {
            JanelaVisualizarAcervo visualizarAcervo = new JanelaVisualizarAcervo();
            visualizarAcervo.ShowDialog();
        }
        private void OnClickReservarLivro(object sender, EventArgs e)
        {
            //JanelaReservarLivro reservar = new JanelaReservarLivro();
            //reservar.ShowDialog();
        }
        private void OnClickRenovarLivro(object sender, EventArgs e)
        {
            JanelaRenovarLivro renovar = new JanelaRenovarLivro();
            renovar.ShowDialog();
        }
        private void OnClickMultas(object sender, EventArgs e)
        {
            JanelaMultasUsuario multas = new JanelaMultasUsuario(_usuarioLogado);
            multas.ShowDialog();
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
