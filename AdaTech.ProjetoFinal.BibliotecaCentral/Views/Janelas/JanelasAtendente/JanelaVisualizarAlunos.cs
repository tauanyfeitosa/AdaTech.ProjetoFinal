﻿using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    public partial class JanelaVisualizarAlunos : Form
    {
        private ListBox listBoxAlunos = new ListBox();

        public JanelaVisualizarAlunos()
        {
            InitializeComponent();
            ConfigurarListBox();
            ExibirAlunos();

            this.Text = "Visualizar Alunos";
        }

        private void ConfigurarListBox()
        {
            listBoxAlunos.Dock = DockStyle.Fill;
            listBoxAlunos.ScrollAlwaysVisible = true;
            listBoxAlunos.SelectionMode = SelectionMode.None; 

            Controls.Add(listBoxAlunos);

            listBoxAlunos.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxAlunos.MeasureItem += ListBoxAlunos_MeasureItem;
            listBoxAlunos.DrawItem += ListBoxAlunos_DrawItem;
        }

        private void ExibirAlunos()
        {
            List<ComunidadeAcademica> alunos = UsuarioData.ObterAlunos();

            foreach (ComunidadeAcademica aluno in alunos)
            {
                listBoxAlunos.Items.Add($"{aluno.NomeCompleto} - {aluno.Matricula} - {aluno.Curso}");
            }
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