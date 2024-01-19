using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    partial class JanelaVisualizarEmprestimos
    {
        private ListBox listBoxEmprestimos = new ListBox();

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
            this.Text = "JanelaVisualizarEmprestimos";

            listBoxEmprestimos.Dock = DockStyle.Fill;
            listBoxEmprestimos.ScrollAlwaysVisible = true;
            listBoxEmprestimos.SelectionMode = SelectionMode.None;

            Controls.Add(listBoxEmprestimos);

            listBoxEmprestimos.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxEmprestimos.MeasureItem += ListBoxEmprestimos_MeasureItem;
            listBoxEmprestimos.DrawItem += ListBoxEmprestimos_DrawItem;
        }

        #endregion
    }
}