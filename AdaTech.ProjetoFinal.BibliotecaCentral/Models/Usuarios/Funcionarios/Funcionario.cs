
namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal abstract class Funcionario: Usuarios
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

        //protected List<Livros> ConsultarAcervo(TipoAcervoLivro acervoLivro)
        //{

        //}
        //protected List<SolicitacaoRequisicaoLivros> ConsultarRequisicaoLotes()
        //{

        //}

    }
}
