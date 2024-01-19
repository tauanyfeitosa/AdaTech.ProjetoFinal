using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;


namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    internal partial class JanelaSolicitarLivros : Form
    {

        public JanelaSolicitarLivros(Usuario usuario)
        {
            InitializeComponent();
            cmbTipoAcervo.DataSource = Enum.GetValues(typeof(TipoAcervoLivro))
                .Cast<TipoAcervoLivro>()
                .Where(value => value != TipoAcervoLivro.EmManutencao && value != TipoAcervoLivro.Indisponivel && value != TipoAcervoLivro.Inativo)
                .ToList();

            cmbLivro.DataSource = LivroData.ObterLivros();
            controller = new SolicitarLivrosController(this, usuario);
        }

        private void BtnSolicitar_Click(object sender, EventArgs e)
        {
            controller.BtnSolicitarClick();
        }
    }
}
