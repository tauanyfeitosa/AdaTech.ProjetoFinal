using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    partial class JanelaSolicitarMudarAcervo
    {
        private ComboBox cmbLivro;
        private ComboBox cmbTipoAcervo;
        private TextBox txtDescricao;
        private Button btnSolicitar;
        private Label lblLivro;
        private Label lblTipoAcervo;
        private Label lblDescricao;
        private SolicitarMudarAcervoController controller;
        private Usuario usuario;

        internal Usuario Usuario
        {
            get { return usuario; }
        }

        internal ComboBox CmbLivro
        {
            get { return cmbLivro; }
        }

        internal ComboBox CmbTipoAcervo
        {
            get { return cmbTipoAcervo; }
        }

        internal TextBox TxtDescricao
        {
            get { return txtDescricao; }
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
            this.lblLivro = new Label();
            this.cmbLivro = new ComboBox();
            this.lblTipoAcervo = new Label();
            this.cmbTipoAcervo = new ComboBox();
            this.lblDescricao = new Label();
            this.txtDescricao = new TextBox();
            this.btnSolicitar = new Button();
            this.SuspendLayout();
            // 
            // lblLivro
            // 
            this.lblLivro.Location = new System.Drawing.Point(181, 43);
            this.lblLivro.Name = "lblLivro";
            this.lblLivro.Size = new System.Drawing.Size(100, 23);
            this.lblLivro.TabIndex = 0;
            this.lblLivro.Text = "Livro:";
            // 
            // cmbLivro
            // 
            this.cmbLivro.DisplayMember = "Titulo";
            this.cmbLivro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivro.Location = new System.Drawing.Point(296, 43);
            this.cmbLivro.Name = "cmbLivro";
            this.cmbLivro.Size = new System.Drawing.Size(200, 28);
            this.cmbLivro.TabIndex = 1;
            this.cmbLivro.ValueMember = "Isbn";
            // 
            // lblTipoAcervo
            // 
            this.lblTipoAcervo.Location = new System.Drawing.Point(108, 117);
            this.lblTipoAcervo.Name = "lblTipoAcervo";
            this.lblTipoAcervo.Size = new System.Drawing.Size(137, 28);
            this.lblTipoAcervo.TabIndex = 2;
            this.lblTipoAcervo.Text = "Tipo de Acervo:";
            // 
            // cmbTipoAcervo
            // 
            this.cmbTipoAcervo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoAcervo.Location = new System.Drawing.Point(296, 117);
            this.cmbTipoAcervo.Name = "cmbTipoAcervo";
            this.cmbTipoAcervo.Size = new System.Drawing.Size(200, 28);
            this.cmbTipoAcervo.TabIndex = 3;
            // 
            // lblDescricao
            // 
            this.lblDescricao.Location = new System.Drawing.Point(145, 241);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(100, 23);
            this.lblDescricao.TabIndex = 4;
            this.lblDescricao.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(296, 211);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(200, 80);
            this.txtDescricao.TabIndex = 5;
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.Location = new System.Drawing.Point(316, 369);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(163, 28);
            this.btnSolicitar.TabIndex = 6;
            this.btnSolicitar.Text = "Solicitar Mudança de Acervo";
            // 
            // JanelaSolicitarMudarAcervo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblLivro);
            this.Controls.Add(this.cmbLivro);
            this.Controls.Add(this.lblTipoAcervo);
            this.Controls.Add(this.cmbTipoAcervo);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.btnSolicitar);
            this.Name = "JanelaSolicitarMudarAcervo";
            this.Text = "JanelaSolicitarMudarAcervo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}