
namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
    using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
    using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;   
    using System.Windows.Forms;
    using System;
    using System.Linq;

    internal class ComunidadeAcademica : Usuario
    {
        private string _matricula, _curso;
        private TipoUsuarioComunidade _tipoUsuario;
        private string _senhaNova;

        internal string Matricula { get { return _matricula; } }
        internal string Curso { get { return _curso; } }
        internal TipoUsuarioComunidade TipoUsuario 
        { 
            get { return _tipoUsuario; }
            set { _tipoUsuario = value;}
        }

        internal string SenhaNova 
        { 
            get { return _senhaNova; }
            set { _senhaNova = value;}
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

        //internal void SolicitarReserva(Livro livro, Emprestimo emprestimo)
        //{
        //    if (livro.ExemplaresDisponiveis == 0)
        //    {              
        //        ReservaLivroData.AdicionarReserva (livro, this, DateTime.Now);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Não foi possível realizar a reserva.");
        //    }
        //}

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ComunidadeAcademica other = (ComunidadeAcademica)obj;
            return _matricula == other._matricula;
        }
        internal void AtribuirNovaSenha (DateTime data)
        {
            if (this.TipoUsuario == TipoUsuarioComunidade.Professor)
            {
                if (data.Day == 25)
                {
                    this.SenhaCripto = CriptografarSenha(_senhaNova);
                }
                else if (data.Day - DateTime.Now.Day == 10)
                {
                    MessageBox.Show($"A nova senha de entrada será: {_senhaNova}");
                }
            } else
            {
                throw new Exception("A senha do usuário deve ser mudada pelo mesmo!");
            }
        }

        private void GerarNovaSenha (DateTime data)
        {
            if (data.Day - 25 == 11)
            {
                string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
                string digitChars = "0123456789";
                string symbolChars = "!@#$%^&*";

                Random random = new Random();

                string caracteresCompletos = uppercaseChars + lowercaseChars + digitChars + symbolChars;

                int tamanhoSenha = random.Next(8, 17);

                string senha = string.Concat(SelecionarChar(uppercaseChars),
                    SelecionarChar(lowercaseChars), SelecionarChar(digitChars), SelecionarChar(symbolChars),
                    new string(Enumerable.Repeat(caracteresCompletos, tamanhoSenha - 4).
                    Select(s => s[random.Next(symbolChars.Length)]).ToArray()));

                string senhaNova = this.CriptografarSenha(senha);

                this.SenhaNova = senhaNova;
            }
        }

        private static char SelecionarChar(string s)
        {
            Random random = new Random();
            return s[random.Next(s.Length)];
        }
    }
}
