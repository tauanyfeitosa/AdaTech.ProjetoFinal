using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelAtendenteController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    public partial class JanelaDevolucao : Form
    {
        internal JanelaDevolucao(Usuario usuario)
        {
            this._atendenteLogin = UsuarioData.SelecionarAtendente(usuario.Login);

            InitializeComponent();

            btnProcurar.Click += (sender, e) => ProcurarButtonClick?.Invoke(sender, e);

            btnCancelar.Click += (sender, e) => CancelarButtonClick?.Invoke(sender, e);

            btnDevolver.Click += (sender, e) => DevolverButtonClick?.Invoke(sender, e);

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
