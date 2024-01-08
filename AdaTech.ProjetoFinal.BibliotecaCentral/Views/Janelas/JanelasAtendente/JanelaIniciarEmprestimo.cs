using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    internal partial class JanelaIniciarEmprestimo : Form
    {

        public JanelaIniciarEmprestimo()
        {
            InitializeComponent();

            tabela.CellClick += (sender, e) => CellClick?.Invoke(sender, new CellClickEventArgs(e.RowIndex, e.ColumnIndex));
            btnCriarSemReserva.Click += (sender, e) => CriarSemReservaButtonClick?.Invoke(sender, e);

            IniciarEmprestimoController controller = new IniciarEmprestimoController(this);
            controller.CarregarReservas();
        }


        public void AtualizarTabela(List<ReservaLivro> reservas)
        {
            tabela.DataSource = reservas;
        }

        public ReservaLivro ObterReservaSelecionada(int rowIndex)
        {
            return rowIndex >= 0 ? tabela.Rows[rowIndex].DataBoundItem as ReservaLivro : null;
        }


        public void MostrarMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }
    }

    public class CellClickEventArgs : EventArgs
    {
        public int RowIndex { get; }
        public int ColumnIndex { get; }

        public CellClickEventArgs(int rowIndex, int columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }
    }
}
