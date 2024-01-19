using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor
{
    public partial class JanelaVisualizarFuncionarios : Form
    {
        public JanelaVisualizarFuncionarios()
        {
            InitializeComponent();
            ExibirFuncionarios();
        }


        private void ListBoxFuncionarios_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void ListBoxFuncionarios_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.Graphics.DrawString(listBoxFuncionarios.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

            e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }

        private void ExibirFuncionarios()
        {
            List<Funcionario> funcionarios = UsuarioData.ObterFuncionarios();

            foreach (Funcionario funcionario in funcionarios)
            {
                listBoxFuncionarios.Items.Add($"{funcionario.NomeCompleto} - {funcionario.Cpf} - {funcionario.Cargo}");
            }
        }
    }
}
