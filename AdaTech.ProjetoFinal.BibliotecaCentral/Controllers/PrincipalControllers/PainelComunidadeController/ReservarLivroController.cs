using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
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
            List<Livro> livros = EmprestimoData.SelecionarLivrosEmprestados(_form.UsuarioLogado);
            AtualizarListaLivros(livros);
            
        }

        public void AtualizarListaLivros(List<Livro> livros)
        {
            _form.AtualizarListaLivros(livros);
        }

        private void ReservarClick(object sender, EventArgs e)
        {
            if (_form.LivroSelecionado != null && _form.LivroSelecionado is Livro livroSelecionado)
            {
                ReservaLivroData.AdicionarReserva(new ReservaLivro(EmprestimoData.SelecionarEmprestimo(_form.LivroSelecionado)[0], _form.UsuarioLogado));
                MessageBox.Show("Reserva realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _form.Close();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um livro antes de clicar em Reservar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
