using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos
{
    using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
    using Usuarios.UsuariosComunidadeAcademica;
    internal class EmprestimoData
    {
        private static List<Emprestimo> _emprestimoLivros = new List<Emprestimo>();

        internal List<Emprestimo> SelecionarEmprestimo(ComunidadeAcademica usuario)
        {
            throw new NotImplementedException();
        }
        //internal List<Emprestimo> SelecionarEmprestimo(Emprestimo emprestimos)
        //{

        //}
        internal static List<Emprestimo> ListarEmprestimos(DateTime dataRealizacaoEmprestimo)
        {
            List<Emprestimo> livrosEmprestimos = _emprestimoLivros.Where(l => l.DataEmprestimo == dataRealizacaoEmprestimo).ToList();
            return livrosEmprestimos;
        }

    }
}
