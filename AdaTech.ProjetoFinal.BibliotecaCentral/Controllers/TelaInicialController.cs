﻿using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers
{
    internal class TelaInicialController
    {
        private readonly TelaLogin _telaLogin;

        internal TelaInicialController(TelaLogin telaLogin)
        {
            _telaLogin = telaLogin;
        }

        internal void RealizarLogin()
        {
            try
            {
                if (_telaLogin.TxtUsuario.Text != null && _telaLogin.TxtUsuario.Text == UsuarioData.SelecionarUsuario(_telaLogin.TxtUsuario.Text).Login)
                {
                    if (UsuarioData.SelecionarUsuario(_telaLogin.TxtUsuario.Text).FazerLogin(_telaLogin.TxtUsuario.Text, _telaLogin.TxtSenha.Text))
                    {
                        MessageBox.Show("Login realizado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Senha incorreta!");
                    }
                } else
                {
                    throw new Exception();
                }
            } catch (Exception e)
            {
                MessageBox.Show("Usuário não encontrado!");
            }
        }
    }
}
