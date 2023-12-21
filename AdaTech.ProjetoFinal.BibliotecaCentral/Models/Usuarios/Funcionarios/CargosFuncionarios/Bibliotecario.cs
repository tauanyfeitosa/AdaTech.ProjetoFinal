
namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal class Bibliotecario: Funcionario
    {
        internal Bibliotecario (string login, string senha, string nomeCompleto, string cpf, string email, bool ativo)
                       : base(login, senha, nomeCompleto, cpf, email, ativo)
        {

        }

        //private Livro CadastrarLivro(string titulo, string autor, string isbn, int anoPublicacao, int edicao, string editora, int exemplares)
        //{

        //}
        //private Livro CadastraLivro()
        //{

        //}
        //private void AtualizarLivro(Livro livro)
        //{

        //}
        //private SolicitacaoMudarAcervoLivros MudarAcervo(Livro livro, TipoAcervo tipoAcervo, string descricao)
        //{

        //}
        //private SolicitacaoRequisicaoLivros SolicitarLivrosNovos(File csv)
        //{

        //}
    }
}
