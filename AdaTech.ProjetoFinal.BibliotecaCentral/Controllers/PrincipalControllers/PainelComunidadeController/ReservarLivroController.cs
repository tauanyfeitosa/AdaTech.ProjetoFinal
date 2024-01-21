using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasCA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelComunidadeController
{
    internal class ReservarLivroController
    {
        private readonly JanelaReservarLivro _form;
        internal ReservarLivroController(JanelaReservarLivro form)
        {
            _form = form;
            _form.ReservarClick += ReservarClick;
        }

        public void CarregarLivros()
        {
            if (_form.UsuarioLogado.TipoUsuario == TipoUsuarioComunidade.Aluno)
            {
                List<Livro> livros = LivroData.ListarLivros(TipoAcervoLivro.AcervoPublico);
                AtualizarListaLivros(livros);
            }
            else if (_form.UsuarioLogado.TipoUsuario == TipoUsuarioComunidade.Professor)
            {
                List<Livro> livrosRestrito = LivroData.ListarLivros(TipoAcervoLivro.AcervoPublico);
                List<Livro> livrosPublico = LivroData.ListarLivros(TipoAcervoLivro.AcervoRestrito);

                List<Livro> livrosCombinados = new List<Livro>();
                livrosCombinados.AddRange(livrosRestrito);
                livrosCombinados.AddRange(livrosPublico);

                AtualizarListaLivros(livrosCombinados);
            }
        }

        public void AtualizarListaLivros(List<Livro> livros)
        {
            _form.AtualizarListaLivros(livros);
        }

        private void ReservarClick(object sender, EventArgs e)
        {

        }
    }
}
