using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor
{
    partial class JanelaVisualizaReserva
    {
        private ListBox listBoxReserva = new ListBox();
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
            this.Text = "Janela Visualizar Reservas";

            listBoxReserva.Dock = DockStyle.Fill;
            listBoxReserva.ScrollAlwaysVisible = true;
            listBoxReserva.SelectionMode = SelectionMode.None;

            Controls.Add(listBoxReserva);

            listBoxReserva.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxReserva.MeasureItem += ListBoxReservas_MeasureItem;
            listBoxReserva.DrawItem += ListBoxReservas_DrawItem;
        }

        #endregion
    }
}