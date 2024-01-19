﻿using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelComunidadeController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasCA
{
    public partial class JanelaRenovarLivro : Form
    {

        internal JanelaRenovarLivro(Usuario usuario)
        {
            this._comunidadeAcademicaLogin = UsuarioData.SelecionarComunidadeAcademica(usuario.Login);

            InitializeComponent();

            btnRenovar.Click += (sender, e) => btnRenovarClick?.Invoke(sender, e);
            btnSair.Click += (sender, e) => btnSairClick?.Invoke(sender, e);

            RenovarLivroController controller = new RenovarLivroController(this, _comunidadeAcademicaLogin);

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
                    texto = $"Livro: {lista[0].Livro.Titulo} - Data Empréstimo: {lista[0].DataEmprestimo} - Data Devolução: {lista[0].DataDevolucaoPrevista}";
                    checkBox1.Text = $"{texto}";
                    checkBox2.Text = " ";
                    checkBox3.Text = " ";
                    checkBox4.Text = " ";
                    checkBox5.Text = " ";
                    break;
                case 2:
                    texto = $"Livro: {lista[0].Livro.Titulo} - Data Empréstimo: {lista[0].DataEmprestimo} - Data Devolução: {lista[0].DataDevolucaoPrevista}";
                    checkBox1.Text = $"{texto}";
                    texto = $"Livro: {lista[1].Livro.Titulo} - Data Empréstimo: {lista[1].DataEmprestimo} - Data Devolução: {lista[1].DataDevolucaoPrevista}";
                    checkBox2.Text = $"{texto}";
                    checkBox3.Text = " ";
                    checkBox4.Text = " ";
                    checkBox5.Text = " ";
                    break;
                case 3:
                    texto = $"Livro: {lista[0].Livro.Titulo} - Data Empréstimo: {lista[0].DataEmprestimo} - Data Devolução: {lista[0].DataDevolucaoPrevista}";
                    checkBox1.Text = $"{texto}";
                    texto = $"Livro: {lista[1].Livro.Titulo} - Data Empréstimo: {lista[1].DataEmprestimo} - Data Devolução: {lista[1].DataDevolucaoPrevista}";
                    checkBox2.Text = $"{texto}";
                    texto = $"Livro: {lista[2].Livro.Titulo} - Data Empréstimo: {lista[2].DataEmprestimo} - Data Devolução: {lista[2].DataDevolucaoPrevista}";
                    checkBox3.Text = $"{texto}";
                    checkBox4.Text = " ";
                    checkBox5.Text = " ";
                    break;
                case 4:
                    texto = $"Livro: {lista[0].Livro.Titulo} - Data Empréstimo: {lista[0].DataEmprestimo} - Data Devolução: {lista[0].DataDevolucaoPrevista}";
                    checkBox1.Text = $"{texto}";
                    texto = $"Livro: {lista[1].Livro.Titulo} - Data Empréstimo: {lista[1].DataEmprestimo} - Data Devolução: {lista[1].DataDevolucaoPrevista}";
                    checkBox2.Text = $"{texto}";
                    texto = $"Livro: {lista[2].Livro.Titulo} - Data Empréstimo: {lista[2].DataEmprestimo} - Data Devolução: {lista[2].DataDevolucaoPrevista}";
                    checkBox3.Text = $"{texto}";
                    texto = $"Livro: {lista[3].Livro.Titulo} - Data Empréstimo: {lista[3].DataEmprestimo} - Data Devolução: {lista[3].DataDevolucaoPrevista}";
                    checkBox4.Text = $"{texto}";
                    checkBox5.Text = " ";
                    break;
                case 5:
                    texto = $"Livro: {lista[0].Livro.Titulo} - Data Empréstimo: {lista[0].DataEmprestimo} - Data Devolução: {lista[0].DataDevolucaoPrevista}";
                    checkBox1.Text = $"{texto}";
                    texto = $"Livro: {lista[1].Livro.Titulo} - Data Empréstimo: {lista[1].DataEmprestimo} - Data Devolução: {lista[1].DataDevolucaoPrevista}";
                    checkBox2.Text = $"{texto}";
                    texto = $"Livro: {lista[2].Livro.Titulo} - Data Empréstimo: {lista[2].DataEmprestimo} - Data Devolução: {lista[2].DataDevolucaoPrevista}";
                    checkBox3.Text = $"{texto}";
                    texto = $"Livro: {lista[3].Livro.Titulo} - Data Empréstimo: {lista[3].DataEmprestimo} - Data Devolução: {lista[3].DataDevolucaoPrevista}";
                    checkBox4.Text = $"{texto}";
                    texto = $"Livro: {lista[4].Livro.Titulo} - Data Empréstimo: {lista[4].DataEmprestimo} - Data Devolução: {lista[4].DataDevolucaoPrevista}";
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
