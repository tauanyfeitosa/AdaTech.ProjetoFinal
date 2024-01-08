using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasCA
{
    partial class JanelaVisualizarAcervo
    {
        private ListBox listBoxAcervo = new ListBox();
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
            this.SuspendLayout();
            // 
            // JanelaVisualizarAcervo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "JanelaVisualizarAcervo";
            this.Text = "JanelaVisualizarAcervo";
            this.ResumeLayout(false);

            listBoxAcervo.Dock = DockStyle.Fill;
            listBoxAcervo.ScrollAlwaysVisible = true;
            listBoxAcervo.SelectionMode = SelectionMode.None;

            Controls.Add(listBoxAcervo);

            listBoxAcervo.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxAcervo.MeasureItem += ListBoxAcervo_MeasureItem;
            listBoxAcervo.DrawItem += ListBoxAcervo_DrawItem;

        }

        #endregion
    }
}