
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using System.Collections.Generic;
using System.Linq;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal class Atendente: Funcionario
    {
        internal Atendente(string senha, string nomeCompleto, string cpf, string email, bool ativo = true)
            : base(senha, nomeCompleto, cpf, email, ativo)
        {

        }

        //private void AprovarEmprestimo(ReservaLivro reservaLivro)
        //{

        //}
        //private void AprovarEmprestimo(ComunidadeAcademica comunidadeAcademica, Livro livro)
        //{

        //}
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
                            Console.WriteLine("Emprestimo confirmado");
                        }
                        else
                        {
                            if(reserva.DataRetirarLivro == DateTime.Now && reserva.StatusReserva == StatusReserva.Aprovada)
                            {
                                Emprestimo emprestimo = new Emprestimo(comunidadeAcademica, livro, reserva);
                                Console.WriteLine("Emprestimo confirmado");
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
        //private void ConfirmarDevolucao(Emprestimo emprestimo)
        //{

        //}
        private void CadastrarComunidadeAcademica(List<ComunidadeAcademica> novaListaCA)
        {

            HashSet<ComunidadeAcademica> conjuntoUnico = new HashSet<ComunidadeAcademica>();

            foreach (var item in UsuarioData.ComunidadeAcademica)
            {
                conjuntoUnico.Add(item);
            }

            foreach (var item in novaListaCA)
            {
                conjuntoUnico.Add(item);
            }

            List<ComunidadeAcademica> listaTotalCA = new List<ComunidadeAcademica>(conjuntoUnico);

            UsuarioData.SalvarComunidadeAcademicaTxt(listaTotalCA);

        }

    }
}
