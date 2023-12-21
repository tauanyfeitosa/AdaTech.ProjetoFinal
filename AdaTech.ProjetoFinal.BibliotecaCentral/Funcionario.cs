using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal abstract class Funcionario
    {
        protected bool ativo;
        internal bool Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

        protected Funcionario()
        {
            this.ativo = true;
        }

        protected List<Livros> ConsultarAcervo(TipoAcervoLivro acervoLivro)
        {

        }
        protected List<SolicitacaoRequisicaoLivros> ConsultarRequisicaoLotes()
        {

        }

    }
}
