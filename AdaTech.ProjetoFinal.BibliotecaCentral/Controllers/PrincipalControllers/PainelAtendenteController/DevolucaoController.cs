using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelAtendenteController
{
    internal class DevolucaoController
    {
        private JanelaDevolucao form;

        public DevolucaoController(JanelaDevolucao form)
        {
            this.form = form;
            form.DevolverButtonClick += DevolverButtonClick;
            form.CancelarButtonClick += CancelarButtonClick;
            form.ProcurarButtonClick += ProcurarButtonClick;
        }
        private void CancelarButtonClick(object sender, EventArgs e)
        {
            form.Close();
        }
        private void DevolverButtonClick(object sender, EventArgs e)
        {
            if (form.EmprestimoEscolhido)
            {
                Emprestimo emprestimoSelecionado = EmprestimoData.SelecionarEmprestimo(form.EmprestimoDevolucao);
                form.AtendenteLogin.ConfirmarDevolucao(emprestimoSelecionado); 

                string mensagem = $"Data Devolução: {emprestimoSelecionado.DataDevolucaoUsuario} - Multa: R${emprestimoSelecionado.Multa.MultaTotal:F2}";
                form.MostrarMensagem(mensagem);

                form.LimparFormulario();
                form.Close();
            }
            else
            {
                form.MostrarMensagem("Selecione um empréstimo para devolução");
            }
        }
        private void ProcurarButtonClick(object sender, EventArgs e)
        {
            ComunidadeAcademica comunidadeAcademica = UsuarioData.SelecionarComunidadeAcademica(form.NumeroMatricula());

            if (comunidadeAcademica != null)
            {
                List<Emprestimo> emprestimos = EmprestimoData.SelecionarEmprestimo(comunidadeAcademica);
                List<Emprestimo> emprestimosNaoDevolvidos = emprestimos;

                foreach (Emprestimo emprestimoEscolhido in emprestimos)
                {
                    if (emprestimoEscolhido.Devolucao == true)
                    {
                        emprestimosNaoDevolvidos.Remove(emprestimoEscolhido);
                    }
                }

                if (emprestimosNaoDevolvidos.Count > 0)
                {
                    form.ExibeRegistros(emprestimosNaoDevolvidos);
                }
                else
                {
                    MessageBox.Show("O usuário não possui empréstimos.");
                }
            }
            else
            {
                MessageBox.Show("Usuário não encontrado.");
            }
        }
    }
}
