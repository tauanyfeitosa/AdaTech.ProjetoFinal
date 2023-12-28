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
        private Livro _livro;
        private ComunidadeAcademica _usuarioComunidadeAcademica;
        private DateTime _dataRetirarLivro;
        private DateTime _dataReserva;
        private StatusReserva _statusReserva;

        internal int NumeroReserva { get { return _numeroReserva; }}
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
            DateTime dataRetirarLivro, DateTime dataReserva)
        {
            this._numeroReserva = numeroReserva;
            this._livro = livro;
            this._usuarioComunidadeAcademica = usuarioComunidadeAcademica;
            this._dataReserva = dataReserva;
            this._dataRetirarLivro = dataRetirarLivro; //arrumar data retirada livro
            this._statusReserva = StatusReserva.EmAnalise;
        }


        internal void AprovarReserva(Atendente atendente)
        {
            if (atendente == null)
                throw new ArgumentNullException(nameof(atendente));
            else
            {
                this._statusReserva = StatusReserva.Aprovada;
            }
        }    
        internal void CancelarReserva()
        {
          if(this._statusReserva == StatusReserva.EmAnalise && DateTime.Now > _dataRetirarLivro)
            {
                this._statusReserva = StatusReserva.Cancelada;
            }         
        }
        //internal void AtualizarDataRetirada(Emprestimo emprestimo)
        //{
        //    //this._dataRetirarLivro = emprestimo.DataDevolucaoPrevista;           
        //}

        internal void CancelarReservaUsuario(Atendente atendente)
        {
            if(atendente != null || _usuarioComunidadeAcademica != null)
            {
                this._statusReserva = StatusReserva.Cancelada;
            }
            else
            {
                throw new InvalidOperationException("Você não tem permissão para cancelar a reserva.");
            }          
        }





    }
}

