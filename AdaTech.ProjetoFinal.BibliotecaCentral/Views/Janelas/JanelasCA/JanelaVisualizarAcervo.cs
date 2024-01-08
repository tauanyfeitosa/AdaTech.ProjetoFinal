using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelComunidadeController;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasCA
{
    public partial class JanelaVisualizarAcervo : Form
    {

        public JanelaVisualizarAcervo()
        {
            InitializeComponent();

            VisualizarAcervoController controller = new VisualizarAcervoController(this);
            this.Text = "Visualizar Acervo";
        }

        public void AdicionarLivroNaListBox(string livro)
        {
            listBoxAcervo.Items.Add(livro);
        }

        private void ListBoxAcervo_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void ListBoxAcervo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.Graphics.DrawString(listBoxAcervo.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

            e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
