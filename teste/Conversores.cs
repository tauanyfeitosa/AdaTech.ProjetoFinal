using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste
{
    internal static class Conversores
    {
        public static int StringParaInt(string valor)
        {
            int resultado;

            if (int.TryParse(valor, out resultado))
            {
                return resultado;
            }
            else
            {
                Console.WriteLine($"Não foi possível converter a string '{valor}' para um número inteiro.");
                return 0;
            }
        }

        public static TipoAcervoLivro StringParaTipoAcervoLivro(string valor)
        {
            try
            {
                TipoAcervoLivro tipoAcervoLivro = (TipoAcervoLivro)Enum.Parse(typeof(TipoAcervoLivro), valor);
                return tipoAcervoLivro;
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"A string '{valor}' não corresponde a nenhum valor do enum TipoAcervoLivro.");
                throw new ArgumentException();
            }
        }
    }
}
