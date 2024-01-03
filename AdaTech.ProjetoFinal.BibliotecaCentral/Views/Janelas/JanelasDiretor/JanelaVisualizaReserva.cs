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
        internal JanelaVisualizaReserva()
        {
            InitializeComponent();
        }

        private void JanelaVisualizaReserva_Load(object sender, EventArgs e)
        {
            List<ReservaLivro> reservas = ReservaLivroData.ListarTodasReservas();

            foreach (var item in reservas)
            {
                Lbx_Reservas.Items.Add(item);
            }
        }
    }
}
