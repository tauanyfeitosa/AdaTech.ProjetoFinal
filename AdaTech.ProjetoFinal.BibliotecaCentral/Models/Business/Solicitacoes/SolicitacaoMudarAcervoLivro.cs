using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business
{
    internal class SolicitacaoMudarAcervoLivro: ISolicitacao
    {
        private Livro _livro;
        private TipoAcervoLivro _tipoAcervoNovo;
        private Bibliotecario _bibliotecario;
        private string _descricao;
        private bool _aprovada;

        internal Bibliotecario Bibliotecario { get => _bibliotecario;}
        internal string Descricao { get => _descricao; set => _descricao = value; }
        internal bool Aprovada { get => _aprovada; set => _aprovada = value; }

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
        }

        public void AlterarSolicitacao(Bibliotecario bibliotecario = null, List<Livro> livro = null, TipoAcervoLivro tipoAcervo = TipoAcervoLivro.Inativo, string descricao = "")
        {
            try
                {
                if (livro.Count > 1)
                    throw new Exception("Não é possível alterar mais de um livro por solicitação");
                if (livro != null)
                    this._livro = livro.First();
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
