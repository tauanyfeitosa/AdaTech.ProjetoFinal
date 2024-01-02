namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas
{
    partial class JanelaVisualizarReservas
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
            this.Lbx_Reservas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lbx_Reservas
            // 
            this.Lbx_Reservas.FormattingEnabled = true;
            this.Lbx_Reservas.Location = new System.Drawing.Point(24, 68);
            this.Lbx_Reservas.Name = "Lbx_Reservas";
            this.Lbx_Reservas.Size = new System.Drawing.Size(268, 212);
            this.Lbx_Reservas.TabIndex = 0;
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Reservas ";
            // 
            // JanelaVisualizarReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 361);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lbx_Reservas);
            this.Name = "JanelaVisualizarReservas";
            this.Text = "JanelaVisualizarReservas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Lbx_Reservas;
        private System.Windows.Forms.Label label1;
    }
}