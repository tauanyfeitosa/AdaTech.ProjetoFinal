using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    internal partial class JanelaVisualizarSolicitacoesLivros : Form
    {

        public JanelaVisualizarSolicitacoesLivros(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
            controller = new VisualizarSolicitacoesLivrosController(this, usuario);
            CarregarSolicitacoes();
        }

        internal DataGridView DgvSolicitacoes
        {
            get { return dgvSolicitacoes; }
        }


        private void CarregarSolicitacoes()
        {
            controller.CarregarSolicitacoes();
        }

        private void CarregarTipoAcervo()
        {

        }
    }
}
