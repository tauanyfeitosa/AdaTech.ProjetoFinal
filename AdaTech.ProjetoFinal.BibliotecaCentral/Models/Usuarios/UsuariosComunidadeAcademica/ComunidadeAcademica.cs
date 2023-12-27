
namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
    using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
    using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;   
    using System.Windows.Forms;
    using System;

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

        protected ComunidadeAcademica(string senha, string nomeCompleto,
            string cpf, string email, string matricula, string curso, TipoUsuarioComunidade tipoUsuario)
            : base(senha, nomeCompleto, cpf, email)
        {
            this.Login = matricula;
            this._curso = curso;
            this._matricula = matricula;
            this._tipoUsuario = tipoUsuario;
        }

        internal ReservaLivro SolicitarReserva(Livro livro, Emprestimo emprestimo)
        {           
            if (livro.ExemplaresDisponiveis == 0)
            {  
                int numeroReserva = 0;//isso ta certo? Um contador de Nreservas?
                ReservaLivro reserva = new ReservaLivro(
             numeroReserva++,
             livro,
             this,
             emprestimo.DataDevolucaoPrevista,//novamente DataDevolucaoPrevista[0]
             DateTime.Now,
             StatusReserva.EmAnalise
         );
                return reserva;
            }
            else
            {
                throw new InvalidOperationException("Não foi possível fazer reserva.");
            }
        }
        //private Emprestimo SolicitarEmprestimo(Livro livro)
        //{

        //}



    }
}
