using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    partial class JanelaVisualizarLivros
    {
        private ListBox listBoxLivros = new ListBox();
        private System.ComponentModel.IContainer components = null;

        protected void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Janela Visualizar Professores";

            listBoxLivros.Dock = DockStyle.Fill;
            listBoxLivros.ScrollAlwaysVisible = true;
            listBoxLivros.SelectionMode = SelectionMode.None;

            Controls.Add(listBoxLivros);

            listBoxLivros.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxLivros.MeasureItem += ListBoxProfessores_MeasureItem;
            listBoxLivros.DrawItem += ListBoxProfessores_DrawItem;
        }

        #endregion
    }
}