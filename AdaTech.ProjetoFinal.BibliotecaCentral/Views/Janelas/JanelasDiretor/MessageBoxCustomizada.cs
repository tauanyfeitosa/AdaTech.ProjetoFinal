using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor
{
    internal partial class MessageBoxCustomizada : Form
    {

        public MessageBoxCustomizada(string message, string option1Text, string option2Text)
        {
            InitializeComponent(message, option1Text, option2Text);
            btnOption1.Click += (sender, e) =>
            {
                DialogResult = DialogResult.Yes;
            };

            btnOption2.Click += (sender, e) =>
            {
                DialogResult = DialogResult.No;
            };

        }
    }
}
