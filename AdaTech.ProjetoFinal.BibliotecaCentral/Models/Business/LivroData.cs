using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal static class LivroData
    {
        private static List<Livro> acervoLivros;

        internal static void LerBinLivros()
        {
        }

        internal static void AtualizarLivros(List<Livro> livros)
        {

        }

        internal static List<Livro> ListarLivros(TipoAcervoLivro? tipoAcervoLivro)
        {
            List<Livro> livrosAcervo = acervoLivros.Where(l => l.tipoAcervoLivro == tipoAcervoLivro).ToList();
            return livrosAcervo;
        }

        internal static void ExcluirLivros(string[] isbnLivros)
        {

        }

        internal static Livro SelecionarLivro(string isbn)
        {
            return new Livro();
        }
    }
}