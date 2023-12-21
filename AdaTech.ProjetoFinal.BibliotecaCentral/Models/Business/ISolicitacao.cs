
namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business
{
    internal interface ISolicitacao
    {
        void AprovarSolicitacao(Diretor diretor);
        void AlterarSolicitacao(Livro livro, TipoAcervo tipoAcervo, string descricao);
        void ReprovarSolicitacao(Diretor diretor);
    }
}
