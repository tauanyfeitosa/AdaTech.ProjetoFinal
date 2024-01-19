using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor
{
    partial class JanelaDetalhesSolicitacao
    {
        private Label lblBibliotecario;
        private Label lblDescricao;
        private Label lblTipoAcervo;
        private Label lblLivroTitulo;
        private Label lblLivroIsbn;
        private Label lblAprovada;
        private Button btnAprovar;
        private Button btnReprovar;
        private Button btnFechar;
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
            this.lblBibliotecario = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblTipoAcervo = new System.Windows.Forms.Label();
            this.lblLivroTitulo = new System.Windows.Forms.Label();
            this.lblLivroIsbn = new System.Windows.Forms.Label();
            this.lblAprovada = new System.Windows.Forms.Label();
            this.btnAprovar = new System.Windows.Forms.Button();
            this.btnReprovar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBibliotecario
            // 
            this.lblBibliotecario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBibliotecario.Location = new System.Drawing.Point(0, 115);
            this.lblBibliotecario.Name = "lblBibliotecario";
            this.lblBibliotecario.Size = new System.Drawing.Size(624, 23);
            this.lblBibliotecario.TabIndex = 0;
            // 
            // lblDescricao
            // 
            this.lblDescricao.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescricao.Location = new System.Drawing.Point(0, 92);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(624, 23);
            this.lblDescricao.TabIndex = 1;
            // 
            // lblTipoAcervo
            // 
            this.lblTipoAcervo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTipoAcervo.Location = new System.Drawing.Point(0, 69);
            this.lblTipoAcervo.Name = "lblTipoAcervo";
            this.lblTipoAcervo.Size = new System.Drawing.Size(624, 23);
            this.lblTipoAcervo.TabIndex = 2;
            // 
            // lblLivroTitulo
            // 
            this.lblLivroTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLivroTitulo.Location = new System.Drawing.Point(0, 46);
            this.lblLivroTitulo.Name = "lblLivroTitulo";
            this.lblLivroTitulo.Size = new System.Drawing.Size(624, 23);
            this.lblLivroTitulo.TabIndex = 3;
            // 
            // lblLivroIsbn
            // 
            this.lblLivroIsbn.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLivroIsbn.Location = new System.Drawing.Point(0, 23);
            this.lblLivroIsbn.Name = "lblLivroIsbn";
            this.lblLivroIsbn.Size = new System.Drawing.Size(624, 23);
            this.lblLivroIsbn.TabIndex = 4;
            // 
            // lblAprovada
            // 
            this.lblAprovada.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAprovada.Location = new System.Drawing.Point(0, 0);
            this.lblAprovada.Name = "lblAprovada";
            this.lblAprovada.Size = new System.Drawing.Size(624, 23);
            this.lblAprovada.TabIndex = 5;
            // 
            // btnAprovar
            // 
            this.btnAprovar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAprovar.Location = new System.Drawing.Point(0, 343);
            this.btnAprovar.Name = "btnAprovar";
            this.btnAprovar.Size = new System.Drawing.Size(624, 46);
            this.btnAprovar.TabIndex = 6;
            this.btnAprovar.Text = "Aprovar";
            // 
            // btnReprovar
            // 
            this.btnReprovar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReprovar.Location = new System.Drawing.Point(0, 389);
            this.btnReprovar.Name = "btnReprovar";
            this.btnReprovar.Size = new System.Drawing.Size(624, 42);
            this.btnReprovar.TabIndex = 7;
            this.btnReprovar.Text = "Reprovar";
            // 
            // btnFechar
            // 
            this.btnFechar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFechar.Location = new System.Drawing.Point(0, 431);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(624, 43);
            this.btnFechar.TabIndex = 8;
            this.btnFechar.Text = "Fechar";
            // 
            // JanelaDetalhesSolicitacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 474);
            this.Controls.Add(this.lblBibliotecario);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblTipoAcervo);
            this.Controls.Add(this.lblLivroTitulo);
            this.Controls.Add(this.lblLivroIsbn);
            this.Controls.Add(this.lblAprovada);
            this.Controls.Add(this.btnAprovar);
            this.Controls.Add(this.btnReprovar);
            this.Controls.Add(this.btnFechar);
            this.Name = "JanelaDetalhesSolicitacao";
            this.Text = "Detalhes da Solicitação";
            this.ResumeLayout(false);

        }

        #endregion
    }
}