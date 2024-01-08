using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    partial class JanelaCriarEmprestimoSemReserva
    {
        public event EventHandler TipoUsuarioSelectedIndexChanged;
        public event EventHandler CriarEmprestimoButtonClick;

        private ComboBox cbTipoUsuario;
        private ComboBox cbUsuarios;
        private ComboBox cbLivros;
        private Button btnCriarEmprestimo;
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
            this.cbTipoUsuario = new System.Windows.Forms.ComboBox();
            this.lblTipoUsuario = new System.Windows.Forms.Label();
            this.cbUsuarios = new System.Windows.Forms.ComboBox();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.cbLivros = new System.Windows.Forms.ComboBox();
            this.lblLivros = new System.Windows.Forms.Label();
            this.btnCriarEmprestimo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbTipoUsuario
            // 
            this.cbTipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoUsuario.Items.AddRange(new object[] {
            "Aluno",
            "Professor"});
            this.cbTipoUsuario.Location = new System.Drawing.Point(376, 32);
            this.cbTipoUsuario.Name = "cbTipoUsuario";
            this.cbTipoUsuario.Size = new System.Drawing.Size(121, 28);
            this.cbTipoUsuario.TabIndex = 1;
            // 
            // lblTipoUsuario
            // 
            this.lblTipoUsuario.AutoSize = true;
            this.lblTipoUsuario.Location = new System.Drawing.Point(211, 32);
            this.lblTipoUsuario.Name = "lblTipoUsuario";
            this.lblTipoUsuario.Size = new System.Drawing.Size(124, 20);
            this.lblTipoUsuario.TabIndex = 0;
            this.lblTipoUsuario.Text = "Tipo de Usuário:";
            // 
            // cbUsuarios
            // 
            this.cbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuarios.Location = new System.Drawing.Point(376, 89);
            this.cbUsuarios.Name = "cbUsuarios";
            this.cbUsuarios.Size = new System.Drawing.Size(121, 28);
            this.cbUsuarios.TabIndex = 3;
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Location = new System.Drawing.Point(267, 89);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(68, 20);
            this.lblUsuarios.TabIndex = 2;
            this.lblUsuarios.Text = "Usuário:";
            // 
            // cbLivros
            // 
            this.cbLivros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLivros.Location = new System.Drawing.Point(376, 146);
            this.cbLivros.Name = "cbLivros";
            this.cbLivros.Size = new System.Drawing.Size(121, 28);
            this.cbLivros.TabIndex = 5;
            // 
            // lblLivros
            // 
            this.lblLivros.AutoSize = true;
            this.lblLivros.Location = new System.Drawing.Point(289, 146);
            this.lblLivros.Name = "lblLivros";
            this.lblLivros.Size = new System.Drawing.Size(46, 20);
            this.lblLivros.TabIndex = 4;
            this.lblLivros.Text = "Livro:";
            // 
            // btnCriarEmprestimo
            // 
            this.btnCriarEmprestimo.AutoSize = true;
            this.btnCriarEmprestimo.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCriarEmprestimo.Location = new System.Drawing.Point(289, 246);
            this.btnCriarEmprestimo.Name = "btnCriarEmprestimo";
            this.btnCriarEmprestimo.Size = new System.Drawing.Size(208, 37);
            this.btnCriarEmprestimo.TabIndex = 6;
            this.btnCriarEmprestimo.Text = "Criar Empréstimo";
            // 
            // JanelaCriarEmprestimoSemReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTipoUsuario);
            this.Controls.Add(this.cbTipoUsuario);
            this.Controls.Add(this.lblUsuarios);
            this.Controls.Add(this.cbUsuarios);
            this.Controls.Add(this.lblLivros);
            this.Controls.Add(this.cbLivros);
            this.Controls.Add(this.btnCriarEmprestimo);
            this.Name = "JanelaCriarEmprestimoSemReserva";
            this.Text = "JanelaCriarEmprestimoSemReserva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTipoUsuario;
        private Label lblUsuarios;
        private Label lblLivros;
    }
}