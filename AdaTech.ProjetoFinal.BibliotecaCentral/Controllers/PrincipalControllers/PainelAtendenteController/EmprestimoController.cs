using System;
using System.Collections.Generic;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers
{
    internal class EmprestimoController
    {
        private JanelaCriarEmprestimoSemReserva form;

        public EmprestimoController(JanelaCriarEmprestimoSemReserva form)
        {
            this.form = form;
            form.TipoUsuarioSelectedIndexChanged += TipoUsuarioSelectedIndexChanged;
            form.CriarEmprestimoButtonClick += CriarEmprestimoButtonClick;
        }

        public void CarregarUsuarios()
        {
            List<ComunidadeAcademica> usuarios = UsuarioData.ListarCA(TipoUsuarioComunidade.Aluno);
            form.AtualizarListaUsuarios(usuarios);
        }

        public void AtualizarListaUsuarios(List<ComunidadeAcademica> usuarios)
        {
            form.AtualizarListaUsuarios(usuarios);
        }

        public void TipoUsuarioSelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoUsuarioSelecionado = form.TipoUsuarioSelecionado;

            if (tipoUsuarioSelecionado == "Aluno")
            {
                List<ComunidadeAcademica> alunos = UsuarioData.ListarCA(TipoUsuarioComunidade.Aluno);
                AtualizarListaUsuarios(alunos);
                CarregarLivros(tipoUsuarioSelecionado);
            }
            else if (tipoUsuarioSelecionado == "Professor")
            {
                List<ComunidadeAcademica> professores = UsuarioData.ListarCA(TipoUsuarioComunidade.Professor);
                form.MostrarMensagem(professores.Count > 0 ? professores[0].TipoUsuario.ToString() : "Nenhum professor encontrado.");
                AtualizarListaUsuarios(professores);
                CarregarLivros(tipoUsuarioSelecionado);
            }
        }

        public void CarregarLivros(string tipoUsuarioSelecionado)
        {
            if (tipoUsuarioSelecionado == "Aluno")
            {
                List<Livro> livros = LivroData.ListarLivros(TipoAcervoLivro.AcervoPublico);
                AtualizarListaLivros(livros);
            }
            else if (tipoUsuarioSelecionado == "Professor")
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
            form.AtualizarListaLivros(livros);
        }

        public void CriarEmprestimoButtonClick(object sender, EventArgs e)
        {
            EmprestimoData.CriarEmprestimoSemReserva(form.UsuariosComboBox, form.LivrosComboBox);
        }
    }
}
