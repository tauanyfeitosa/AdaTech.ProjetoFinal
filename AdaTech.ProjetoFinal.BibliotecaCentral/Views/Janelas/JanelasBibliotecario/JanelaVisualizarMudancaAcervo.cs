using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    internal partial class JanelaVisualizarMudancaAcervo : Form
    {

        public JanelaVisualizarMudancaAcervo(Usuario usuario)
        {
            this.usuario = usuario;
            controller = new VisualizarMudancaAcervoController(this, usuario);
            InitializeComponent();
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

    }
}
