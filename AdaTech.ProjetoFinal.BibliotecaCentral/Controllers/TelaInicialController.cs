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
            if (_telaLogin.TxtUsuario.Text == "admin" && _telaLogin.TxtSenha.Text == "senha")
            {
                MessageBox.Show("Login efetuado com sucesso!");
                _telaLogin.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!");
            }
        }
    }
}
