using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor
{
    internal partial class MessageBoxCustomizada : Form
    {
        private Label lblMessage;
        private Button btnOption1;
        private Button btnOption2;

        public MessageBoxCustomizada(string message, string option1Text, string option2Text)
        {
            InitializeOpcoes();

            lblMessage.Text = message;
            btnOption1.Text = option1Text;
            btnOption2.Text = option2Text;
        }

        private void InitializeOpcoes()
        {
            lblMessage = new Label();
            btnOption1 = new Button();
            btnOption2 = new Button();

            lblMessage.Dock = DockStyle.Top;
            btnOption1.Dock = DockStyle.Top;
            btnOption2.Dock = DockStyle.Top;

            btnOption1.Text = "Ver Solicitações de Lote";
            btnOption2.Text = "Ver Solicitações de Acervo";

            btnOption1.Click += (sender, e) =>
            {
                DialogResult = DialogResult.Yes;
            };

            btnOption2.Click += (sender, e) =>
            {
                DialogResult = DialogResult.No;
            };


            Controls.Add(btnOption1);
            Controls.Add(btnOption2);
        }
    }
}
