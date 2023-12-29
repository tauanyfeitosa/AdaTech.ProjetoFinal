using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos
{
    internal class Emprestimo
    {
        private ReservaLivro _reservaLivro;
        private Livro _livro;
        private ComunidadeAcademica _usuarioComunidadeAcademica;
        private DateTime _dataEmprestimo;
        private DateTime _dataDevolucaoPrevista;
        private DateTime _dataDevolucaoUsuario;
        private bool _devolucao;
        private Multa _multaAtraso;
        private decimal _valor;
        internal Emprestimo(ComunidadeAcademica comunidadeAcademica, Livro livro, ReservaLivro reserva = null)
        {
            this._livro = livro;
            this._dataEmprestimo = DateTime.Now;
            this._dataDevolucaoPrevista = _dataEmprestimo.AddDays(7);
            this._usuarioComunidadeAcademica = comunidadeAcademica;
            this._devolucao = false;
            this._reservaLivro = reserva;
            livro.AlterarExemplarDisponivel('d');
        }

        internal ReservaLivro ReservaLivro { get => _reservaLivro; } 
        internal Livro Livro { get => _livro; } 
        internal ComunidadeAcademica ComunidadeAcademica { get => _usuarioComunidadeAcademica; } 
        internal Multa Multa { get => _multaAtraso; } 

        internal DateTime DataEmprestimo
        {
            get
            {
                return _dataEmprestimo;
            }
            private set
            {
                _dataEmprestimo = value;
            }
        }
        internal DateTime DataDevolucaoPrevista
        {
            get
            {
                return _dataDevolucaoPrevista;
            }
            private set
            {
                _dataDevolucaoPrevista = value;
            }
        }
        internal DateTime DataDevolucaoUsuario
        {
            get
            {
                return _dataDevolucaoUsuario;
            }
            private set
            {
                _dataDevolucaoUsuario = value;
            }
        }
        internal bool Devolucao
        {
            get
            {
                return _devolucao;
            }
            private set
            {
                _devolucao = value;
            }
        }

        internal void VerificarMulta()
        {
            if((_dataDevolucaoPrevista - _dataDevolucaoUsuario).Days < 0)
            {
               this._valor += _multaAtraso.CalcularMulta(Math.Abs((_dataDevolucaoPrevista - _dataDevolucaoUsuario).Days));
            }
        }

        internal void DevolverLivro(string estadoLivro)
        {
            if(estadoLivro == "ruim")
            {
                _valor += _multaAtraso.MultaMauEstado;
            }
            this._dataDevolucaoUsuario = DateTime.Now;
            this._devolucao = true;
            VerificarMulta();
        }
        internal void RenovarLivro()
        {

        }
    }
}
