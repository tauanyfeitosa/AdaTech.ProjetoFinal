using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    public partial class JanelaVisualizarProfessores : Form
    {
        private ListBox listBoxProfessores = new ListBox();

        public JanelaVisualizarProfessores()
        {
            InitializeComponent();
            ConfigurarListBox();
            ExibirProfessores();

            this.Text = "Visualizar Professores";
        }

        private void ConfigurarListBox()
        {
            listBoxProfessores.Dock = DockStyle.Fill;
            listBoxProfessores.ScrollAlwaysVisible = true;
            listBoxProfessores.SelectionMode = SelectionMode.None;

            Controls.Add(listBoxProfessores);

            listBoxProfessores.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxProfessores.MeasureItem += ListBoxProfessores_MeasureItem;
            listBoxProfessores.DrawItem += ListBoxProfessores_DrawItem;
        }

        private void ExibirProfessores()
        {
            List<ComunidadeAcademica> professores = UsuarioData.ObterProfessores();

            foreach (ComunidadeAcademica professor in professores)
            {
                listBoxProfessores.Items.Add($"{professor.NomeCompleto} - {professor.Matricula} - {professor.Curso}");
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

            e.Graphics.DrawString(listBoxProfessores.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

            e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
