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
        public event EventHandler TipoUsuarioSelectedIndexChanged;
        public event EventHandler CriarEmprestimoButtonClick;

        private ComboBox cbTipoUsuario;
        private ComboBox cbUsuarios;
        private ComboBox cbLivros;
        private Button btnCriarEmprestimo;

        public JanelaCriarEmprestimoSemReserva()
        {
            InitializeComponent();
            InicializarControles();

            EmprestimoController controller = new EmprestimoController(this);
            controller.CarregarUsuarios();
        }

        private void InicializarControles()
        {
            cbTipoUsuario = new ComboBox();
            cbTipoUsuario.Items.AddRange(new string[] { "Aluno", "Professor" });
            cbTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoUsuario.Location = new Point(10, 10);
            cbTipoUsuario.SelectedIndexChanged += (sender, e) => TipoUsuarioSelectedIndexChanged?.Invoke(sender, e);

            cbUsuarios = new ComboBox();
            cbUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUsuarios.Location = new Point(10, 40);

            cbLivros = new ComboBox();
            cbLivros.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLivros.Location = new Point(10, 70);

            btnCriarEmprestimo = new Button();
            btnCriarEmprestimo.Text = "Criar Empréstimo";
            btnCriarEmprestimo.AutoSize = true;
            btnCriarEmprestimo.Font = new Font("Arial", 12, FontStyle.Regular);
            btnCriarEmprestimo.Location = new Point(10, 300);
            btnCriarEmprestimo.Click += (sender, e) => CriarEmprestimoButtonClick?.Invoke(sender, e);

            Controls.Add(cbTipoUsuario);
            Controls.Add(cbUsuarios);
            Controls.Add(cbLivros);
            Controls.Add(btnCriarEmprestimo);
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
