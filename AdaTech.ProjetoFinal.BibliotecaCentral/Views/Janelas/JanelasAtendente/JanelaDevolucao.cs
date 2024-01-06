using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosComunidadeAcademica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    public partial class JanelaDevolucao : Form
    {
        private System.Windows.Forms.Label label1;
        private TextBox txtMatricula;
        private Button btnProcurar;
        private Button btnCancelar;
        private Button btnDevolver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoNegativo;
        private System.Windows.Forms.RadioButton rdoPositivo;
        private DataGridView dgvEmprestimos;
        private BindingSource pessoaBindingSource;
        private DataGridViewTextBoxColumn livroDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn devolucaoDataGridViewTextBoxColumn;
        private Usuario _usuarioLogin;
        internal JanelaDevolucao(Usuario usuario)
        {
            this._usuarioLogin = usuario;
            InitializeComponent();
            CriacaoComponentes();
        }
        private void CriacaoComponentes()
        {
            #region Divisão Matrícula

            label1 = new System.Windows.Forms.Label();
            label1.AutoSize = true;
            label1.Location = new Point(20, 36);
            label1.Name = "label1";
            label1.Size = new Size(38, 13);
            label1.TabIndex = 0;
            label1.Text = "Matrícula:";

            txtMatricula = new TextBox();
            txtMatricula.Location = new Point(74, 36);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(120, 20);
            txtMatricula.TabIndex = 1;
            #endregion

            #region Botão Pesquisar

            btnProcurar = new Button();
            btnProcurar.Location = new Point(230, 36);
            btnProcurar.Name = "btnProcurar";
            btnProcurar.Size = new Size(75, 23);
            btnProcurar.TabIndex = 2;
            btnProcurar.Text = "Pesquisar";
            btnProcurar.UseVisualStyleBackColor = true;
            //btnProcurar.Click += (sender, e) => ProcurarUsuarioButtonClick?.Invoke(sender, e);
            #endregion

            #region Botão Cancelar

            btnCancelar = new Button();
            btnCancelar.Location = new Point(387, 140);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            //btnCancelar.Click += (sender, e) => EncerrarButtonClick?.Invoke(sender, e);
            #endregion

            #region Botão Devolver

            btnDevolver = new Button();
            btnDevolver.Location = new Point(387, 85);
            btnDevolver.Name = "btnDevolver";
            btnDevolver.Size = new Size(75, 23);
            btnDevolver.TabIndex = 2;
            btnDevolver.Text = "Devolver";
            btnDevolver.UseVisualStyleBackColor = true;
            //btnDevolver.Click += (sender, e) => DevolucaoButtonClick?.Invoke(sender, e);
            #endregion

            #region Caixa Seleção Mau Estado

            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox1.Location = new Point(18, 90);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(292, 67);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Livro Mau Estado";

            rdoNegativo = new System.Windows.Forms.RadioButton();
            rdoNegativo.AutoSize = true;
            rdoNegativo.Checked = true;
            rdoNegativo.Location = new Point(102, 33);
            rdoNegativo.Name = "rdoNegativo";
            rdoNegativo.Size = new Size(73, 17);
            rdoNegativo.TabIndex = 9;
            rdoNegativo.TabStop = true;
            rdoNegativo.Text = "Não";
            rdoNegativo.UseVisualStyleBackColor = true;

            rdoPositivo = new System.Windows.Forms.RadioButton();
            rdoPositivo.AutoSize = true;
            rdoPositivo.Location = new Point(14, 33);
            rdoPositivo.Name = "rdoPositivo";
            rdoPositivo.Size = new Size(67, 17);
            rdoPositivo.TabIndex = 9;
            rdoPositivo.Text = "Sim";
            rdoPositivo.UseVisualStyleBackColor = true;

            groupBox1.Controls.Add(rdoNegativo);
            groupBox1.Controls.Add(rdoPositivo);
            #endregion

            #region DataGridView Empréstimos

            dgvEmprestimos = new DataGridView();
            livroDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            devolucaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dgvEmprestimos.AllowUserToAddRows = false;
            dgvEmprestimos.AllowUserToDeleteRows = false;
            dgvEmprestimos.AutoGenerateColumns = false;
            dgvEmprestimos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmprestimos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmprestimos.Columns.AddRange(new DataGridViewColumn[] {
            livroDataGridViewTextBoxColumn,
            estadoDataGridViewTextBoxColumn,
            devolucaoDataGridViewTextBoxColumn});
            dgvEmprestimos.DataSource = pessoaBindingSource;
            dgvEmprestimos.Location = new Point(12, 200);
            dgvEmprestimos.Name = "dgvEmprestimos";
            dgvEmprestimos.ReadOnly = true;
            dgvEmprestimos.Size = new Size(527, 215);
            dgvEmprestimos.TabIndex = 9;
            #endregion

            #region Livro DGV
            livroDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            livroDataGridViewTextBoxColumn.DataPropertyName = "Livro";
            livroDataGridViewTextBoxColumn.Frozen = true;
            livroDataGridViewTextBoxColumn.HeaderText = "Livro";
            livroDataGridViewTextBoxColumn.Name = "livroDataGridViewTextBoxColumn";
            livroDataGridViewTextBoxColumn.ReadOnly = true;
            #endregion

            #region Mau Estado DGV
            estadoDataGridViewTextBoxColumn.DataPropertyName = "DataEmprestimo";
            estadoDataGridViewTextBoxColumn.HeaderText = "Empréstimo";
            estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            estadoDataGridViewTextBoxColumn.ReadOnly = true;
            #endregion

            #region Devolucao DGV

            devolucaoDataGridViewTextBoxColumn.DataPropertyName = "DataDevolucaoPrevista";
            devolucaoDataGridViewTextBoxColumn.HeaderText = "Devolução";
            devolucaoDataGridViewTextBoxColumn.Name = "devolucaoDataGridViewTextBoxColumn";
            devolucaoDataGridViewTextBoxColumn.ReadOnly = true;
            #endregion

            groupBox1.SuspendLayout();
            ((ISupportInitialize)(dgvEmprestimos)).BeginInit();
            SuspendLayout();

            Controls.Add(dgvEmprestimos);
            Controls.Add(groupBox1);
            Controls.Add(btnProcurar);
            Controls.Add(btnCancelar);
            Controls.Add(btnDevolver);
            Controls.Add(txtMatricula);
            Controls.Add(label1);

            Text = "Devolução";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((ISupportInitialize)(dgvEmprestimos)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
