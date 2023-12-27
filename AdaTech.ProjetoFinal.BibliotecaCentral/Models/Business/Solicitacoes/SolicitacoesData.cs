using System.Collections.Generic;
using System.Linq;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes
{
    internal static class SolicitacoesData
    {
        private static List<SolicitacaoMudarAcervoLivro> solicitacoesMudarAcervo = new List<SolicitacaoMudarAcervoLivro>();
        private static List<SolicitacaoRequisicaoLivros> solicitacaoRequisicaoLivros = new List<SolicitacaoRequisicaoLivros>();

        internal static void CriarSolicitacao(TipoSolicitacao solicitacao, Livro livro, TipoAcervoLivro tipoAcervo, string descricao, Bibliotecario bibliotecario)
        {
            if (solicitacao == TipoSolicitacao.MudarAcervoLivro)
                AdicionarSolicitacao(new SolicitacaoMudarAcervoLivro(livro, tipoAcervo, bibliotecario, descricao));
            else if (solicitacao == TipoSolicitacao.RequisicaoLivro)
                AdicionarSolicitacao(new SolicitacaoRequisicaoLivros(bibliotecario, livro, tipoAcervo, descricao));
        }

        internal static void AdicionarSolicitacao (ISolicitacao solicitacao)
        {
            if (solicitacao is SolicitacaoMudarAcervoLivro)
                solicitacoesMudarAcervo.Add(solicitacao as SolicitacaoMudarAcervoLivro);
            else if (solicitacao is SolicitacaoRequisicaoLivros)
                solicitacaoRequisicaoLivros.Add(solicitacao as SolicitacaoRequisicaoLivros);
        }

        internal static (List<SolicitacaoMudarAcervoLivro> solicitacoesAcervo, List<SolicitacaoRequisicaoLivros> solicitacoesRequisicao) SelecionarSolicitacoes(Bibliotecario bibliotecario)
        {
            List<SolicitacaoMudarAcervoLivro> solicitacoesMudarAcervoBibliotecario = solicitacoesMudarAcervo.Where(s => s.Bibliotecario == bibliotecario).ToList();
            List<SolicitacaoRequisicaoLivros> solicitacoesRequisicaoLivrosBibliotecario = solicitacaoRequisicaoLivros.Where(s => s.Bibliotecario == bibliotecario).ToList();

            return (solicitacoesAcervo: solicitacoesMudarAcervoBibliotecario, solicitacoesRequisicao: solicitacoesRequisicaoLivrosBibliotecario);
        }

        internal static ISolicitacao SelecionarSolicitacao(ISolicitacao solicitacao)
        {
            if (solicitacao is SolicitacaoMudarAcervoLivro)
                return solicitacoesMudarAcervo.FirstOrDefault(s => s == solicitacao);
            else if (solicitacao is SolicitacaoRequisicaoLivros)
                return solicitacaoRequisicaoLivros.FirstOrDefault(s => s == solicitacao);
            else
                return null;
        }

        internal static void RemoverSolicitacoes(ISolicitacao solicitacao)
        {
            if (solicitacao is SolicitacaoMudarAcervoLivro)
                solicitacoesMudarAcervo.Remove(solicitacao as SolicitacaoMudarAcervoLivro);
            else if (solicitacao is SolicitacaoRequisicaoLivros)
                solicitacaoRequisicaoLivros.Remove(solicitacao as SolicitacaoRequisicaoLivros);
        }

        internal static void RemoverSolicitacoes(List<ISolicitacao> solicitacoes)
        {
            foreach (var solicitacao in solicitacoes)
            {
                if (solicitacao is SolicitacaoMudarAcervoLivro)
                    solicitacoesMudarAcervo.Remove(solicitacao as SolicitacaoMudarAcervoLivro);
                else if (solicitacao is SolicitacaoRequisicaoLivros)
                    solicitacaoRequisicaoLivros.Remove(solicitacao as SolicitacaoRequisicaoLivros);
            }
        }

        internal static void AprovarSolicitacoes (List<ISolicitacao> solicitacoes, Diretor diretor)
        {

            foreach (var solicitacao in solicitacoes)
            {
                if (solicitacao is SolicitacaoMudarAcervoLivro)
                    solicitacoesMudarAcervo.FirstOrDefault(s => s == solicitacao).AprovarSolicitacao(diretor);
                else if (solicitacao is SolicitacaoRequisicaoLivros)
                    solicitacaoRequisicaoLivros.FirstOrDefault(s => s == solicitacao).AprovarSolicitacao(diretor);
            }
        }

        internal static void ReprovarSolicitacoes(List<ISolicitacao> solicitacoes, Diretor diretor)
        {
            foreach (var solicitacao in solicitacoes)
            {
                if (solicitacao is SolicitacaoMudarAcervoLivro)
                    solicitacoesMudarAcervo.FirstOrDefault(s => s == solicitacao).ReprovarSolicitacao(diretor);
                else if (solicitacao is SolicitacaoRequisicaoLivros)
                    solicitacaoRequisicaoLivros.FirstOrDefault(s => s == solicitacao).ReprovarSolicitacao(diretor);
            }
        }
    }
}
