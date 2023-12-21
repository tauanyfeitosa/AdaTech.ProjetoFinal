using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
   internal abstract class Usuarios
    {
        protected string login, senha, nomeCompleto, cpf, email;

        internal string Login { get { return login; } }
        internal string Senha { get { return senha; } }
        internal string NomeCompleto { get { return nomeCompleto; } }
        internal string Cpf { get { return cpf; } }
        internal string Email { get { return email; } }

        protected Usuarios(string login, string senha, string nomeCompleto, string cpf, string email)
        {
            this.login = login;
            this.senha = senha;
            this.nomeCompleto = nomeCompleto;
            this.cpf = cpf;
            this.email = email;
        }

        internal bool FazerLogin (string login, string senha)
        {
            return Login == login && Senha == senha;
        }

    }
}
