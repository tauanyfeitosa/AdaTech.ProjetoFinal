﻿using System;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos
{
    internal class Multa
    {
        private decimal _multaTotal;
        private decimal _multaDiaria;
        private decimal _multaMauEstado;
        private bool _pagamentoMulta;

        internal decimal MultaTotal
        {
            get
            {
                return _multaTotal;
            }
            private set
            {
                _multaTotal = value;
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

        internal Multa(DateTime dataPrevista, DateTime dataDevolucao = default(DateTime), bool mauEstado = false)
        {
            int diasAtraso;

            if (dataDevolucao > dataPrevista)
            {
                diasAtraso = (int)(dataDevolucao - dataPrevista).TotalDays;
            }
            else
            {
                diasAtraso = 0;
            }

            _multaDiaria = 1;
            _multaMauEstado = 10;
            _multaTotal = CalcularMulta(diasAtraso, mauEstado);
            _pagamentoMulta = false;
        }
        private decimal CalcularMulta(int dias, bool mauEstado)
        {
            if (mauEstado)
            {
                return (dias * MultaDiaria) + MultaMauEstado;
            }
            return dias * _multaDiaria;
        }
        internal void PagarMulta()
        {
            PagamentoMulta = true;
        }
    }
}