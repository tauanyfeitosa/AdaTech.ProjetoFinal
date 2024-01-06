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

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor
{
    public partial class JanelaVisualizaReserva : Form
    {
        private ListBox listBoxReserva = new ListBox();

        internal JanelaVisualizaReserva()
        {
            InitializeComponent();
            ConfigurarListBox();
            ExibirReservas();

            this.Text = "Visualizar Reservas";
        }

        private void ConfigurarListBox()
        {
            listBoxReserva.Dock = DockStyle.Fill;
            listBoxReserva.ScrollAlwaysVisible = true;
            listBoxReserva.SelectionMode = SelectionMode.None;

            Controls.Add(listBoxReserva);

            listBoxReserva.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxReserva.MeasureItem += ListBoxReservas_MeasureItem;
            listBoxReserva.DrawItem += ListBoxReservas_DrawItem;
        }

        private void ExibirReservas()
        {
            List<ReservaLivro> reservas = ReservaLivroData.ListarTodasReservas();

            foreach (var item in reservas)
            {
                listBoxReserva.Items.Add(item.ToString();
            }
        }

        private void ListBoxReservas_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void ListBoxReservas_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.Graphics.DrawString(listBoxReserva.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

            e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
