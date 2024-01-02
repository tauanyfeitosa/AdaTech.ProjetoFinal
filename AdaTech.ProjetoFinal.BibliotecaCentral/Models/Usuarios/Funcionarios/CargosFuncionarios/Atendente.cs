
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal class Atendente: Funcionario
    {
        internal Atendente(string senha, string nomeCompleto, string cpf, string email, bool ativo = true)
            : base(senha, nomeCompleto, cpf, email, ativo)
        {

        }

        private void AprovarEmprestimo(ReservaLivro reservaLivro)
        {
            var emprestimo = new Emprestimo(reservaLivro);
            var lista = new List<Emprestimo> { emprestimo };

            //EmprestimoData.SalvarEmprestimoTxt(lista);
        }
        private void AprovarEmprestimo(ComunidadeAcademica comunidadeAcademica, Livro livro)
        {
            var emprestimo = new Emprestimo(null, livro, comunidadeAcademica);
            var lista = new List<Emprestimo> { emprestimo };

            //EmprestimoData.SalvarEmprestimoTxt(lista);
        }
        internal void VerificarEmprestimo(ComunidadeAcademica comunidadeAcademica, Livro livro, ReservaLivro reserva = null)
        {
            try
            {
               if (reserva == null)
                {
                    AprovarEmprestimo(comunidadeAcademica, livro);
                }
               else
                {
                    Emprestimo emprestimo = new Emprestimo(reserva);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Emprestimo não realizado");
            }
        }
        internal void ConfirmarDevolucao(Emprestimo emprestimo)
        {
            emprestimo.DevolverLivro();
        }
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
