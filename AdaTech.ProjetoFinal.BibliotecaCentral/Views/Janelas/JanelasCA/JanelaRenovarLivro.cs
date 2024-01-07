using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelComunidadeController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
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
    public partial class JanelaRenovarLivro : Form
    {

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Button btnPagar;
        private Button btnSair;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;

        public event EventHandler btnSairClick;
        public event EventHandler btnPagarClick;

        private ComunidadeAcademica _comunidadeAcademicaLogin;
        private List<int> _caixas = new List<int> { 0, 0, 0, 0, 0 };

        internal List<int> Caixas { get { return _caixas; } }
        internal ComunidadeAcademica ComunidadeAcademicaLogin
        {
            get { return _comunidadeAcademicaLogin; }
            set { _comunidadeAcademicaLogin = value; }
        }

        internal JanelaRenovarLivro(Usuario usuario)
        {
            this._comunidadeAcademicaLogin = UsuarioData.SelecionarComunidadeAcademica(usuario.Login);

            InitializeComponent();
            InicializarComponetes();
            RenovarLivroController controller = new RenovarLivroController(this, _comunidadeAcademicaLogin);

            controller.SepararMultas();

            checkBox1.CheckedChanged += CheckBoxChecked1;
            checkBox2.CheckedChanged += CheckBoxChecked2;
            checkBox3.CheckedChanged += CheckBoxChecked3;
            checkBox4.CheckedChanged += CheckBoxChecked4;
            checkBox5.CheckedChanged += CheckBoxChecked5;
        }
        private void InicializarComponetes()
        {
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            btnPagar = new Button();
            btnSair = new Button();
            SuspendLayout();

            #region Botão Pagar
            btnPagar = new Button();
            btnPagar.Location = new Point(387, 370);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(75, 23);
            btnPagar.TabIndex = 1;
            btnPagar.Text = "Pagar";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += (sender, e) => btnPagarClick?.Invoke(sender, e);
            #endregion

            #region Botão Sair
            btnSair = new Button();
            btnSair.Location = new Point(277, 370);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(75, 23);
            btnSair.TabIndex = 2;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += (sender, e) => btnSairClick?.Invoke(sender, e);
            #endregion

            #region CheckBox1
            checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(64, 145);
            this.checkBox1.Size = new System.Drawing.Size(113, 24);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.UseVisualStyleBackColor = true;
            #endregion

            #region CheckBox2
            checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(64, 185);
            this.checkBox2.Size = new System.Drawing.Size(113, 24);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.UseVisualStyleBackColor = true;
            #endregion

            #region CheckBox3
            checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(64, 225);
            this.checkBox3.Size = new System.Drawing.Size(113, 24);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.UseVisualStyleBackColor = true;
            #endregion

            #region CheckBox4
            checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(64, 265);
            this.checkBox4.Size = new System.Drawing.Size(113, 24);
            this.checkBox4.TabIndex = 6;
            this.checkBox4.UseVisualStyleBackColor = true;
            #endregion

            #region CheckBox5
            checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(64, 305);
            this.checkBox5.Size = new System.Drawing.Size(113, 24);
            this.checkBox5.TabIndex = 7;
            this.checkBox5.UseVisualStyleBackColor = true;
            #endregion

            #region TituloPagamento
            label1 = new System.Windows.Forms.Label();
            label1.AutoSize = true;
            label1.Location = new Point(330, 36);
            label1.Name = "label1";
            label1.Size = new Size(78, 13);
            label1.TabIndex = 8;
            label1.Text = "Renovação de Livro";
            #endregion

            #region TituloEscolha
            label2 = new System.Windows.Forms.Label();
            label2.AutoSize = true;
            label2.Location = new Point(290, 76);
            label2.Name = "label2";
            label2.Size = new Size(68, 13);
            label2.TabIndex = 9;
            label2.Text = "Selecione qual livro deseja renovar";
            #endregion

            Controls.Add(btnSair);
            Controls.Add(btnPagar);
            Controls.Add(checkBox1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox3);
            Controls.Add(checkBox4);
            Controls.Add(checkBox5);
            Controls.Add(label1);
            Controls.Add(label2);

            Text = "Pagamento Multas";
            ResumeLayout(false);
            PerformLayout();
        }
        public void MostrarMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }
        internal void ExibeRegistros(List<Emprestimo> lista)
        {
            string texto;

            switch (lista.Count)
            {
                case 1:
                    texto = $"Livro: {lista[0].Livro.Titulo} - Data Devolução: {lista[0].DataDevolucaoUsuario} - Multa Total: R${lista[0].Multa.MultaTotal}";
                    checkBox1.Text = $"{texto}";
                    checkBox2.Text = " ";
                    checkBox3.Text = " ";
                    checkBox4.Text = " ";
                    checkBox5.Text = " ";
                    break;
                case 2:
                    texto = $"Livro: {lista[0].Livro.Titulo} - Data Devolução: {lista[0].DataDevolucaoUsuario} - Multa Total: R${lista[0].Multa.MultaTotal}";
                    checkBox1.Text = $"{texto}";
                    texto = $"Livro: {lista[1].Livro.Titulo} - Data Devolução: {lista[1].DataDevolucaoUsuario} - Multa Total: R${lista[1].Multa.MultaTotal}";
                    checkBox2.Text = $"{texto}";
                    checkBox3.Text = " ";
                    checkBox4.Text = " ";
                    checkBox5.Text = " ";
                    break;
                case 3:
                    texto = $"Livro: {lista[0].Livro.Titulo} - Data Devolução: {lista[0].DataDevolucaoUsuario} - Multa Total: R${lista[0].Multa.MultaTotal}";
                    checkBox1.Text = $"{texto}";
                    texto = $"Livro: {lista[1].Livro.Titulo} - Data Devolução: {lista[1].DataDevolucaoUsuario} - Multa Total: R${lista[1].Multa.MultaTotal}";
                    checkBox2.Text = $"{texto}";
                    texto = $"Livro: {lista[2].Livro.Titulo} - Data Devolução: {lista[2].DataDevolucaoUsuario} - Multa Total: R${lista[2].Multa.MultaTotal}";
                    checkBox3.Text = $"{texto}";
                    checkBox4.Text = " ";
                    checkBox5.Text = " ";
                    break;
                case 4:
                    texto = $"Livro: {lista[0].Livro.Titulo} - Data Devolução: {lista[0].DataDevolucaoUsuario} - Multa Total: R${lista[0].Multa.MultaTotal}";
                    checkBox1.Text = $"{texto}";
                    texto = $"Livro: {lista[1].Livro.Titulo} - Data Devolução: {lista[1].DataDevolucaoUsuario} - Multa Total: R${lista[1].Multa.MultaTotal}";
                    checkBox2.Text = $"{texto}";
                    texto = $"Livro: {lista[2].Livro.Titulo} - Data Devolução: {lista[2].DataDevolucaoUsuario} - Multa Total: R${lista[2].Multa.MultaTotal}";
                    checkBox3.Text = $"{texto}";
                    texto = $"Livro: {lista[3].Livro.Titulo} - Data Devolução: {lista[3].DataDevolucaoUsuario} - Multa Total: R${lista[3].Multa.MultaTotal}";
                    checkBox4.Text = $"{texto}";
                    checkBox5.Text = " ";
                    break;
                case 5:
                    texto = $"Livro: {lista[0].Livro.Titulo} - Data Devolução: {lista[0].DataDevolucaoUsuario} - Multa Total: R${lista[0].Multa.MultaTotal}";
                    checkBox1.Text = $"{texto}";
                    texto = $"Livro: {lista[1].Livro.Titulo} - Data Devolução: {lista[1].DataDevolucaoUsuario} - Multa Total: R${lista[1].Multa.MultaTotal}";
                    checkBox2.Text = $"{texto}";
                    texto = $"Livro: {lista[2].Livro.Titulo} - Data Devolução: {lista[2].DataDevolucaoUsuario} - Multa Total: R${lista[2].Multa.MultaTotal}";
                    checkBox3.Text = $"{texto}";
                    texto = $"Livro: {lista[3].Livro.Titulo} - Data Devolução: {lista[3].DataDevolucaoUsuario} - Multa Total: R${lista[3].Multa.MultaTotal}";
                    checkBox4.Text = $"{texto}";
                    texto = $"Livro: {lista[4].Livro.Titulo} - Data Devolução: {lista[4].DataDevolucaoUsuario} - Multa Total: R${lista[4].Multa.MultaTotal}";
                    checkBox5.Text = $"{texto}";
                    break;
                default:
                    checkBox1.Text = "SEM EMPRÉSTIMOS";
                    checkBox2.Text = "SEM EMPRÉSTIMOS";
                    checkBox3.Text = "SEM EMPRÉSTIMOS";
                    checkBox4.Text = "SEM EMPRÉSTIMOS";
                    checkBox5.Text = "SEM EMPRÉSTIMOS";
                    break;
            }

        }
        private void CheckBoxChecked1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                _caixas[0] = 1;
            }
            else
            {
                _caixas[0] = 0;
            }
        }
        private void CheckBoxChecked2(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                _caixas[1] = 1;
            }
            else
            {
                _caixas[1] = 0;
            }
        }
        private void CheckBoxChecked3(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                _caixas[2] = 1;
            }
            else
            {
                _caixas[2] = 0;
            }
        }
        private void CheckBoxChecked4(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                _caixas[3] = 1;
            }
            else
            {
                _caixas[3] = 0;
            }
        }
        private void CheckBoxChecked5(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                _caixas[4] = 1;
            }
            else
            {
                _caixas[4] = 0;
            }
        }
    }
}
