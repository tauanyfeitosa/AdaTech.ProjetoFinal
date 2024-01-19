using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using System;
using System.Collections.Generic;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal class Bibliotecario: Funcionario
    {
        internal Bibliotecario (string senha, string nomeCompleto, string cpf, string email, bool ativo = true)
                       : base(senha, nomeCompleto, cpf, email, ativo)
        {

        }

        private void CadastrarLivro(string titulo, string autor, string isbn, int anoPublicacao, int edicao, string editora, int exemplares)
        {
            LivroData.IncluirLivros(titulo, autor, isbn, anoPublicacao, edicao, editora, exemplares); 
        }

        private void CadastrarLivros(List<Livro> novosLivros)
        {

            HashSet<Livro> setLivros = new HashSet<Livro>();

            foreach (var item in LivroData.AcervoLivros)
            {
                setLivros.Add(item);
            }

            foreach (var item in novosLivros)
            {
                setLivros.Add(item);
            }

            List<Livro> novaListaLivros = new List<Livro>(setLivros);

            LivroData.SalvarLivrosTxt(novaListaLivros);

        }

        private void CadastrarLivro(Livro novoLivro)
        {
            HashSet<Livro> setLivros = new HashSet<Livro>();

            foreach (var item in LivroData.AcervoLivros)
            {
                setLivros.Add(item);
            }

            setLivros.Add(novoLivro);

            List<Livro> novaListaLivros = new List<Livro>(setLivros);

            LivroData.SalvarLivrosTxt(novaListaLivros);
        }

        // private void AtualizarLivro(Livro livro)


        internal void CriarSolicitacao(TipoSolicitacao tipoSolicitacao, Livro livro, TipoAcervoLivro tipoAcervo, string descricao)
        {
              SolicitacoesData.CriarSolicitacao(tipoSolicitacao, livro, tipoAcervo, descricao, this);
        }

        internal void AlterarSolicitacao(ISolicitacao solicitacao, Livro livro = null, TipoAcervoLivro tipoAcervo = TipoAcervoLivro.Inativo, string descricao = "")
        {
            if (solicitacao == null)
                throw new ArgumentNullException(nameof(solicitacao));
            solicitacao.AlterarSolicitacao(this, livro, tipoAcervo, descricao);
        }
    }
}
