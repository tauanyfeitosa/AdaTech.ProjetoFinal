using AdaTech.ProjetoFinal.BibliotecaCentral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva
{
    internal class ReservaLivro
    {
        private int _numeroReserva;
        private Livro _livro;
        private ComunidadeAcademica _usuarioComunidadeAcademica;
        private DateTime _dataRetirarLivro;
        private DateTime _dataReserva;
        private StatusReserva _statusReserva;

        internal int NumeroReserva { get { return _numeroReserva; } }
        internal Livro Livro { get { return _livro; } }
        internal ComunidadeAcademica UsuarioComunidadeAcademica { get { return _usuarioComunidadeAcademica; } }
        internal DateTime DataRetirarLivro { get { return _dataRetirarLivro; } }
        internal DateTime DataReserva { get { return _dataReserva; } }
        internal StatusReserva StatusReserva
        {
            get { return _statusReserva; }
            set { _statusReserva = value; }
        }

        internal ReservaLivro(int numeroReserva, Livro livro, ComunidadeAcademica usuarioComunidadeAcademica,
            DateTime dataRetirarLivro, DateTime dataReserva, StatusReserva statusReserva)
        {
            this._numeroReserva = numeroReserva;
            this._livro = livro;
            this._usuarioComunidadeAcademica = usuarioComunidadeAcademica;
            this._dataReserva = dataReserva;
            this._dataRetirarLivro = dataRetirarLivro;
            this._statusReserva = statusReserva;
        }

        //internal void AtualizarDataRetirada()
        //{

        //}

        //internal void AprovarReserva()
        //{

        //}

        //internal void CancelarReserva()
        //{

        //}

        //internal void CancelarReservaUsuario()
        //{

        //}
    }
}

