﻿using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    public partial class JanelaVisualizarAlunos : Form
    {

        public JanelaVisualizarAlunos()
        {
            InitializeComponent();
            ConfigurarListBox();

            VisualizarAlunosController controller = new VisualizarAlunosController(this);
            this.Text = "Visualizar Alunos";
        }

        private void ConfigurarListBox()
        {
        }

        public void AdicionarAlunoNaListBox(string aluno)
        {
            listBoxAlunos.Items.Add(aluno);
        }

        private void ListBoxAlunos_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void ListBoxAlunos_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.Graphics.DrawString(listBoxAlunos.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

            e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
