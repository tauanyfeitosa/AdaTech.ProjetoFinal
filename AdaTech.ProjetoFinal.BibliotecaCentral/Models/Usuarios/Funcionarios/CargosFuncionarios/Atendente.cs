
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
using System;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal class Atendente: Funcionario
    {
        private EmprestimoData _emprestimoData;
        private ReservaLivro _reservaParaEmprestimo;

        internal ReservaLivro ReservaLivro { get => _reservaParaEmprestimo; }
        internal EmprestimoData EmprestimoData { get => _emprestimoData; }
        internal Atendente(string senha, string nomeCompleto, string cpf, string email, bool ativo = true)
            : base(senha, nomeCompleto, cpf, email, ativo)
        {

        }
        private void VerificarEmprestimo(ComunidadeAcademica comunidadeAcademica, Livro livro, ReservaLivro reserva = null)
        {
            try
            {
                
                if(livro.ExemplaresDisponiveis >= 1 && _emprestimoData.SelecionarEmprestimo(comunidadeAcademica).Count < 3)
                {
                    foreach (Emprestimo emprestimos in _emprestimoData.SelecionarEmprestimo(comunidadeAcademica))
                    {
                        if(emprestimos.Multa.PagamentoMulta == false)
                        {
                            return;
                        }
                    }

                    if (reserva == null)
                    {
                        Emprestimo emprestimo = new Emprestimo(comunidadeAcademica, livro);
                    }
                    else
                    {
                        if(reserva.DataRetirarLivro == DateTime.Now && reserva.StatusReserva == StatusReserva.Aprovada)
                        {
                            Emprestimo emprestimo = new Emprestimo(comunidadeAcademica, livro, reserva);
                        }
                    }
                }
                //Verificar Reserva = null -> Disponibilidade Livro -> Quantidade de emprestimo por usuario (3) -> Verificar Multa nos emprestimos -> Criar Emprestimo;
                //Reserva != null -> verificar se a reserva é pra hoje e foi aprovada -> Criar emprestimo
                //--> Lembrar de diminuir 1 no exemplar disponível
            }
            catch(Exception ex)
            {
                Console.WriteLine("Emprestimo não realizado");
            }
        }
        private void ConfirmarDevolucao(Emprestimo emprestimo, string estadoLivro)
        {
            emprestimo.DevolverLivro(estadoLivro);

        }
        //private void AtualizarComunidadeAcademica()
        //{

        //}
        //private void CadastrarComunidadeAcademica()
        //{

        //}
    }
}
