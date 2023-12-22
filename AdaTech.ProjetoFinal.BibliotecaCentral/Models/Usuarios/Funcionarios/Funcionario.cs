﻿
using System.Collections.Generic;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal abstract class Funcionario: Usuario
    {
        protected bool ativo;
        internal bool Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

        protected Funcionario(string login, string senha, string nomeCompleto, string cpf, string email, bool ativo)
            : base(login, senha, nomeCompleto, cpf, email)
        {
            this.ativo = ativo;
        }

        protected List<string> ConsultarAcervo(TipoAcervoLivro acervoLivro)
        {
            List<Livro> livrosAcervo = LivroData.ListarLivros(acervoLivro);
            List<string> livrosAcervoExibicao = new List<string>();
            foreach (var item in livrosAcervo)
            {
                livrosAcervoExibicao.Add($"Titulo: {item.Titulo}, - Autor: {item.Autor}, " +
                    $"- Isbn:{item.Isbn}, - Ano de Publicação: {item.AnoPublicacao}, - Edição: {item.Edicao}," +
                    $" - Editora: {item.Editora}, - Exemplares: {item.Exemplares} livros," +
                    $" - Exemplares Disponiveis: {item.ExemplaresDisponiveis} livros, " +
                    $"- Livros em Bom Estado: {item.LivrosBomEstado} livros, " +
                    $"- Livros em Estado Mediano : {item.LivrosEstadoMediano} livros," +
                    $" - Livros em Mau Estado: {item.LivrosMauEstado} livros," +
                    $" - Tipo de Acervo do Livro: {item.tipoAcervoLivro} livros");
            }
            return livrosAcervoExibicao;
        }
        //protected List<SolicitacaoRequisicaoLivros> ConsultarRequisicaoLotes()
        //{

        //}

    }
}