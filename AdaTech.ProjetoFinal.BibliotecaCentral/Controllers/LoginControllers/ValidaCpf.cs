using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers
{
    public static class ValidaCpf
    {
        public static bool IsValid(string cpf)
        {
            // Remover caracteres não numéricos
            cpf = new string(cpf.ToCharArray().Where(char.IsDigit).ToArray());

            // Verificar se o CPF tem 11 dígitos
            if (cpf.Length != 11)
            {
                MessageBox.Show("CPF inválido! Digite novamente.");
                return false;
            }

            // Verificar se todos os dígitos são iguais (ex: 111.111.111-11)
            if (new string(cpf[0], cpf.Length) == cpf)
            {
                MessageBox.Show("CPF inválido! Digite novamente.");
                return false;
            }

            // Calcular o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            }

            int resto = soma % 11;
            int digitoVerificador1 = (resto < 2) ? 0 : 11 - resto;

            // Verificar o primeiro dígito verificador
            if (int.Parse(cpf[9].ToString()) != digitoVerificador1)
            {
                MessageBox.Show("CPF inválido! Digite novamente.");
                return false;
            }

            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            }

            resto = soma % 11;
            int digitoVerificador2 = (resto < 2) ? 0 : 11 - resto;

            // Verificar o segundo dígito verificador
            return int.Parse(cpf[10].ToString()) == digitoVerificador2;
        }
    }
}
