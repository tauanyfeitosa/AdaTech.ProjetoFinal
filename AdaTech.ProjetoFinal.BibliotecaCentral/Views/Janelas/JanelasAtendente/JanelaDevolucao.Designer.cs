using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasAtendente
{
    partial class JanelaDevolucao
    {
        private Label label1;
        private TextBox txtMatricula;
        private Button btnProcurar;
        private Button btnCancelar;
        private Button btnDevolver;
        private GroupBox groupBox1;
        private RadioButton rdoNegativo;
        private RadioButton rdoPositivo;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;

        public event EventHandler ProcurarButtonClick;
        public event EventHandler DevolverButtonClick;
        public event EventHandler CancelarButtonClick;

        private Atendente _atendenteLogin;
        private List<int> _caixas = new List<int> { 0, 0, 0, 0, 0 };
        private bool _estadoLivro;

        internal List<int> Caixas { get { return _caixas; } }
        internal bool EstadoLivro
        {
            get { return _estadoLivro; }
            set { _estadoLivro = value; }
        }
        internal Atendente AtendenteLogin
        {
            get { return _atendenteLogin; }
            set { _atendenteLogin = value; }
        }
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoNegativo = new System.Windows.Forms.RadioButton();
            this.rdoPositivo = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matrícula:";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(120, 33);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(216, 26);
            this.txtMatricula.TabIndex = 1;
            // 
            // btnProcurar
            // 
            this.btnProcurar.Location = new System.Drawing.Point(387, 33);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(142, 36);
            this.btnProcurar.TabIndex = 2;
            this.btnProcurar.Text = "Pesquisar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(387, 153);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(142, 34);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(387, 90);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(142, 31);
            this.btnDevolver.TabIndex = 2;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoNegativo);
            this.groupBox1.Controls.Add(this.rdoPositivo);
            this.groupBox1.Location = new System.Drawing.Point(18, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 67);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Livro Mau Estado";
            // 
            // rdoNegativo
            // 
            this.rdoNegativo.AutoSize = true;
            this.rdoNegativo.Checked = true;
            this.rdoNegativo.Location = new System.Drawing.Point(102, 33);
            this.rdoNegativo.Name = "rdoNegativo";
            this.rdoNegativo.Size = new System.Drawing.Size(63, 24);
            this.rdoNegativo.TabIndex = 9;
            this.rdoNegativo.TabStop = true;
            this.rdoNegativo.Text = "Não";
            this.rdoNegativo.UseVisualStyleBackColor = true;
            // 
            // rdoPositivo
            // 
            this.rdoPositivo.AutoSize = true;
            this.rdoPositivo.Location = new System.Drawing.Point(14, 33);
            this.rdoPositivo.Name = "rdoPositivo";
            this.rdoPositivo.Size = new System.Drawing.Size(61, 24);
            this.rdoPositivo.TabIndex = 9;
            this.rdoPositivo.Text = "Sim";
            this.rdoPositivo.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(64, 204);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(22, 21);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(64, 244);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(22, 21);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(64, 284);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(22, 21);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(64, 324);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(22, 21);
            this.checkBox4.TabIndex = 13;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(64, 364);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(22, 21);
            this.checkBox5.TabIndex = 14;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // JanelaDevolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnProcurar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.label1);
            this.Name = "JanelaDevolucao";
            this.Text = "Devolução";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}