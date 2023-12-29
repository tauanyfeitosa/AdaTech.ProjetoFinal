
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosComunidadeAcademica;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
   internal abstract class Usuario
    {
        protected string login, senhaCripto, nomeCompleto, cpf, email;
        private bool _ehAdmin;

        internal string Login
        { 
            get { return login; }
            set { login = value; }
        }
        internal string SenhaCripto { 
            get { return senhaCripto; } 
            set {  senhaCripto = value; }
        }
        internal string NomeCompleto { get { return nomeCompleto; } }
        internal string Cpf { get { return cpf; } }
        internal string Email { get { return email; } }
        internal bool EhAdmin 
        { 
            get { return _ehAdmin;  } 
            set{ if(VerificaEhAdmin()) _ehAdmin = value; }
        }

        protected Usuario(string senha, string nomeCompleto, string cpf, string email)
        {
            this.senhaCripto = CriptografarSenha(senha);
            this.nomeCompleto = nomeCompleto;
            this.cpf = cpf;
            this.email = email;
            this.EhAdmin = false;
        }

        internal bool FazerLogin(string login, string senha)
        {
            return Login == login && VerificarSenha(senha);
        }

        protected string CriptografarSenha(string senha)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); 
                }
                return builder.ToString();
            }
        }

        private bool VerificarSenha(string senhaDigitada)
        {
            string senhaDigitadaCriptografada = CriptografarSenha(senhaDigitada);

            return SenhaCripto.Equals(senhaDigitadaCriptografada);
        }

        protected void AlterarSenha(string senhaAtual, string novaSenha)
        {
            if (!VerificarSenha(senhaAtual)) throw new InvalidOperationException("Senha fornecida incorreta.");

            senhaCripto = CriptografarSenha(novaSenha);
        }

        internal static void ResetarSenha(Usuario usuario, string novaSenha)
        {
            Usuario caller = Sessao.getInstance.ObterUsuarioLogado();
            if (caller.EhAdmin)
            {
                usuario.senhaCripto = usuario.CriptografarSenha(novaSenha);
                return;
            }

                throw new UnauthorizedAccessException("Apenas administradores têm permissão para resetar senha.");
        }

        protected bool VerificaEhAdmin()
        {
            return this.GetType() == typeof(Diretor);
        }



    }
}
