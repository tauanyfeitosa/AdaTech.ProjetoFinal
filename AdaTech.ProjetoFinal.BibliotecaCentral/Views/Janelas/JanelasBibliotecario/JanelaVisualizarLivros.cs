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

        public JanelaVisualizarLivros()
        {
            InitializeComponent();
            ExibirProfessores();

            this.Text = "Visualizar Livros";
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
