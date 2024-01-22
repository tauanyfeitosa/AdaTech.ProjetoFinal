using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasCA;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelComunidadeController
{
    internal class MultasUsuarioController
    {
        private JanelaMultasUsuario form;
        private string _emprestimoPago;
        private List<Emprestimo> _listaEmprestimos = new List<Emprestimo>();
        private ComunidadeAcademica _comunidadeAcademica;

        public MultasUsuarioController(JanelaMultasUsuario form, ComunidadeAcademica usuario)
        {
            _comunidadeAcademica = usuario;
            this.form = form;
            this.form.btnPagarClick += btnPagarClick;
            this.form.btnSairClick += btnSairClick;
        }
        public void btnPagarClick(object sender, EventArgs e)
        {
            if (VerificarCaixasEscolhidas() && _listaEmprestimos != null)
            {
                Emprestimo emprestimo = EmprestimoData.SelecionarEmprestimo(_emprestimoPago);
                emprestimo.Multa.PagarMulta();

                EmprestimoData.ExcluirEmprestimos(emprestimo.Livro, emprestimo.ComunidadeAcademica);
                form.MostrarMensagem("PAGO");
                form.Close();
            }
            else
            {
                if (_listaEmprestimos == null)
                {
                    form.MostrarMensagem("O usuário não possui multas");
                }
                else
                {
                    form.MostrarMensagem("Selecione 1 empréstimo para pagar");
                }
            }

        }
        public void btnSairClick(object sender, EventArgs e)
        {
            form.Close();
        }
        public void SepararMultas()
        {
            if (_comunidadeAcademica != null)
            {
                List<Emprestimo> emprestimos = EmprestimoData.SelecionarEmprestimo(_comunidadeAcademica);

                List<Emprestimo> emprestimosDevolvidos = new List<Emprestimo>();
                List<Emprestimo> emprestimosNaoDevolvidos = emprestimos;

                foreach (Emprestimo emprestimoEscolhido in emprestimos)
                {
                    if (emprestimoEscolhido.Devolucao == true && emprestimoEscolhido.Multa.MultaTotal > 0)
                    {
                        emprestimosDevolvidos.Add(emprestimoEscolhido);
                    }
                }

                if (emprestimosDevolvidos.Count > 0)
                {
                    form.ExibeRegistros(emprestimosDevolvidos);

                    _listaEmprestimos = emprestimosDevolvidos;
                }
                else
                {
                    MessageBox.Show("O usuário não possui multas pendentes.");
                    form.ExibeRegistros(emprestimosDevolvidos);
                }
            }
            else
            {
                MessageBox.Show("Usuário não encontrado.");
            }
        }
        private bool VerificarCaixasEscolhidas()
        {
            int contador = 0;

            if (form.Caixas.Count > 0 && _listaEmprestimos.Count > 0)
            {
                foreach (int selecao in form.Caixas)
                {
                    if (selecao == 1)
                    {
                        _emprestimoPago = _listaEmprestimos[contador].IdEmprestimo.ToString();
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