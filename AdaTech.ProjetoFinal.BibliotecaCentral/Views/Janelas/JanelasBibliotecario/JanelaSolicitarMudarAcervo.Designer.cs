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
            this.lblLivro = new System.Windows.Forms.Label();
            this.cmbLivro = new System.Windows.Forms.ComboBox();
            this.lblTipoAcervo = new System.Windows.Forms.Label();
            this.cmbTipoAcervo = new System.Windows.Forms.ComboBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnSolicitar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLivro
            // 
            this.lblLivro.Location = new System.Drawing.Point(121, 28);
            this.lblLivro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLivro.Name = "lblLivro";
            this.lblLivro.Size = new System.Drawing.Size(67, 15);
            this.lblLivro.TabIndex = 0;
            this.lblLivro.Text = "Livro:";
            // 
            // cmbLivro
            // 
            this.cmbLivro.DisplayMember = "Titulo";
            this.cmbLivro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivro.Location = new System.Drawing.Point(197, 28);
            this.cmbLivro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbLivro.Name = "cmbLivro";
            this.cmbLivro.Size = new System.Drawing.Size(135, 21);
            this.cmbLivro.TabIndex = 1;
            this.cmbLivro.ValueMember = "Isbn";
            // 
            // lblTipoAcervo
            // 
            this.lblTipoAcervo.Location = new System.Drawing.Point(72, 76);
            this.lblTipoAcervo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipoAcervo.Name = "lblTipoAcervo";
            this.lblTipoAcervo.Size = new System.Drawing.Size(91, 18);
            this.lblTipoAcervo.TabIndex = 2;
            this.lblTipoAcervo.Text = "Tipo de Acervo:";
            // 
            // cmbTipoAcervo
            // 
            this.cmbTipoAcervo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoAcervo.Location = new System.Drawing.Point(197, 76);
            this.cmbTipoAcervo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbTipoAcervo.Name = "cmbTipoAcervo";
            this.cmbTipoAcervo.Size = new System.Drawing.Size(135, 21);
            this.cmbTipoAcervo.TabIndex = 3;
            // 
            // lblDescricao
            // 
            this.lblDescricao.Location = new System.Drawing.Point(97, 157);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(67, 15);
            this.lblDescricao.TabIndex = 4;
            this.lblDescricao.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(197, 137);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(135, 53);
            this.txtDescricao.TabIndex = 5;
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.Location = new System.Drawing.Point(211, 240);
            this.btnSolicitar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(109, 23);
            this.btnSolicitar.TabIndex = 6;
            this.btnSolicitar.Text = "Solicitar Mudança de Acervo";
            // 
            // JanelaSolicitarMudarAcervo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.lblLivro);
            this.Controls.Add(this.cmbLivro);
            this.Controls.Add(this.lblTipoAcervo);
            this.Controls.Add(this.cmbTipoAcervo);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.btnSolicitar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "JanelaSolicitarMudarAcervo";
            this.Text = "JanelaSolicitarMudarAcervo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}