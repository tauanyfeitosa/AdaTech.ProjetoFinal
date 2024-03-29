﻿using System;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes
{
    internal class SolicitacaoMudarAcervoLivro: ISolicitacao
    {
        private Livro _livro;
        private TipoAcervoLivro _tipoAcervoNovo;
        private Bibliotecario _bibliotecario;
        private string _descricao;
        private bool _aprovada;

        internal Bibliotecario Bibliotecario { get => _bibliotecario;}
        public string Descricao { get => _descricao; }
        public TipoAcervoLivro TipoAcervo { get => _tipoAcervoNovo; }

        internal Livro Livro { get => _livro; set => _livro = value; }

        public bool Aprovada { get => _aprovada; set => _aprovada = value; }

        public string LivroTitulo { get => _livro.Titulo; }
        public string LivroIsbn { get => _livro.Isbn; }


        internal SolicitacaoMudarAcervoLivro(Livro livro, TipoAcervoLivro tipoAcervoNovo, Bibliotecario bibliotecario, string descricao)
        {
            if (livro == null)
                throw new ArgumentNullException(nameof(livro));
            if (tipoAcervoNovo == TipoAcervoLivro.Inativo)
                throw new ArgumentNullException(nameof(tipoAcervoNovo));
            if (bibliotecario == null)
                throw new ArgumentNullException(nameof(bibliotecario));
            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentNullException(nameof(descricao));
            this._livro = livro;
            this._tipoAcervoNovo = tipoAcervoNovo;
            this._bibliotecario = bibliotecario;
            this._descricao = descricao;
        }

        public void AprovarSolicitacao(Diretor diretor)
        {
            if (diretor == null)
                throw new ArgumentNullException(nameof(diretor));
            this.Aprovada = true;
            this._livro.TipoAcervoLivro = this._tipoAcervoNovo;
        }

        public void AlterarSolicitacao(Bibliotecario bibliotecario = null, Livro livro = null, TipoAcervoLivro tipoAcervo = TipoAcervoLivro.Inativo, string descricao = "")
        {
            try
                {
                if (livro != null)
                    this._livro = livro;
                if (bibliotecario != null)
                    this._bibliotecario = bibliotecario;
                if (tipoAcervo != TipoAcervoLivro.Inativo)
                    this._tipoAcervoNovo = tipoAcervo;
                if (!string.IsNullOrEmpty(descricao))
                    this._descricao = descricao;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar solicitação", ex);
            }
        }

        public void ReprovarSolicitacao(Diretor diretor)
        {
            if (diretor == null)
                throw new ArgumentNullException(nameof(diretor));
            this.Aprovada = false;
        }
    }
}
