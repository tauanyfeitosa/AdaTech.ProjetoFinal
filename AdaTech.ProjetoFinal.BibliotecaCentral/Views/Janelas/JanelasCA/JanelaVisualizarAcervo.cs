using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasCA
{
    public partial class JanelaVisualizarAcervo : Form
    {
        private ListBox listBoxAcervo = new ListBox();

        public JanelaVisualizarAcervo()
        {
            InitializeComponent();
            ConfigurarListBox();

            VisualizarAcervoController controller = new VisualizarAcervoController(this);
            this.Text = "Visualizar Acervo";
        }

        private void ConfigurarListBox()
        {
            listBoxAcervo.Dock = DockStyle.Fill;
            listBoxAcervo.ScrollAlwaysVisible = true;
            listBoxAcervo.SelectionMode = SelectionMode.None;

            Controls.Add(listBoxAcervo);

            listBoxAcervo.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxAcervo.MeasureItem += ListBoxAcervo_MeasureItem;
            listBoxAcervo.DrawItem += ListBoxAcervo_DrawItem;
        }

        public void AdicionarLivroNaListBox(string livro)
        {
            listBoxAcervo.Items.Add(livro);
        }

        private void ListBoxAcervo_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void ListBoxAcervo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.Graphics.DrawString(listBoxAcervo.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

            e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
