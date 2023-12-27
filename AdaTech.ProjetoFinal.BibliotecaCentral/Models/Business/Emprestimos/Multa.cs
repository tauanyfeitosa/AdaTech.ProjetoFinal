using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos
{
    internal class Multa
    {
        private decimal _multas;
        private decimal _multaDiaria;
        private decimal _multaMauEstado;
        private bool _pagamentoMulta;
        internal Multa()
        {
            this._pagamentoMulta = true;
        }
        internal decimal Multas
        {
            get
            {
                return _multas;
            }
            private set
            {
                _multas = value;
            }
        }
        internal decimal MultaDiaria
        {
            get
            {
                return _multaDiaria;
            }
            private set
            {
                _multaDiaria = value;
            }
        }
        internal decimal MultaMauEstado
        {
            get
            {
                return _multaMauEstado;
            }
            private set
            {
                _multaMauEstado = value;
            }
        }
        internal bool PagamentoMulta
        {
            get
            {
                return _pagamentoMulta;
            }
            private set
            {
                _pagamentoMulta = value;
            }
        }
        internal void CalcularMulta()
        {

        }
        internal void PagarMulta()
        {

        }
    }
}
