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

        internal TelaPrincipal(Usuario usuario)
        {
            Load += OnLoad;
            FormClosing += OnFormClosing;
            this.usuarioLogado = usuario;
            this.telaPrincipalController = new TelaPrincipalController(usuario);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            largura = this.ClientSize.Width;
            altura = this.ClientSize.Height;

            SelecionarInterface(telaPrincipalController.FiltrarLogin(), InitializeComponent());
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !confirmacaoSaidaExibida)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    confirmacaoSaidaExibida = true;
                    Application.Exit();
                }
            }
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

            painelAtendente.Controls.Add(bntVisualizarAlunos);
            painelAtendente.Controls.Add(bntVisualizarProfessores);
            painelAtendente.Controls.Add(btnCarregarCSVUsuario);
            painelAtendente.Controls.Add(btnCarregarCSVEmprestimos);
            painelAtendente.Controls.Add(btnCarregarCSVReserva);
            painelAtendente.Controls.Add(btnVisualizarEmprestimos);
            painelAtendente.Controls.Add(bntVisualizarReservas);
            painelAtendente.Controls.Add(btnIniciarEmprestimo);
            painelAtendente.Controls.Add(bntDevolverLivro);

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

                telaPrincipalController.CarregarCSV(caminhoArquivoCSV, caminhoArquivoTxt, usuarioLogado, "ComunidadeAcademica");

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

                telaPrincipalController.CarregarCSV(caminhoArquivoCSV, caminhoArquivoTxt, usuarioLogado, "Emprestimo");

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

                telaPrincipalController.CarregarCSV(caminhoArquivoCSV, caminhoArquivoTxt, usuarioLogado, "ReservaLivro");

            }
        }

        private void OnClickIniciarEmprestimo(object sender, EventArgs e)
        {
            JanelaIniciarEmprestimo janelaIniciarEmprestimo = new JanelaIniciarEmprestimo();
            janelaIniciarEmprestimo.ShowDialog();
        }
        private void OnClickDevolverLivro(object sender, EventArgs e)
        {
            JanelaDevolucao devolucao = new JanelaDevolucao(usuarioLogado);
            devolucao.ShowDialog();
        }
        #endregion

        #endregion


        #region Lógica Painel Bibliotecário
        private Panel CriarPainelBibliotecario(Panel painelBibliotecario)
        {
            painelBibliotecario.Controls.Clear();

            painelBibliotecario.Controls.Add(btnCarregarCSVLivro);
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

                telaPrincipalController.CarregarCSV(caminhoArquivoCSV, caminhoArquivoTxt, usuarioLogado);

            }
        }

        private void OnClickVisualizarLivros(object sender, EventArgs e)
        {
            JanelaVisualizarLivros visualizarLivros = new JanelaVisualizarLivros();
            visualizarLivros.ShowDialog();
        }

        private void OnClickSolicitarLivros (object sender, EventArgs e)
        {
            JanelaSolicitarLivros solicitarLivros = new JanelaSolicitarLivros (usuarioLogado);
            solicitarLivros.ShowDialog();
        }

        private void OnClickVisualizarSolicitacoesLivros (Object sender, EventArgs e)
        {
            JanelaVisualizarSolicitacoesLivros visualizarSolicitacoesLivros = new JanelaVisualizarSolicitacoesLivros(usuarioLogado);
            visualizarSolicitacoesLivros.ShowDialog();
        }

        private void OnClickSolicitarMudarAcervo (Object sender, EventArgs e)
        {
            JanelaSolicitarMudarAcervo solicitarMudarAcervo = new JanelaSolicitarMudarAcervo(usuarioLogado);
            solicitarMudarAcervo.ShowDialog();
        }

        private void OnClickVisualizarSolicitacoesAcervo (Object sender, EventArgs e)
        {
            JanelaVisualizarMudancaAcervo visualizarMudancaAcervo = new JanelaVisualizarMudancaAcervo(usuarioLogado);
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

            painelDiretor.Controls.Add(bntVisualizarReservas);

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

                telaPrincipalController.CarregarCSV(caminhoArquivoCSV, caminhoArquivoTxt, usuarioLogado);

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
            JanelaVisualizarSolicitacoes visualizarSolicitacoes = new JanelaVisualizarSolicitacoes(usuarioLogado, TipoSolicitacao.MudarAcervoLivro);
            visualizarSolicitacoes.ShowDialog();
        }

        private void MostrarSolicitacoesDeLote()
        {
            JanelaVisualizarSolicitacoes visualizarSolicitacoes = new JanelaVisualizarSolicitacoes(usuarioLogado, TipoSolicitacao.RequisicaoLivro);
            visualizarSolicitacoes.ShowDialog();
        }



        #endregion


        #region Lógica Painel Comunidade Acadêmica
        private Panel CriarPainelComunidadeAcademica(Panel painelComunidadeAcademica)
        {
            ComunidadeAcademica usuarioCA = UsuarioData.SelecionarComunidadeAcademica(usuarioLogado.Login);
            if (usuarioCA != null && usuarioCA.TipoUsuario == TipoUsuarioComunidade.Professor)
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

            #region Botão RenovarLivro

            Button bntRenovar = new Button();
            bntRenovar.Size = new Size(150, 20);
            bntRenovar.Location = new Point(20, 90);
            bntRenovar.Anchor = AnchorStyles.Right;
            bntRenovar.Text = "Renovar Livro";
            bntRenovar.Click += OnClickRenovarLivro;

            #endregion

            #region Botão Multas

            Button bntMultas = new Button();
            bntMultas.Size = new Size(150, 20);
            bntMultas.Location = new Point(20, 130);
            bntMultas.Anchor = AnchorStyles.Right;
            bntMultas.Text = "Pagar Multa";
            bntMultas.Click += OnClickMultas;

            #endregion

            /*#region Botão ReservarLivro

            Button bntReservar = new Button();
            bntReservar.Size = new Size(150, 20);
            bntReservar.Location = new Point(20, 170);
            bntReservar.Anchor = AnchorStyles.Right;
            bntReservar.Text = "Reservar Livro";
            bntReservar.Click += OnClickReservarLivro;

            #endregion*/

            painelComunidadeAcademica.Controls.Add(bntVisualizarAcervo);
            //painelComunidadeAcademica.Controls.Add(bntReservar);
            painelComunidadeAcademica.Controls.Add(bntRenovar);
            painelComunidadeAcademica.Controls.Add(bntMultas);

            return painelComunidadeAcademica;
        }

        #region OnClick de CA
        private void OnClickVisualizarAcervo(object sender, EventArgs e)
        {
            JanelaVisualizarAcervo visualizarAcervo = new JanelaVisualizarAcervo();
            visualizarAcervo.ShowDialog();
        }
        /*private void OnClickReservarLivro(object sender, EventArgs e)
        {
            JanelaReservarLivro reservar = new JanelaReservarLivro();
            reservar.ShowDialog();
        }*/
        private void OnClickRenovarLivro(object sender, EventArgs e)
        {
            JanelaRenovarLivro renovar = new JanelaRenovarLivro(usuarioLogado);
            renovar.ShowDialog();
        }
        private void OnClickMultas(object sender, EventArgs e)
        {
            JanelaMultasUsuario multas = new JanelaMultasUsuario(usuarioLogado);
            multas.ShowDialog();
        }
        #endregion

        #endregion

        private void OnClickLogout(object sender, EventArgs e)
        {
            confirmacaoSaidaExibida = true;
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.Show();

            this.Close();
        }
    }
}
