using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal class Bibliotecario: Funcionario
    {
        internal Bibliotecario (string login, string senha, string nomeCompleto, string cpf, string email, bool ativo)
                       : base(login, senha, nomeCompleto, cpf, email, ativo)
        {

        }

        private void CadastrarLivro(string titulo, string autor, string isbn, int anoPublicacao, int edicao, string editora, int exemplares)
        {
            LivroData.IncluirLivros(titulo, autor, isbn, anoPublicacao, edicao, editora, exemplares); 
        }

        //private Livro CadastraLivro()
        //{

        //}
        //private void AtualizarLivro(Livro livro)
        //{

        //}
        internal void CriarSolicitacao(TipoSolicitacao tipoSolicitacao, Livro livro, TipoAcervoLivro tipoAcervo, string descricao)
        {
              SolicitacoesData.CriarSolicitacao(tipoSolicitacao, livro, tipoAcervo, descricao, this);
        }
    }
}
