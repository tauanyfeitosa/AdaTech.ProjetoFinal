
using System.Collections.Generic;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes
{
    internal interface ISolicitacao
    {
        void AprovarSolicitacao(Diretor diretor);
        void AlterarSolicitacao(Bibliotecario bibliotecario = null, Livro livro = null, TipoAcervoLivro tipoAcervo = TipoAcervoLivro.Inativo, string descricao = "");
        void ReprovarSolicitacao(Diretor diretor);
    }
}
