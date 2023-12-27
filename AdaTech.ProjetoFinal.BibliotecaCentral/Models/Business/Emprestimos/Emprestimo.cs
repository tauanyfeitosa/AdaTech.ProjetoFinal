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

        internal ReservaLivro ReservaLivro { get { return _reservaLivro; } }
        internal Livro Livro { get { return _livro; } }
        internal ComunidadeAcademica ComunidadeAcademica { get { return _usuarioComunidadeAcademica; } }
        internal Multa Multa { get { return _multaAtraso; } }

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

        internal void DevolverLivro(string isbn)
        {

        }
        internal void RenovarLivro()
        {

        }
    }
}
