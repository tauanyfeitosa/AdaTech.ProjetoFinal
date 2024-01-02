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

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views
{
    internal partial class TelaPrincipal : Form
    {
        private bool _confirmacaoSaidaExibida = false;
        private Label _lblBemVindo;
        private Usuario _usuarioLogado;
        private TelaPrincipalController _telaPrincipalController;

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
            bntVisualizarAlunos.Location = new Point(20, 20);
            bntVisualizarAlunos.Anchor = AnchorStyles.Right;
            bntVisualizarAlunos.Text = "Visualizar Alunos";
            bntVisualizarAlunos.Click += OnClickVisualizarAlunos;

            #endregion

            #region Botão VisualizarProfessores

            Button bntVisualizarProfessores = new Button();
            bntVisualizarProfessores.Size = new Size(150, 20);
            bntVisualizarProfessores.Location = new Point(20, 50);
            bntVisualizarProfessores.Anchor = AnchorStyles.Right;
            bntVisualizarProfessores.Text = "Visualizar Professores";
            bntVisualizarProfessores.Click += OnClickVisualizarProfessores;

            #endregion

            #region Botão Carregar CSV

            Button btnCarregarCSV = new Button();
            btnCarregarCSV.Size = new Size(300, 50);
            btnCarregarCSV.Location = new Point(20, 80);
            btnCarregarCSV.Anchor = AnchorStyles.Right;
            btnCarregarCSV.Text = "Carregar CSV - Usuários Comunidade Acadêmica";
            btnCarregarCSV.Click += OnClickCarregarCSV;

            #endregion

            painelAtendente.Controls.Add(bntVisualizarAlunos);
            painelAtendente.Controls.Add(bntVisualizarProfessores);
            painelAtendente.Controls.Add(btnCarregarCSV);

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

        private void OnClickCarregarCSV(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos CSV|*.csv|Todos os Arquivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivoCSV = openFileDialog.FileName;

                string diretorioDoAplicativo = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Data");

                string caminhoArquivoTxt = Path.Combine(diretorioDoAplicativo, "ComunidadeAcademica.txt");

                _telaPrincipalController.CarregarCSV(caminhoArquivoCSV, caminhoArquivoTxt);

            }
        }
        #endregion

        #endregion


        #region Lógica Painel Bibliotecário
        private Panel CriarPainelBibliotecario(Panel painelBibliotecario)
        {
            painelBibliotecario.Controls.Clear();

            return painelBibliotecario;
        }
        #endregion


        #region Lógica Painel Diretor
        private Panel CriarPainelDiretor(Panel painelDiretor)
        {
            painelDiretor.Controls.Clear();
            Button bntVisualizarReservas = new Button();
            
            bntVisualizarReservas.Size = new Size(150, 20);
            bntVisualizarReservas.Location = new Point(20, 50);
            bntVisualizarReservas.Anchor = AnchorStyles.Right;
            bntVisualizarReservas.Text = "Visualizar Reservas";
            bntVisualizarReservas.Click += OnClickVisualizarReservas;

            painelDiretor.Controls.Add(bntVisualizarReservas);
            return painelDiretor;
        }

        private void OnClickVisualizarReservas(object sender, EventArgs e)
        {
            JanelaVisualizarReservas janelaVisualizarReservas = new JanelaVisualizarReservas();
            janelaVisualizarReservas.ExibirReservasLivro((ComunidadeAcademica)_usuarioLogado);
        }
        #endregion


        #region Lógica Painel Comunidade Acadêmica
        private Panel CriarPainelComunidadeAcademica(Panel painelComunidadeAcademica)
        {
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
