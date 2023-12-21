using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal class ComunidadeAcademica : Usuarios
    {
        private string _matricula, _curso;
        private TipoUsuarioEnum _tipoUsuario;

        internal string Matricula { get { return _matricula; } }
        internal string Curso { get { return _curso; } }
        internal TipoUsuarioEnum TipoUsuario 
        { 
            get { return _tipoUsuario; }
            set { _tipoUsuario = value;}
        }

        protected ComunidadeAcademica(string login, string senha, string nomeCompleto,
            string cpf, string email, string matricula, string curso, TipoUsuarioEnum tipoUsuario)
            : base(login, senha, nomeCompleto, cpf, email)
        {
            this._curso = curso;
            this._matricula = matricula;
            this._tipoUsuario = tipoUsuario;
        }

        private ReservaLivro SolicitarReserva(Livros livro)
        {

        }
        private Emprestimos SolicitarEmprestimo(Livros livro)
        {

        }
    }
}
