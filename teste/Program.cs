using System.Net;

namespace teste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LivroDataTeste.AddLivro(new Livro("A Revolução dos Bichos", "George Orwell", "9788578270262", 1945, 1, "Companhia das Letras", 70, 35, 20, 10, 5, TipoAcervoLivro.AcervoParticular));
            LivroDataTeste.imprimirLivros();
        }
    }
}
