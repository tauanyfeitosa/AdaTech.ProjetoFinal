using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
using System;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Utilities
{
    public static class Conversores
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

        public static DateTime StringParaDateTime(string dataString)
        {
            if (DateTime.TryParse(dataString, out DateTime data))
            {
                return data;
            }
            else
            {
                throw new ArgumentException("Formato de data inválido");
            }
        }

        public static StatusReserva StringParaStatusReserva(string statusString)
        {
            if (Enum.TryParse<StatusReserva>(statusString, out StatusReserva statusReserva))
            {
                return statusReserva;
            }
            else
            {
                throw new ArgumentException("Valor de status inválido");
            }
        }

        public static bool StringParaBool(string valor)
        {
            if (bool.TryParse(valor, out bool resultado))
            {
                return resultado;
            }
            else
            {
                throw new ArgumentException("Valor de string não é válido para booleano");
            }
        }

        public static decimal StringParaDecimal(string valorString)
        {
            if (decimal.TryParse(valorString, out decimal resultado))
            {
                return resultado;
            }
            else
            {
                throw new ArgumentException("Valor de string não é válido para decimal");
            }
        }

        internal static TipoUsuarioComunidade StringParaTipoUsuarioComunidade(string valor)
        {
            try
            {
                TipoUsuarioComunidade TipoUsuarioComunidade = (TipoUsuarioComunidade)Enum.Parse(typeof(TipoUsuarioComunidade), valor);
                return TipoUsuarioComunidade;
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"A string '{valor}' não corresponde a nenhum valor do enum TipoAcervoLivro.");
                throw new ArgumentException();
            }
        }
    }
}
