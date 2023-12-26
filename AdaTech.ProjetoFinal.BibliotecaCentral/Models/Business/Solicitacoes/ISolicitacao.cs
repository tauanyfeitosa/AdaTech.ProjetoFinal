
using System.Collections.Generic;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business
{
    internal interface ISolicitacao
    {
        void AprovarSolicitacao(Diretor diretor);
        void AlterarSolicitacao(Bibliotecario bibliotecario = null, List<Livro> livro = null, TipoAcervoLivro tipoAcervo = TipoAcervoLivro.Inativo, string descricao = "");
        void ReprovarSolicitacao(Diretor diretor);
    }
}
