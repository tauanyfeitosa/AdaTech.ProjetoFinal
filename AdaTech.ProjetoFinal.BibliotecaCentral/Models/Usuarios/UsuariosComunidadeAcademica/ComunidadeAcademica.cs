
namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal class ComunidadeAcademica : Usuario
    {
        private string _matricula, _curso;
        private TipoUsuarioComunidade _tipoUsuario;

        internal string Matricula { get { return _matricula; } }
        internal string Curso { get { return _curso; } }
        internal TipoUsuarioComunidade TipoUsuario 
        { 
            get { return _tipoUsuario; }
            set { _tipoUsuario = value;}
        }

        internal ComunidadeAcademica(string senha, string nomeCompleto,
            string cpf, string email, string matricula, string curso, TipoUsuarioComunidade tipoUsuario)
            : base(senha, nomeCompleto, cpf, email)
        {
            this.Login = matricula;
            this._curso = curso;
            this._matricula = matricula;
            this._tipoUsuario = tipoUsuario;
        }

        //private ReservaLivro SolicitarReserva(Livros livro)
        //{

        //}
        //private Emprestimos SolicitarEmprestimo(Livros livro)
        //{

        //}
    }
}
