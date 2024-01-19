using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    public partial class JanelaVisualizarProfessores : Form
    {

        public JanelaVisualizarProfessores()
        {
            InitializeComponent();

            VisualizarProfessoresController controller = new VisualizarProfessoresController(this);
            this.Text = "Visualizar Professores";
        }

        public void AdicionarProfessorNaListBox(string professor)
        {
            listBoxProfessores.Items.Add(professor);
        }

        private void ListBoxProfessores_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void ListBoxProfessores_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.Graphics.DrawString(listBoxProfessores.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

            e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
