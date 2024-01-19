using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelBibliotecarioController;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasBibliotecario
{
    partial class JanelaSolicitarLivros
    {
        private Label lblLivro;
        private ComboBox cmbLivro;
        private Label lblTipoAcervo;
        private ComboBox cmbTipoAcervo;
        private Label lblDescricao;
        private TextBox txtDescricao;
        private Button btnSolicitar;
        private Usuario usuarioLogado;
        private SolicitarLivrosController controller;
        private System.ComponentModel.IContainer components = null;

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
            this.lblLivro.Location = new System.Drawing.Point(407, 60);
            this.lblLivro.Name = "lblLivro";
            this.lblLivro.Size = new System.Drawing.Size(61, 25);
            this.lblLivro.TabIndex = 0;
            this.lblLivro.Text = "Livro:";
            // 
            // cmbLivro
            // 
            this.cmbLivro.DisplayMember = "TituloIsbn";
            this.cmbLivro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivro.Location = new System.Drawing.Point(491, 57);
            this.cmbLivro.Name = "cmbLivro";
            this.cmbLivro.Size = new System.Drawing.Size(400, 28);
            this.cmbLivro.TabIndex = 1;
            this.cmbLivro.ValueMember = "Isbn";
            // 
            // lblTipoAcervo
            // 
            this.lblTipoAcervo.Location = new System.Drawing.Point(337, 116);
            this.lblTipoAcervo.Name = "lblTipoAcervo";
            this.lblTipoAcervo.Size = new System.Drawing.Size(131, 23);
            this.lblTipoAcervo.TabIndex = 2;
            this.lblTipoAcervo.Text = "Tipo de Acervo:";
            // 
            // cmbTipoAcervo
            // 
            this.cmbTipoAcervo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoAcervo.Location = new System.Drawing.Point(491, 111);
            this.cmbTipoAcervo.Name = "cmbTipoAcervo";
            this.cmbTipoAcervo.Size = new System.Drawing.Size(400, 28);
            this.cmbTipoAcervo.TabIndex = 3;
            // 
            // lblDescricao
            // 
            this.lblDescricao.Location = new System.Drawing.Point(368, 213);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(100, 23);
            this.lblDescricao.TabIndex = 4;
            this.lblDescricao.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(491, 181);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(400, 80);
            this.txtDescricao.TabIndex = 5;
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.Location = new System.Drawing.Point(578, 338);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(182, 34);
            this.btnSolicitar.TabIndex = 6;
            this.btnSolicitar.Text = "Solicitar Reposição";
            // 
            // JanelaSolicitarLivros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 715);
            this.Controls.Add(this.lblLivro);
            this.Controls.Add(this.cmbLivro);
            this.Controls.Add(this.lblTipoAcervo);
            this.Controls.Add(this.cmbTipoAcervo);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.btnSolicitar);
            this.Name = "JanelaSolicitarLivros";
            this.Text = "JanelaSolicitarLivros";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}