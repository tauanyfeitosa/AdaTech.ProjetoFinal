using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers
{
	public static class ValidaMatricula
	{
		public static bool IsValidAluno(string matricula)
		{
            matricula = new string(matricula.ToCharArray().Where(char.IsDigit).ToArray());

            if (matricula.Length != 12)
            {
                MessageBox.Show("Matrícula inválida! Digite novamente.");
                return false;
            }

            // Verificar se os 4 primeiros dígitos são um ano
            int ano;
            if (!int.TryParse(matricula.Substring(0, 4), out ano))
            {
                MessageBox.Show("Matrícula inválida! Digite novamente.");
                return false;
            }

            // Verificar se o ano não é um ano futuro ou de no máximo 8 anos atrás
            int anoAtual = DateTime.Now.Year;
            if (ano > anoAtual || (anoAtual - ano) > 8)
            {
                MessageBox.Show("Matrícula inválida! Digite novamente.");
                return false;
            }

            // Verificar se os dois dígitos seguintes são zero
            if (matricula.Substring(4, 2) != "00")
            {
                MessageBox.Show("Matrícula inválida! Digite novamente.");
                return false;
            }

            // Verificar se os dígitos seguintes não são todos iguais
            string restante = matricula.Substring(6, 6);
            if (restante.Distinct().Count() == 1)
            {
                MessageBox.Show("Matrícula inválida! Digite novamente.");
                return false;
            }

            return true;
        }

        public static bool IsValidProfessor(string matricula)
        {
            matricula = new string(matricula.ToCharArray().Where(char.IsDigit).ToArray());

            if (matricula.Length != 12)
            {
                MessageBox.Show("Matrícula inválida! Digite novamente.");
                return false;
            }

            // Verificar se os 4 primeiros dígitos são um ano
            int ano;
            if (!int.TryParse(matricula.Substring(0, 4), out ano))
            {
                MessageBox.Show("Matrícula inválida! Digite novamente.");
                return false;
            }

            // Verificar se o ano não é um ano futuro
            int anoAtual = DateTime.Now.Year;
            if (ano > anoAtual)
            {
                MessageBox.Show("Matrícula inválida! Digite novamente.");
                return false;
            }

            // Verificar se os dois dígitos seguintes são zero
            if (matricula.Substring(4, 2) != "00")
            {
                MessageBox.Show("Matrícula inválida! Digite novamente.");
                return false;
            }    

            // Verificar se os dígitos seguintes não são todos iguais
            string restante = matricula.Substring(6, 6);
            if (restante.Distinct().Count() == 1)
            {
                MessageBox.Show("Matrícula inválida! Digite novamente.");
                return false;
            }

            return true;
        }
    }

}
