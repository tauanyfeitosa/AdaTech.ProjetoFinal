using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva
{
    internal class ReservaLivro
    {
        private int _numeroReserva;
        private readonly Livro _livro;
        private readonly ComunidadeAcademica _usuarioComunidadeAcademica;
        private DateTime _dataRetirarLivro;
        private readonly DateTime _dataReserva;
        private readonly Emprestimo _emprestimo;
        private StatusReserva _statusReserva;

        internal int NumeroReserva { get { return _numeroReserva; } }
        internal Livro Livro { get { return _livro; } }
        internal ComunidadeAcademica UsuarioComunidadeAcademica { get { return _usuarioComunidadeAcademica; } }
        internal DateTime DataRetirarLivro { get { return _dataRetirarLivro; } }
        internal DateTime DataReserva { get { return _dataReserva; } }

        internal Emprestimo Emprestimo { get { return _emprestimo; } }

        internal StatusReserva StatusReserva { get { return _statusReserva; } }

        internal ReservaLivro(Emprestimo emprestimo, int numero)
        {
            this._livro = emprestimo.Livro;
            this._usuarioComunidadeAcademica = emprestimo.ComunidadeAcademica;
            this._dataReserva = DateTime.Now;
            this._dataRetirarLivro = emprestimo.DataDevolucaoPrevista.AddDays(1);
            this._emprestimo = emprestimo;
            this._statusReserva = StatusReserva.Aprovada;
            this._numeroReserva = numero;
        }

        internal void CancelarReserva()
        {
            if (this.Emprestimo.Devolucao == false && this.Emprestimo.DataDevolucaoPrevista < DateTime.Now)
            {
                this._statusReserva = StatusReserva.Cancelada;
            }
            else if (this.Emprestimo.Devolucao == true && this.DataRetirarLivro == DateTime.Now)
            {
                this._statusReserva = StatusReserva.LivroRetirado;
            }
        }
    }
}

