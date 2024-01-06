using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers
{
    public class VisualizarEmprestimosController
    {
        private JanelaVisualizarEmprestimos form;

        public VisualizarEmprestimosController(JanelaVisualizarEmprestimos form)
        {
            this.form = form;
            form.Load += (sender, e) => ExibirEmprestimos();
        }

        public void ExibirEmprestimos()
        {
            List<Emprestimo> emprestimos = EmprestimoData.EmprestimoLivros;

            foreach (Emprestimo emprestimo in emprestimos)
            {
                string infoEmprestimo = emprestimo.DataDevolucaoUsuario != DateTime.MinValue
                    ? $"Livro: {emprestimo.Livro.Titulo} - Data Empréstimo: {emprestimo.DataEmprestimo.ToShortDateString()} - Data Devolução: {emprestimo.DataDevolucaoUsuario.ToShortDateString()} - Id Emprestimo: {emprestimo.IdEmprestimo}"
                    : $"Livro: {emprestimo.Livro.Titulo} - Data Empréstimo: {emprestimo.DataEmprestimo.ToShortDateString()} - Data Devolução Prevista: {emprestimo.DataDevolucaoPrevista.ToShortDateString()} - Id Emprestimo: {emprestimo.IdEmprestimo}";

                form.AdicionarEmprestimoNaListBox(infoEmprestimo);
            }
        }
    }
}
