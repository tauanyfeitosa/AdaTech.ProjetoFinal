using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;
using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelAtendenteController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosComunidadeAcademica;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    public partial class JanelaDevolucao : Form
    {
        private System.Windows.Forms.Label label1;
        private TextBox txtMatricula;
        private Button btnProcurar;
        private Button btnCancelar;
        private Button btnDevolver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoNegativo;
        private System.Windows.Forms.RadioButton rdoPositivo;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;

        public event EventHandler ProcurarButtonClick;
        public event EventHandler DevolverButtonClick;
        public event EventHandler CancelarButtonClick;

        private Atendente _atendenteLogin;
        private List<int> _caixas = new List<int> { 0, 0, 0, 0, 0 };
        private bool _estadoLivro;

        internal List<int> Caixas {  get { return _caixas; } }
        internal bool EstadoLivro
        {
            get { return _estadoLivro; }
            set { _estadoLivro = value;}
        }
        internal Atendente AtendenteLogin
        {
            get { return _atendenteLogin; }
            set { _atendenteLogin = value; }
        }
        internal JanelaDevolucao(Usuario usuario)
        {
            this._atendenteLogin = UsuarioData.SelecionarAtendente(usuario.Login);

            InitializeComponent();
            InicializarControles();
            _estadoLivro = false;
            checkBox1.CheckedChanged += CheckBoxChecked1;
            checkBox2.CheckedChanged += CheckBoxChecked2;
            checkBox3.CheckedChanged += CheckBoxChecked3;
            checkBox4.CheckedChanged += CheckBoxChecked4;
            checkBox5.CheckedChanged += CheckBoxChecked5;
            rdoNegativo.CheckedChanged += CheckNegativo;
            rdoPositivo.CheckedChanged += CheckPositivo;

            DevolucaoController controller = new DevolucaoController(this);
        }
        private void InicializarControles()
        {
            #region Divisão Matrícula

            label1 = new System.Windows.Forms.Label();
            label1.AutoSize = true;
            label1.Location = new Point(20, 36);
            label1.Name = "label1";
            label1.Size = new Size(38, 13);
            label1.TabIndex = 0;
            label1.Text = "Matrícula:";

            txtMatricula = new TextBox();
            txtMatricula.Location = new Point(74, 36);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(120, 20);
            txtMatricula.TabIndex = 1;
            #endregion

            #region Botão Pesquisar

            btnProcurar = new Button();
            btnProcurar.Location = new Point(230, 36);
            btnProcurar.Name = "btnProcurar";
            btnProcurar.Size = new Size(75, 23);
            btnProcurar.TabIndex = 2;
            btnProcurar.Text = "Pesquisar";
            btnProcurar.UseVisualStyleBackColor = true;
            btnProcurar.Click += (sender, e) => ProcurarButtonClick?.Invoke(sender, e);
            #endregion

            #region Botão Cancelar

            btnCancelar = new Button();
            btnCancelar.Location = new Point(387, 140);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += (sender, e) => CancelarButtonClick?.Invoke(sender, e);
            #endregion

            #region Botão Devolver

            btnDevolver = new Button();
            btnDevolver.Location = new Point(387, 85);
            btnDevolver.Name = "btnDevolver";
            btnDevolver.Size = new Size(75, 23);
            btnDevolver.TabIndex = 2;
            btnDevolver.Text = "Devolver";
            btnDevolver.UseVisualStyleBackColor = true;
            btnDevolver.Click += (sender, e) => DevolverButtonClick?.Invoke(sender, e);
            #endregion

            #region Caixa Seleção Mau Estado

            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox1.Location = new Point(18, 90);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(292, 67);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Livro Mau Estado";

            rdoNegativo = new System.Windows.Forms.RadioButton();
            rdoNegativo.AutoSize = true;
            rdoNegativo.Checked = true;
            rdoNegativo.Location = new Point(102, 33);
            rdoNegativo.Name = "rdoNegativo";
            rdoNegativo.Size = new Size(73, 17);
            rdoNegativo.TabIndex = 9;
            rdoNegativo.TabStop = true;
            rdoNegativo.Text = "Não";
            rdoNegativo.UseVisualStyleBackColor = true;

            rdoPositivo = new System.Windows.Forms.RadioButton();
            rdoPositivo.AutoSize = true;
            rdoPositivo.Location = new Point(14, 33);
            rdoPositivo.Name = "rdoPositivo";
            rdoPositivo.Size = new Size(67, 17);
            rdoPositivo.TabIndex = 9;
            rdoPositivo.Text = "Sim";
            rdoPositivo.UseVisualStyleBackColor = true;

            groupBox1.Controls.Add(rdoNegativo);
            groupBox1.Controls.Add(rdoPositivo);
            groupBox1.SuspendLayout();
            #endregion

            #region CheckBox1
            checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(64, 204);
            this.checkBox1.Size = new System.Drawing.Size(113, 24);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.UseVisualStyleBackColor = true;
            #endregion

            #region CheckBox2
            checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(64, 244);
            this.checkBox2.Size = new System.Drawing.Size(113, 24);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.UseVisualStyleBackColor = true;
            #endregion

            #region CheckBox3
            checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(64, 284);
            this.checkBox3.Size = new System.Drawing.Size(113, 24);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.UseVisualStyleBackColor = true;
            #endregion

            #region CheckBox4
            checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(64, 324);
            this.checkBox4.Size = new System.Drawing.Size(113, 24);
            this.checkBox4.TabIndex = 13;
            this.checkBox4.UseVisualStyleBackColor = true;
            #endregion

            #region CheckBox5
            checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(64, 364);
            this.checkBox5.Size = new System.Drawing.Size(113, 24);
            this.checkBox5.TabIndex = 14;
            this.checkBox5.UseVisualStyleBackColor = true;
            #endregion

            Controls.Add(groupBox1);
            Controls.Add(btnProcurar);
            Controls.Add(btnCancelar);
            Controls.Add(btnDevolver);
            Controls.Add(txtMatricula);
            Controls.Add(checkBox1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox3);
            Controls.Add(checkBox4);
            Controls.Add(checkBox5);
            Controls.Add(label1);

            Text = "Devolução";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        internal void LimparFormulario()
        {
            txtMatricula.Clear();
            rdoNegativo.Checked = true;

            txtMatricula.Focus();
        }
        public void MostrarMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }
        internal string NumeroMatricula()
        {
            return txtMatricula.Text;
        }
        internal void ExibeRegistros(List<Emprestimo> lista)
        {
            string texto;

            switch (lista.Count)
            {
                case 1:
                    texto = lista[0].CheckBoxTexto();
                    checkBox1.Text = $"{texto}"; 
                    checkBox2.Text = " ";
                    checkBox3.Text = " ";
                    checkBox4.Text = " ";
                    checkBox5.Text = " ";
                    break;
                case 2:
                    texto = lista[0].CheckBoxTexto();
                    checkBox1.Text = $"{texto}";
                    texto = lista[1].CheckBoxTexto();
                    checkBox2.Text = $"{texto}";
                    checkBox3.Text = " ";
                    checkBox4.Text = " ";
                    checkBox5.Text = " ";
                    break;
                case 3:
                    texto = lista[0].CheckBoxTexto();
                    checkBox1.Text = $"{texto}";
                    texto = lista[1].CheckBoxTexto();
                    checkBox2.Text = $"{texto}";
                    texto = lista[2].CheckBoxTexto();
                    checkBox3.Text = $"{texto}";
                    checkBox4.Text = " ";
                    checkBox5.Text = " ";
                    break;
                case 4:
                    texto = lista[0].CheckBoxTexto();
                    checkBox1.Text = $"{texto}";
                    texto = lista[1].CheckBoxTexto();
                    checkBox2.Text = $"{texto}";
                    texto = lista[2].CheckBoxTexto();
                    checkBox3.Text = $"{texto}";
                    texto = lista[3].CheckBoxTexto();
                    checkBox4.Text = $"{texto}";
                    checkBox5.Text = " ";
                    break;
                case 5:
                    texto = lista[0].CheckBoxTexto();
                    checkBox1.Text = $"{texto}";
                    texto = lista[1].CheckBoxTexto();
                    checkBox2.Text = $"{texto}";
                    texto = lista[2].CheckBoxTexto();
                    checkBox3.Text = $"{texto}";
                    texto = lista[3].CheckBoxTexto();
                    checkBox4.Text = $"{texto}";
                    texto = lista[4].CheckBoxTexto();
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
        private void CheckNegativo(object sender, EventArgs e)
        {
            _estadoLivro = false; 
        }
        private void CheckPositivo(object sender, EventArgs e)
        {
            _estadoLivro = true;
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
