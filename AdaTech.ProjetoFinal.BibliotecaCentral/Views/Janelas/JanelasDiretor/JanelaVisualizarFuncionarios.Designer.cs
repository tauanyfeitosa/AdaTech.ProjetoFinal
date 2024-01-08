using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor
{
    partial class JanelaVisualizarFuncionarios
    {
        private ListBox listBoxFuncionarios = new ListBox();
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "JanelaVisualizarFuncionarios";

            listBoxFuncionarios.Dock = DockStyle.Fill;
            listBoxFuncionarios.ScrollAlwaysVisible = true;
            listBoxFuncionarios.SelectionMode = SelectionMode.None;

            Controls.Add(listBoxFuncionarios);

            listBoxFuncionarios.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxFuncionarios.MeasureItem += ListBoxFuncionarios_MeasureItem;
            listBoxFuncionarios.DrawItem += ListBoxFuncionarios_DrawItem;
        }

        #endregion
    }
}