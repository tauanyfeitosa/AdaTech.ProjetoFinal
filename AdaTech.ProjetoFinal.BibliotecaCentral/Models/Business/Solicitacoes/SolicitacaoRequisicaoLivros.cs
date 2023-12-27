using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes
{
    internal class SolicitacaoRequisicaoLivros: ISolicitacao
    {
        private Bibliotecario _bibliotecario;
        private Livro _livro;
        private string _descricao;
        private TipoAcervoLivro _tipoAcervo;
        private bool _aprovada;

        internal Bibliotecario Bibliotecario { get => _bibliotecario;}

        internal Livro Livro { get => _livro; set => _livro = value; }

        internal bool Aprovada { get => _aprovada; set => _aprovada = value; }

        internal SolicitacaoRequisicaoLivros(Bibliotecario bibliotecario, Livro livro, TipoAcervoLivro tipoAcervo, string descricao)
        {
            if (bibliotecario == null)
                throw new ArgumentNullException(nameof(bibliotecario));
            if (livro == null)
                throw new ArgumentNullException(nameof(livro));
            if (tipoAcervo == TipoAcervoLivro.Inativo)
                throw new ArgumentNullException(nameof(tipoAcervo));
            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentNullException(nameof(descricao));
            this._bibliotecario = bibliotecario;
            this._livro = livro;
            this._tipoAcervo = tipoAcervo;
            this._descricao = descricao;
        }

        public void AprovarSolicitacao(Diretor diretor)
        {
            if (diretor == null)
                throw new ArgumentNullException(nameof(diretor));
            this.Aprovada = true;
            this.Livro.TipoAcervoLivro = this._tipoAcervo;
            var listaLivros = new List<Livro>()
            {
                this.Livro
            };
            LivroData.IncluirLivros(listaLivros);
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
                    this._tipoAcervo = tipoAcervo;
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

        //internal void LerCsvLivros(File csv)
        //{
        //    if (csv == null)
        //        throw new ArgumentNullException(nameof(csv));
        //}
    }
}
