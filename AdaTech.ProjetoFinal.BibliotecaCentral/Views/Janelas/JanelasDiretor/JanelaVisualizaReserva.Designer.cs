namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor
{
    partial class JanelaVisualizaReserva
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.Lbx_Reservas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.Font = new System.Drawing.Font("NSimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo.Location = new System.Drawing.Point(38, 34);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(179, 20);
            this.lbl_Titulo.TabIndex = 0;
            this.lbl_Titulo.Text = "Lista de Reservas";
            // 
            // Lbx_Reservas
            // 
            this.Lbx_Reservas.FormattingEnabled = true;
            this.Lbx_Reservas.Location = new System.Drawing.Point(42, 67);
            this.Lbx_Reservas.Name = "Lbx_Reservas";
            this.Lbx_Reservas.ScrollAlwaysVisible = true;
            this.Lbx_Reservas.Size = new System.Drawing.Size(175, 160);
            this.Lbx_Reservas.TabIndex = 1;
            // 
            // JanelaVisualizaReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 342);
            this.Controls.Add(this.Lbx_Reservas);
            this.Controls.Add(this.lbl_Titulo);
            this.Name = "JanelaVisualizaReserva";
            this.Text = "Janela Visualiza Reserva";
            this.Load += new System.EventHandler(this.JanelaVisualizaReserva_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.ListBox Lbx_Reservas;
    }
}