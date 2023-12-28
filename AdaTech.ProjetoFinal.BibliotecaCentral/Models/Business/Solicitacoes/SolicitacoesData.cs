using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Utilities;
using static System.Windows.Forms.LinkLabel;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes
{
    internal static class SolicitacoesData
    {
        private static readonly string PATH_REQUISICAO = "../../../Data/Requisicoes.txt";
        private static readonly string PATH_ACERVO = "../../../Data/MudancasAcervo.txt";
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

        // SALVAR E CARREGAR DADOS

        internal static List<SolicitacaoMudarAcervoLivro> LerSolicitacoesMudarAcervoTxt()
        {
            List<SolicitacaoMudarAcervoLivro> solicitacoesAcervo = new List<SolicitacaoMudarAcervoLivro>();

            try
            {
                using (StreamReader sr = new StreamReader(PATH_ACERVO))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        SolicitacaoMudarAcervoLivro solMudarAcervo = ConverterLinhaParaSolicitacaoAcervoLivro(linha);
                        solicitacoesAcervo.Add(solMudarAcervo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
            }

            return solicitacoesMudarAcervo;
    }

        internal static List<SolicitacaoRequisicaoLivros> LerSolicitacoesRequisicaoTxt()
        {
            List<SolicitacaoRequisicaoLivros> solicitacoesRequisicao = new List<SolicitacaoRequisicaoLivros>();

            try
            {
                using (StreamReader sr = new StreamReader(PATH_ACERVO))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        SolicitacaoRequisicaoLivros solRequisicao = ConverterLinhaParaSolicitacaoRequisicao(linha);
                        solicitacoesRequisicao.Add(solRequisicao);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
            }

            return solicitacoesRequisicao;
        }

        private static SolicitacaoMudarAcervoLivro ConverterLinhaParaSolicitacaoAcervoLivro(string linha)
    {
        string[] partes = linha.Split(',');
        string partesLivro = string.Join(",", partes.Skip(0).Take(11));
        Livro livro = LivroData.ConverterLinhaParaLivro(partesLivro);
        TipoAcervoLivro tipoAcervoLivro = Conversores.StringParaTipoAcervoLivro(partes[12]);
        string partesBibliotecario = string.Join(",", partes.Skip(13).Take(17));
        Bibliotecario bibliotecario = UsuarioData.ConverterLinhaParaBibliotecario(partesBibliotecario);
        string descricao = partes[18];
        bool aprovada = Conversores.StringParaBool(partes[19]);

        // PRECISAMOS VER COMO COLOCAR APROVADA OU NAO

        return new SolicitacaoMudarAcervoLivro(livro, tipoAcervoLivro, bibliotecario, descricao);
    }

        private static SolicitacaoRequisicaoLivros ConverterLinhaParaSolicitacaoRequisicao(string linha)
        {
            string[] partes = linha.Split(',');
            string partesBibliotecario = string.Join(",", partes.Skip(0).Take(4));
            Bibliotecario bibliotecario = UsuarioData.ConverterLinhaParaBibliotecario(partesBibliotecario);
            string partesLivro = string.Join(",", partes.Skip(5).Take(16));
            Livro livro = LivroData.ConverterLinhaParaLivro(partesLivro);
            TipoAcervoLivro tipoAcervoLivro = Conversores.StringParaTipoAcervoLivro(partes[17]);
            string descricao = partes[18];
            bool aprovada = Conversores.StringParaBool(partes[19]);

            return new SolicitacaoRequisicaoLivros(bibliotecario, livro, tipoAcervoLivro, descricao);
        }

        internal static void SalvarSolicitacoesTxt(List<SolicitacaoMudarAcervoLivro> solicitacoes)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(PATH_ACERVO))
                {
                    foreach (SolicitacaoMudarAcervoLivro solicitacao in solicitacoes)
                    {
                        string linha = ConverterParaLinha(solicitacoes);
                        sw.WriteLine(linha);
                    }
                }

                Console.WriteLine("Alterações salvas com sucesso no arquivo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static void SalvarSolicitacoesTxt(List<SolicitacaoRequisicaoLivros> solicitacoes)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(PATH_ACERVO))
                {
                    foreach (SolicitacaoRequisicaoLivros solicitacao in solicitacoes)
                    {
                        string linha = ConverterParaLinha(solicitacoes);
                        sw.WriteLine(linha);
                    }
                }

                Console.WriteLine("Alterações salvas com sucesso no arquivo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static string ConverterSolicitacaoRequisicaoParaLinha(SolicitacaoRequisicaoLivros solicitacao)
        {
            string bibliotecarioLinha = UsuarioData.ConverterBibliotecarioParaLinha(solicitacao.Bibliotecario);
            string livroLinha = LivroData.ConverterLivroParaLinha(solicitacao.Livro);

            return $"{bibliotecarioLinha},{livroLinha},{solicitacao.Descricao},{solicitacao.TipoAcervo},{solicitacao.Aprovada}";
        }

        internal static string ConverterSolicitacaoAcervoParaLinha(SolicitacaoMudarAcervoLivro solicitacao)
        {
            string bibliotecarioLinha = UsuarioData.ConverterBibliotecarioParaLinha(solicitacao.Bibliotecario);
            string livroLinha = LivroData.ConverterLivroParaLinha(solicitacao.LivroS);

            return $"{bibliotecarioLinha},{livroLinha},{solicitacao.Descricao},{solicitacao.TipoAcervo},{solicitacao.Aprovada}";
        }

    }
}
