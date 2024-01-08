using System.Collections.Generic;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers
{
    public class VisualizarProfessoresController
    {
        private JanelaVisualizarProfessores form;

        public VisualizarProfessoresController(JanelaVisualizarProfessores form)
        {
            this.form = form;
            form.Load += (sender, e) => ExibirProfessores();
        }

        public void ExibirProfessores()
        {
            List<ComunidadeAcademica> professores = UsuarioData.ObterProfessores();

            foreach (ComunidadeAcademica professor in professores)
            {
                form.AdicionarProfessorNaListBox($"{professor.NomeCompleto} - {professor.Matricula} - {professor.Curso}");
            }
        }
    }
}
