using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelComunidadeController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasCA
{
    public partial class JanelaMultasUsuario : Form
    {
        internal JanelaMultasUsuario(Usuario usuario)
        {
            this._comunidadeAcademicaLogin = UsuarioData.SelecionarComunidadeAcademica(usuario.Login);

            InitializeComponent();

            btnPagar.Click += (sender, e) => btnPagarClick?.Invoke(sender, e);
            btnSair.Click += (sender, e) => btnSairClick?.Invoke(sender, e);
            MultasUsuarioController controller = new MultasUsuarioController(this, _comunidadeAcademicaLogin);

            controller.SepararMultas();

            checkBox1.CheckedChanged += CheckBoxChecked1;
            checkBox2.CheckedChanged += CheckBoxChecked2;
            checkBox3.CheckedChanged += CheckBoxChecked3;
            checkBox4.CheckedChanged += CheckBoxChecked4;
            checkBox5.CheckedChanged += CheckBoxChecked5;
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
