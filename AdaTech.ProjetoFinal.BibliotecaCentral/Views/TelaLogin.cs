﻿using System;
using System.Drawing;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    public partial class TelaLogin : Form
    {
        private Panel painelLogin;
        private TextBox txtUsuario;
        private TextBox txtSenha;
        private Button btnEntrar;
        private TelaInicialController controller;

        internal Panel PainelLogin { get => painelLogin; private set => painelLogin = value; }
        internal TextBox TxtUsuario { get => txtUsuario; private set => txtUsuario = value; }
        internal TextBox TxtSenha { get => txtSenha; private set => txtSenha = value; }
        internal Button BtnEntrar { get => btnEntrar; private set => btnEntrar = value; }


        public static void Main(string[] args)
        {
            Application.Run(new TelaLogin());
        }

        public TelaLogin()
        {
            Load += OnLoad;
            this.controller = new TelaInicialController(this);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            int larguraTela = this.ClientSize.Width;
            int alturaTela = this.ClientSize.Height;

            InitializeLoginForm(larguraTela, alturaTela);
        }

        private void InitializeLoginForm (int largura, int altura)
        {
            painelLogin = new Panel();
            painelLogin.Size = new Size(largura / 3, altura / 3);
            painelLogin.Location = new Point(largura / 3, altura / 3);
            painelLogin.BackColor = Color.LightGray;
            painelLogin.BorderStyle = BorderStyle.FixedSingle;
            painelLogin.Anchor = AnchorStyles.None;
            painelLogin.AutoScroll = true;

            txtUsuario = new TextBox();
            txtUsuario.Size = new Size(painelLogin.Width / 2, painelLogin.Height / 10);
            txtUsuario.Location = new Point(painelLogin.Width / 4, painelLogin.Height / 4);
            txtUsuario.Anchor = AnchorStyles.None;
            txtUsuario.Text = "Usuário";

            txtSenha = new TextBox();
            txtSenha.Size = new Size(painelLogin.Width / 2, painelLogin.Height / 10);
            txtSenha.Location = new Point(painelLogin.Width / 4, painelLogin.Height / 2);
            txtSenha.Anchor = AnchorStyles.None;
            txtSenha.Text = "Senha";
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

            Controls.Add(painelLogin);
        }

        private void OnClickEntrar(object sender, EventArgs e)
        {
            string usuarioDigitado = txtUsuario.Text;
            string senhaDigitada = txtSenha.Text;

            controller.RealizarLogin();
        }


    }
}
