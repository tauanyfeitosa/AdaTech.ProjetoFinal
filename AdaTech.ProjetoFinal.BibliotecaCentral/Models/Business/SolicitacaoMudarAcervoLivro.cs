using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business
{
    internal class SolicitacaoMudarAcervoLivro: ISolicitacao
    {
        //private Livro _livro;
        //private TipoAcervo _tipoAcervoNovo;
        private readonly Bibliotecario _bibliotecario;
        private string _descricao;
        private bool _aprovada;

        internal Bibliotecario Bibliotecario { get => _bibliotecario;}
        internal string Descricao { get => _descricao; set => _descricao = value; }
        internal bool Aprovada { get => _aprovada; set => _aprovada = value; }

        public void AprovarSolicitacao(Diretor diretor)
        {
            if (diretor == null)
                throw new ArgumentNullException(nameof(diretor));
            this.Aprovada = true;
        }

        public void AlterarSolicitacao(Livro livro = null, TipoAcervo tipoAcervo = null, string descricao = null)
        {
            throw new NotImplementedException();
        }

        public void ReprovarSolicitacao(Diretor diretor)
        {
            if (diretor == null)
                throw new ArgumentNullException(nameof(diretor));
            this.Aprovada = false;
        }
    }
}
