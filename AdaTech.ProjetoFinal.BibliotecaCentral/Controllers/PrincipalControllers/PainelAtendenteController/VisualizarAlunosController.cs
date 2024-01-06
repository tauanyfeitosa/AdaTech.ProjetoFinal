using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers
{
    public class VisualizarAlunosController
    {
        private JanelaVisualizarAlunos form;

        public VisualizarAlunosController(JanelaVisualizarAlunos form)
        {
            this.form = form;
            form.Load += (sender, e) => ExibirAlunos();
        }

        public void ExibirAlunos()
        {
            List<ComunidadeAcademica> alunos = UsuarioData.ObterAlunos();

            foreach (ComunidadeAcademica aluno in alunos)
            {
                form.AdicionarAlunoNaListBox($"{aluno.NomeCompleto} - {aluno.Matricula} - {aluno.Curso}");
            }
        }
    }
}
