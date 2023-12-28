using System;
using System.Linq;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers
{
	public static class ValidaSenha
	{
		public static bool IsValid(string senha)
		{
            if (senha.Length < 8 && senha.Length > 16)
            {
                MessageBox.Show("A senha deve conter entre 8 e 16 caractéres");
                return false;
            }

            if (!senha.Any(char.IsUpper))
            {
                MessageBox.Show("A senha deve conter pelo menos uma letra MAIÚSCULA");
                return false;
            }

            if (!senha.Any(char.IsLower))
            {
                MessageBox.Show("A senha deve conter pelo menos uma letra minúscula");
                return false;
            }

            if (!senha.Any(char.IsDigit))
            {
                MessageBox.Show("A senha deve conter pelo menos um número");
                return false;
            }

            return true;
        
        }
	}
}

