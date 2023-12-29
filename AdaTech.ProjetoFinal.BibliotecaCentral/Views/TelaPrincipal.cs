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

            SelecionarInterface(_telaPrincipalController.FiltrarLogin(), InitializeTela(larguraTela, alturaTela));
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

            Controls.Add(_lblBemVindo);

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

            painelAtendente.Controls.Add(bntVisualizarAlunos);
            painelAtendente.Controls.Add(bntVisualizarProfessores);

            return painelAtendente;
        }


        #region OnClick de Atendente
        private void OnClickVisualizarAlunos(object sender, EventArgs e)
        {

        }

        private void OnClickVisualizarProfessores(object sender, EventArgs e)
        {

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

            return painelDiretor;
        }
        #endregion


        #region Lógica Painel Comunidade Acadêmica
        private Panel CriarPainelComunidadeAcademica(Panel painelComunidadeAcademica)
        {
            painelComunidadeAcademica.Controls.Clear();

            return painelComunidadeAcademica;
        } 
        #endregion
    }
}
