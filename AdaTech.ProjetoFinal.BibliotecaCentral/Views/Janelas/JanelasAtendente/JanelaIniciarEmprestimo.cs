using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    internal partial class JanelaIniciarEmprestimo : Form
    {
        public event EventHandler<CellClickEventArgs> CellClick;
        public event EventHandler CriarSemReservaButtonClick;

        private DataGridView tabela;
        private Button btnCriarSemReserva;

        public JanelaIniciarEmprestimo()
        {
            InitializeComponent();
            InicializarBotao();
            InicializarDataGrid();

            IniciarEmprestimoController controller = new IniciarEmprestimoController(this);
            controller.CarregarReservas();
        }

        private void InicializarDataGrid()
        {
            tabela = new DataGridView();

            tabela.Dock = DockStyle.Fill;
            tabela.AllowUserToAddRows = false;  
            tabela.AllowUserToDeleteRows = false;  
            tabela.ReadOnly = true;  

            DataGridViewTextBoxColumn colunaID = new DataGridViewTextBoxColumn();
            colunaID.HeaderText = "ID";
            colunaID.DataPropertyName = "NumeroReserva";  
            tabela.Columns.Add(colunaID);

            DataGridViewTextBoxColumn colunaLivro = new DataGridViewTextBoxColumn();
            colunaLivro.HeaderText = "Livro";
            colunaLivro.DataPropertyName = "LivroTitulo";  
            tabela.Columns.Add(colunaLivro);

            DataGridViewTextBoxColumn colunaAutor = new DataGridViewTextBoxColumn();
            colunaAutor.HeaderText = "Autor";
            colunaAutor.DataPropertyName = "LivroAutor";  
            tabela.Columns.Add(colunaAutor);

            DataGridViewTextBoxColumn colunaUsuario = new DataGridViewTextBoxColumn();
            colunaUsuario.HeaderText = "Usuario";
            colunaUsuario.DataPropertyName = "UsuarioNome";  
            tabela.Columns.Add(colunaUsuario);

            DataGridViewTextBoxColumn colunaTipoUsuario = new DataGridViewTextBoxColumn();
            colunaTipoUsuario.HeaderText = "Tipo de Usuário";
            colunaTipoUsuario.DataPropertyName = "UsuarioTipo";
            tabela.Columns.Add (colunaTipoUsuario);


            tabela.CellClick += (sender, e) => CellClick?.Invoke(sender, new CellClickEventArgs(e.RowIndex, e.ColumnIndex));

            Controls.Add(tabela);
        }


        public void AtualizarTabela(List<ReservaLivro> reservas)
        {
            tabela.DataSource = reservas;
        }

        public ReservaLivro ObterReservaSelecionada(int rowIndex)
        {
            return rowIndex >= 0 ? tabela.Rows[rowIndex].DataBoundItem as ReservaLivro : null;
        }

        private void InicializarBotao()
        {
            btnCriarSemReserva = new Button();
            btnCriarSemReserva.Text = "Criar Empréstimo Sem Reserva";
            btnCriarSemReserva.AutoSize = true;
            btnCriarSemReserva.Font = new Font("Arial", 12, FontStyle.Regular);
            btnCriarSemReserva.Location = new Point(10, 400);
            btnCriarSemReserva.Click += (sender, e) => CriarSemReservaButtonClick?.Invoke(sender, e);

            Controls.Add(btnCriarSemReserva);
        }

        public void MostrarMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }
    }

    public class CellClickEventArgs : EventArgs
    {
        public int RowIndex { get; }
        public int ColumnIndex { get; }

        public CellClickEventArgs(int rowIndex, int columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }
    }
}
