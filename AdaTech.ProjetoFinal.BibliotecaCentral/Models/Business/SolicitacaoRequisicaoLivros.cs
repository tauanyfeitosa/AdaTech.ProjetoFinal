using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business
{
    internal class SolicitacaoRequisicaoLivros
    {
        private Bibliotecario _bibliotecario;
        private Livro _livro;
        private string _descricao;
        private TipoAcervoLivro _tipoAcervo;
        private bool _aprovada;

        internal Bibliotecario Bibliotecario { get => _bibliotecario;}

        internal Livro Livro { get => _livro; set => _livro = value; }

        internal bool Aprovada { get => _aprovada; set => _aprovada = value; }

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
                if (livro != null)
                    this._livro = livro.First();
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
