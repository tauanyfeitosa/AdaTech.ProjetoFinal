using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    internal partial class JanelaCriarEmprestimoSemReserva : Form
    {

        public JanelaCriarEmprestimoSemReserva()
        {
            InitializeComponent();

            cbTipoUsuario.SelectedIndexChanged += (sender, e) => TipoUsuarioSelectedIndexChanged?.Invoke(sender, e);

            btnCriarEmprestimo.Click += (sender, e) => CriarEmprestimoButtonClick?.Invoke(sender, e);

            EmprestimoController controller = new EmprestimoController(this);
            controller.CarregarUsuarios();
        }


        public void AtualizarListaUsuarios(List<ComunidadeAcademica> usuarios)
        {
            cbUsuarios.DataSource = usuarios;
            cbUsuarios.DisplayMember = "Nome";
            cbUsuarios.ValueMember = "CPF";
        }

        public void AtualizarListaLivros(List<Livro> livros)
        {
            cbLivros.DataSource = livros;
            cbLivros.DisplayMember = "Titulo";
            cbLivros.ValueMember = "Isbn";
        }

        public void MostrarMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }

        public ComboBox UsuariosComboBox => cbUsuarios;
        public ComboBox LivrosComboBox => cbLivros;
        public string TipoUsuarioSelecionado => cbTipoUsuario.SelectedItem as string;
    }
}
