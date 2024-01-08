using System.Windows.Forms;
using System;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    partial class JanelaIniciarEmprestimo
    {
        public event EventHandler<CellClickEventArgs> CellClick;
        public event EventHandler CriarSemReservaButtonClick;

        private DataGridView tabela;
        private Button btnCriarSemReserva;
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabela = new System.Windows.Forms.DataGridView();
            this.colunaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaLivro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaAutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaTipoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCriarSemReserva = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).BeginInit();
            this.SuspendLayout();
            // 
            // tabela
            // 
            this.tabela.AllowUserToAddRows = false;
            this.tabela.AllowUserToDeleteRows = false;
            this.tabela.ColumnHeadersHeight = 34;
            this.tabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaID,
            this.colunaLivro,
            this.colunaAutor,
            this.colunaUsuario,
            this.colunaTipoUsuario});
            this.tabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabela.Location = new System.Drawing.Point(0, 0);
            this.tabela.Name = "tabela";
            this.tabela.ReadOnly = true;
            this.tabela.RowHeadersWidth = 62;
            this.tabela.Size = new System.Drawing.Size(800, 450);
            this.tabela.TabIndex = 1;
            // 
            // colunaID
            // 
            this.colunaID.DataPropertyName = "NumeroReserva";
            this.colunaID.HeaderText = "ID";
            this.colunaID.MinimumWidth = 8;
            this.colunaID.Name = "colunaID";
            this.colunaID.ReadOnly = true;
            this.colunaID.Width = 150;
            // 
            // colunaLivro
            // 
            this.colunaLivro.DataPropertyName = "LivroTitulo";
            this.colunaLivro.HeaderText = "Livro";
            this.colunaLivro.MinimumWidth = 8;
            this.colunaLivro.Name = "colunaLivro";
            this.colunaLivro.ReadOnly = true;
            this.colunaLivro.Width = 150;
            // 
            // colunaAutor
            // 
            this.colunaAutor.DataPropertyName = "LivroAutor";
            this.colunaAutor.HeaderText = "Autor";
            this.colunaAutor.MinimumWidth = 8;
            this.colunaAutor.Name = "colunaAutor";
            this.colunaAutor.ReadOnly = true;
            this.colunaAutor.Width = 150;
            // 
            // colunaUsuario
            // 
            this.colunaUsuario.DataPropertyName = "UsuarioNome";
            this.colunaUsuario.HeaderText = "Usuario";
            this.colunaUsuario.MinimumWidth = 8;
            this.colunaUsuario.Name = "colunaUsuario";
            this.colunaUsuario.ReadOnly = true;
            this.colunaUsuario.Width = 150;
            // 
            // colunaTipoUsuario
            // 
            this.colunaTipoUsuario.DataPropertyName = "UsuarioTipo";
            this.colunaTipoUsuario.HeaderText = "Tipo de Usuário";
            this.colunaTipoUsuario.MinimumWidth = 8;
            this.colunaTipoUsuario.Name = "colunaTipoUsuario";
            this.colunaTipoUsuario.ReadOnly = true;
            this.colunaTipoUsuario.Width = 150;
            // 
            // btnCriarSemReserva
            // 
            this.btnCriarSemReserva.AutoSize = true;
            this.btnCriarSemReserva.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCriarSemReserva.Location = new System.Drawing.Point(0, 413);
            this.btnCriarSemReserva.Name = "btnCriarSemReserva";
            this.btnCriarSemReserva.Size = new System.Drawing.Size(358, 37);
            this.btnCriarSemReserva.TabIndex = 0;
            this.btnCriarSemReserva.Text = "Criar Empréstimo Sem Reserva";
            // 
            // JanelaIniciarEmprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCriarSemReserva);
            this.Controls.Add(this.tabela);
            this.Name = "JanelaIniciarEmprestimo";
            this.Text = "JanelaIniciarEmprestimo";
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridViewTextBoxColumn colunaID;
        private DataGridViewTextBoxColumn colunaLivro;
        private DataGridViewTextBoxColumn colunaAutor;
        private DataGridViewTextBoxColumn colunaUsuario;
        private DataGridViewTextBoxColumn colunaTipoUsuario;
    }
}