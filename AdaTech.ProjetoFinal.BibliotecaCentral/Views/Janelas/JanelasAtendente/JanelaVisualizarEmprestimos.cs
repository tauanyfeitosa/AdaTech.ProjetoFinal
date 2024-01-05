using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    public partial class JanelaVisualizarEmprestimos : Form
    {
        private ListBox listBoxEmprestimos = new ListBox();

        public JanelaVisualizarEmprestimos()
        {
            InitializeComponent();
            ConfigurarListBox();

            VisualizarEmprestimosController controller = new VisualizarEmprestimosController(this);
            this.Text = "Visualizar Empréstimos";
        }

        private void ConfigurarListBox()
        {
            listBoxEmprestimos.Dock = DockStyle.Fill;
            listBoxEmprestimos.ScrollAlwaysVisible = true;
            listBoxEmprestimos.SelectionMode = SelectionMode.None;

            Controls.Add(listBoxEmprestimos);

            listBoxEmprestimos.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxEmprestimos.MeasureItem += ListBoxEmprestimos_MeasureItem;
            listBoxEmprestimos.DrawItem += ListBoxEmprestimos_DrawItem;
        }

        public void AdicionarEmprestimoNaListBox(string infoEmprestimo)
        {
            listBoxEmprestimos.Items.Add(infoEmprestimo);
        }

        private void ListBoxEmprestimos_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void ListBoxEmprestimos_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.Graphics.DrawString(listBoxEmprestimos.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

            e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
