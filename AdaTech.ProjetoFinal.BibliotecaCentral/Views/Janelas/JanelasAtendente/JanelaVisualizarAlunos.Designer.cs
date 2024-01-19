using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    partial class JanelaVisualizarAlunos
    {

        private ListBox listBoxAlunos = new ListBox();
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
            this.Text = "Janela Visualizar Alunos";

            listBoxAlunos.Dock = DockStyle.Fill;
            listBoxAlunos.ScrollAlwaysVisible = true;
            listBoxAlunos.SelectionMode = SelectionMode.None;

            listBoxAlunos.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxAlunos.MeasureItem += ListBoxAlunos_MeasureItem;
            listBoxAlunos.DrawItem += ListBoxAlunos_DrawItem;


            Controls.Add(listBoxAlunos);
        }

        #endregion
    }
}