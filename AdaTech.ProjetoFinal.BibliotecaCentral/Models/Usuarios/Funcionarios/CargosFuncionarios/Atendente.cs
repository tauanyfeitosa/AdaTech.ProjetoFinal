
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
        //private Emprestimo VerificarEmprestimo(Reserva reserva, ComunidadeAcademica comunidadeAcademica, Livro livro)
        //{

        //}
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
