using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor
{
    partial class MessageBoxCustomizada
    {
        private Label lblMessage;
        private Button btnOption1;
        private Button btnOption2;
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

        private void InitializeComponent(string message, string option1Text, string option2Text)
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Selecione abaixo";
            this.Visible = true;

            lblMessage = new Label();
            btnOption1 = new Button();
            btnOption2 = new Button();

            lblMessage.Dock = DockStyle.Top;
            btnOption1.Dock = DockStyle.Top;
            btnOption2.Dock = DockStyle.Top;

            btnOption1.Text = "Ver Solicitações de Lote";
            btnOption2.Text = "Ver Solicitações de Acervo";

            lblMessage.Text = message;
            btnOption1.Text = option1Text;
            btnOption2.Text = option2Text;

            lblMessage.Visible = true;
            btnOption1.Visible = true;
            btnOption2.Visible = true;

            Controls.Add(lblMessage);
            Controls.Add(btnOption1);
            Controls.Add(btnOption2);
        }

        #endregion
    }
}