using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelAtendenteController
{
    internal class DevolucaoController
    {
        private JanelaDevolucao form;
        private string _emprestimoDevolucao;
        private List<Emprestimo> _listaEmprestimos = new List<Emprestimo>();

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
            if (VerificarCaixasEscolhidas())
            {
                Emprestimo emprestimoSelecionado = EmprestimoData.SelecionarEmprestimo(_emprestimoDevolucao);
                emprestimoSelecionado.MauEstado = form.EstadoLivro;
                string mensagem = emprestimoSelecionado.ToString();
                form.MostrarMensagem($"{mensagem}");

                form.AtendenteLogin.ConfirmarDevolucao(emprestimoSelecionado);
                form.Close();
            }
            else
            {
                form.MostrarMensagem("Selecione um empréstimo para devolução");
            }
        }
        private void ProcurarButtonClick(object sender, EventArgs e)
        {
            _listaEmprestimos = null;
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

                    _listaEmprestimos = emprestimosNaoDevolvidos;
                    form.LimparFormulario();
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

        private bool VerificarCaixasEscolhidas()
        {
            List<Emprestimo> emprestimos = new List<Emprestimo>();
            emprestimos = _listaEmprestimos;
            MessageBox.Show($"{_listaEmprestimos.Count}");
            int contador = 0;

            if(form.Caixas.Count > 0 && emprestimos != null)
            {
                foreach (int selecao in form.Caixas)
                {
                    if (selecao == 1)
                    {
                        _emprestimoDevolucao = emprestimos[contador].IdEmprestimo.ToString();
                        contador++;
                    }
                }

                if (contador == 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
