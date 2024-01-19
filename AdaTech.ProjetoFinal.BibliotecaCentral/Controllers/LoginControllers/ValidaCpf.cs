using System.Linq;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers
{
    public static class ValidaCpf
    {
        public static bool IsValid(string cpf)
        {
            cpf = new string(cpf.ToCharArray().Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
            {
                MessageBox.Show("CPF inválido! Digite novamente.");
                return false;
            }

            if (new string(cpf[0], cpf.Length) == cpf)
            {
                MessageBox.Show("CPF inválido! Digite novamente.");
                return false;
            }

            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            }

            int resto = soma % 11;
            int digitoVerificador1 = (resto < 2) ? 0 : 11 - resto;

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

            return int.Parse(cpf[10].ToString()) == digitoVerificador2;
        }
    }
}
