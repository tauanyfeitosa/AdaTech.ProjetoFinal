using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasCA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelComunidadeController
{
    internal class VisualizarAcervoController
    {
        private JanelaVisualizarAcervo form;

        public VisualizarAcervoController(JanelaVisualizarAcervo form)
        {
            this.form = form;
            form.Load += (sender, e) => ExibirLivros();
        }

        public void ExibirLivros()
        {
            List<Livro> livros = LivroData.ObterLivros();

            foreach (Livro livro in livros)
            {
                form.AdicionarLivroNaListBox($"{livro.Titulo}. {livro.Autor}. {livro.Edicao}° edição. Editora {livro.Editora} - {livro.ExemplaresDisponiveis} exemplares disponíveis");
            }
        }
    }
}
