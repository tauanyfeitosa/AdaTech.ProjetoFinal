using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    public partial class JanelaVisualizarLivros : Form
    {
        private ListBox listBoxLivros = new ListBox();

        public JanelaVisualizarLivros()
        {
            ConfigurarListBox();
            ExibirProfessores();

            this.Text = "Visualizar Livros";
        }

        private void ConfigurarListBox()
        {
            listBoxLivros.Dock = DockStyle.Fill;
            listBoxLivros.ScrollAlwaysVisible = true;
            listBoxLivros.SelectionMode = SelectionMode.None;

            Controls.Add(listBoxLivros);

            listBoxLivros.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxLivros.MeasureItem += ListBoxProfessores_MeasureItem;
            listBoxLivros.DrawItem += ListBoxProfessores_DrawItem;
        }

        private void ExibirProfessores()
        {
            List<Livro> livros = LivroData.ObterLivros();

            foreach (Livro livro in livros)
            {
                listBoxLivros.Items.Add($"{livro.Titulo} - {livro.Isbn} - {livro.TipoAcervoLivro}");
            }
        }

        private void ListBoxProfessores_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void ListBoxProfessores_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.Graphics.DrawString(listBoxLivros.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

            e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
