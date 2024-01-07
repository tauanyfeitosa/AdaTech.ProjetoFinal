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
        private DateTime _dataReserva;
        private readonly Emprestimo _emprestimo;
        private StatusReserva _statusReserva;

        public int NumeroReserva 
        {
            get { return _numeroReserva; }
            set { _numeroReserva = value; }
        }
        internal Livro Livro { get { return _livro; } }
        internal ComunidadeAcademica UsuarioComunidadeAcademica { get { return _usuarioComunidadeAcademica; } }

        public string LivroTitulo { get { return this.Livro.Titulo; } }
        public string LivroAutor { get { return this.Livro.Autor; } }
        public string UsuarioNome { get { return this.UsuarioComunidadeAcademica.NomeCompleto; } }
        public string UsuarioTipo { get { return this.UsuarioComunidadeAcademica.TipoUsuario.ToString(); } }
        internal DateTime DataRetirarLivro 
        { 
            get { return _dataRetirarLivro; }
            set { _dataRetirarLivro = value; }
        }
        internal DateTime DataReserva { get { return _dataReserva; } set { _dataReserva = value; } }

        internal Emprestimo Emprestimo { get { return _emprestimo; } }

        internal StatusReserva StatusReserva 
        { 
            get { return _statusReserva; } 
            set { _statusReserva = value; }
        }

        internal ReservaLivro(Emprestimo emprestimo, ComunidadeAcademica usuario)
        {
            this._livro = emprestimo.Livro;
            this._usuarioComunidadeAcademica = usuario;
            this._dataReserva = DateTime.Now;
            this._dataRetirarLivro = emprestimo.DataDevolucaoPrevista.AddDays(1);
            this._emprestimo = emprestimo;
            this._statusReserva = StatusReserva.Aprovada;
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

        public override string ToString()
        {
            return $"- Livro: {Livro.Titulo} " +
                $"- Requerente: {UsuarioComunidadeAcademica.NomeCompleto} " +
                $"- Data de reserva: {DataReserva.ToShortDateString()}" +
                $"- Data de retirada prevista: {DataRetirarLivro.ToShortDateString()}";
        }
    }
}

