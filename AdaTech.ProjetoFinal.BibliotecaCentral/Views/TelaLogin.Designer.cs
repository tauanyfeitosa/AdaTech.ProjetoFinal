using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    partial class TelaLogin
    {
        private Panel painelLogin;
        private TextBox txtUsuario;
        private TextBox txtSenha;
        private Button btnEntrar;
        private ComboBox cmbUsuario;
        private TelaInicialController controller;
        private int largura;
        private int altura;

        private System.ComponentModel.IContainer components = null;

        internal Panel PainelLogin { get => painelLogin; private set => painelLogin = value; }
        internal TextBox TxtUsuario { get => txtUsuario; private set => txtUsuario = value; }
        internal TextBox TxtSenha { get => txtSenha; private set => txtSenha = value; }
        internal ComboBox CmbUsuario { get => cmbUsuario; private set => cmbUsuario = value; }
        internal Button BtnEntrar { get => btnEntrar; private set => btnEntrar = value; }

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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Tela Login";
            this.Visible = true;

            painelLogin = new Panel();
            painelLogin.Size = new Size(largura / 3, altura / 3);
            painelLogin.Location = new Point(largura / 3, altura / 3);
            painelLogin.BackColor = Color.LightGray;
            painelLogin.BorderStyle = BorderStyle.FixedSingle;
            painelLogin.Anchor = AnchorStyles.None;
            painelLogin.AutoScroll = true;


            cmbUsuario = new ComboBox();
            cmbUsuario.Location = new Point(painelLogin.Width / 4, painelLogin.Height / 8);
            cmbUsuario.Width = painelLogin.Width / 2;
            cmbUsuario.Height = painelLogin.Height / 10;
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.DataSource = new List<string> { "Aluno", "Funcionário", "Professor" };

            Label lblUsuarioDica = new Label();
            lblUsuarioDica.Text = "Usuário";
            lblUsuarioDica.AutoSize = true;
            lblUsuarioDica.Location = new Point(painelLogin.Width / 4, painelLogin.Height / 4);
            lblUsuarioDica.Anchor = AnchorStyles.None;
            lblUsuarioDica.ForeColor = Color.Black;


            txtUsuario = new TextBox();
            txtUsuario.Size = new Size(painelLogin.Width / 2, painelLogin.Height / 10);
            txtUsuario.Location = new Point(painelLogin.Width / 4, painelLogin.Height / 3);
            txtUsuario.Anchor = AnchorStyles.None;
            txtUsuario.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnEntrar.PerformClick();
                }
            };

            Label lblSenha = new Label();
            lblSenha.Text = "Senha";
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(painelLogin.Width / 4, (painelLogin.Height / 2) - 20);
            lblSenha.Anchor = AnchorStyles.None;
            lblSenha.ForeColor = Color.Black;

            txtSenha = new TextBox();
            txtSenha.Size = new Size(painelLogin.Width / 2, painelLogin.Height / 10 + 30);
            txtSenha.Location = new Point(painelLogin.Width / 4, painelLogin.Height / 2);
            txtSenha.Anchor = AnchorStyles.None;
            txtSenha.PasswordChar = '*';
            txtSenha.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnEntrar.PerformClick();
                }
            };

            btnEntrar = new Button();
            btnEntrar.Size = new Size(painelLogin.Width / 2, painelLogin.Height / 10);
            btnEntrar.Location = new Point(painelLogin.Width / 4, painelLogin.Height / 4 * 3);
            btnEntrar.Anchor = AnchorStyles.None;
            btnEntrar.Text = "Entrar";
            btnEntrar.Click += OnClickEntrar;

            painelLogin.Controls.Add(txtUsuario);
            painelLogin.Controls.Add(txtSenha);
            painelLogin.Controls.Add(btnEntrar);
            painelLogin.Controls.Add(cmbUsuario);
            painelLogin.Controls.Add(lblUsuarioDica);
            painelLogin.Controls.Add(lblSenha);

            Controls.Add(painelLogin);
        }

        #endregion
    }
}

