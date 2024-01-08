using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers
{
    internal class IniciarEmprestimoController
    {
        private JanelaIniciarEmprestimo form;

        public IniciarEmprestimoController(JanelaIniciarEmprestimo form)
        {
            this.form = form;
            form.CellClick += TabelaCellClick;
            form.CriarSemReservaButtonClick += CriarSemReservaButtonClick;
        }

        public void CarregarReservas()
        {
            List<ReservaLivro> reservas = ReservaLivroData.ListarReservasAprovadas(DateTime.Today);

            if (reservas.Count > 0)
            {
                form.AtualizarTabela(reservas);
            }
            else
            {
                form.MostrarMensagem("Não há reservas aprovadas para hoje.");
            }
        }

        public void TabelaCellClick(object sender, CellClickEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                ReservaLivro reserva = form.ObterReservaSelecionada(e.RowIndex);

                if (reserva != null)
                {
                    CriarEmprestimo(reserva);
                }
            }
        }

        public void CriarEmprestimo(ReservaLivro reserva)
        {
            List<Emprestimo> listaEmprestimos = EmprestimoData.SelecionarEmprestimo(reserva.UsuarioComunidadeAcademica);
            if(listaEmprestimos.Count < 5)
            {
                if (!VerificarReservaExemplar(reserva))
                {
                    Emprestimo emprestimo = new Emprestimo(reserva);
                    reserva.StatusReserva = StatusReserva.LivroRetirado;

                    try
                    {
                        EmprestimoData.CriarEmprestimo(emprestimo);
                        form.MostrarMensagem("Empréstimo criado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        form.MostrarMensagem(ex.Message);
                    }
                }
                else
                {
                    form.MostrarMensagem("Usuário já reservou um exemplar desse livro");
                }
            }
            else
            {
                MessageBox.Show("Usuário atingiu o limite máximo de empréstimos");
            }
        }
        public bool VerificarReservaExemplar(ReservaLivro reserva)
        {
            List<Emprestimo> listaEmprestimos = EmprestimoData.SelecionarEmprestimo(reserva.UsuarioComunidadeAcademica);
            foreach(Emprestimo emprestimo in listaEmprestimos)
            {
                if(reserva.Livro.Titulo == emprestimo.Livro.Titulo)
                {
                    return true;
                }
            }
            return false;
        }

        public void CriarSemReservaButtonClick(object sender, EventArgs e)
        {
            JanelaCriarEmprestimoSemReserva janela = new JanelaCriarEmprestimoSemReserva();
            janela.ShowDialog();
        }
    }
}
