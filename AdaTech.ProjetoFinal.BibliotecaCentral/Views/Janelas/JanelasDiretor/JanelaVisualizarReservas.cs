using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas
{
    public partial class JanelaVisualizarReservas : Form
    {
        internal JanelaVisualizarReservas()
        {
            InitializeComponent();
            
        }

        private void ConfigurarListBox()
        {
            Lbx_Reservas.Dock = DockStyle.Fill;
            Lbx_Reservas.ScrollAlwaysVisible = true;
            Lbx_Reservas.SelectionMode = SelectionMode.None;

            Controls.Add(Lbx_Reservas);

            Lbx_Reservas.DrawMode = DrawMode.OwnerDrawVariable;
            Lbx_Reservas.MeasureItem += Lbx_Reservas_MeasureItem;
            Lbx_Reservas.DrawItem += Lbx_Reservas_DrawItem;
        }

        internal void ExibirReservasLivro(ComunidadeAcademica usuario)
        {
            List<ReservaLivro> reservaLivros = ReservaLivroData.ListarReservasUsuario(usuario);

            foreach (ReservaLivro reserva in reservaLivros)
            {
                Lbx_Reservas.Items.Add($"- {reserva.DataRetirarLivro}" +
                    $"\n - {reserva.UsuarioComunidadeAcademica}" +
                    $"\n - {reserva.Livro}" +
                    $"\n - {reserva.NumeroReserva}" +
                    $"\n - {reserva.Emprestimo}" +
                    $"\n - {reserva.DataRetirarLivro}" +
                    $"\n - {reserva.StatusReserva}" +
                    $"\n - {reserva.DataReserva}");
            }
        }

        private void Lbx_Reservas_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void Lbx_Reservas_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.Graphics.DrawString(Lbx_Reservas.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

            e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
