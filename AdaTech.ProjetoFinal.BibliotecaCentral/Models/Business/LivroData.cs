using AdaTech.ProjetoFinal.BibliotecaCentral.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    [Serializable]
    public static class LivroData
    {
        private static List<Livro> _acervoLivros = new List<Livro>();
        private static string FILE_PATH = "LivroData.bin";

        // Esse construtor estatico vai carregar os objetos do arquivo binario na lista _acervoLivros sempre que o programa compilar    
        static LivroData()
        {
            _acervoLivros = Data.LoadData<Livro>(FILE_PATH);
        }

        
        // Esse método é mais pra gente visualizar se as modificacoes estao salvando ou nao, depois podemos apagar
        internal static void imprimirLivros()
        {
            if( _acervoLivros.Count == 0) { Console.WriteLine("LISTA VAZIA");  }
            foreach(var livro in _acervoLivros)
            {
                Console.WriteLine(livro.Titulo);
            }
        }

        internal static void IncluirLivros(List<Livro> livros)
        {
            _acervoLivros.AddRange(livros);
            Data.SaveData(FILE_PATH, _acervoLivros); // SALVANDO A MODIFICACAO NO BINARIO
        }

        internal static void IncluirLivro(string titulo, string autor, string isbn, int anoPublicacao, int edicao, string editora, 
            int exemplares, TipoAcervoLivro tipoAcervoLivro)
        {
            _acervoLivros.Add(new Livro(titulo, autor, isbn, anoPublicacao, edicao, editora, exemplares, tipoAcervoLivro));
            Data.SaveData(FILE_PATH, _acervoLivros); // SALVANDO A MODIFICACAO NO BINARIO
        }

        internal static void AtualizarLivros(List<Livro> livrosAtualizados)
        {
            foreach (var livroAtualizado in livrosAtualizados)
            {
               AtualizarLivro(livroAtualizado);
            }

        }

        internal static void AtualizarLivro(Livro livroAtualizado)
        {
            var livroExistente = _acervoLivros.Find(livro => livro.Equals(livroAtualizado));

            if (livroExistente != null)
            {
                int index = _acervoLivros.IndexOf(livroExistente);
                _acervoLivros[index] = livroAtualizado;
                Data.SaveData(FILE_PATH, _acervoLivros); // SALVANDO A MODIFICACAO NO BINARIO
            }
        }

        internal static List<Livro> ListarLivros(TipoAcervoLivro? tipoAcervoLivro)
        {
            List<Livro> livrosAcervo = _acervoLivros.Where(l => l.tipoAcervoLivro == tipoAcervoLivro).ToList();
            return livrosAcervo;
        }

        internal static void ExcluirLivros(List<Livro> livrosSelecionados)
        {
            _acervoLivros.RemoveAll(livro => livrosSelecionados.Contains(livro));
            Data.SaveData(FILE_PATH, _acervoLivros); // SALVANDO A MODIFICACAO NO BINARIO
        }

        internal static Livro SelecionarLivro(string isbn)
        {
            return _acervoLivros.Where(l => l.Isbn == isbn).FirstOrDefault();
        }
    }
}