using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva
{
    internal static class ReservaLivroData
    {
        private static Tuple<List<ReservaLivro>, List<ReservaLivro>> _reservasLivros;

        //internal static void AtualizarJsonResrvas() 
        //{

        //}
        internal static List<ReservaLivro> ListarReservasUsuario(Usuario usuario)
        {
            List<ReservaLivro> reservasUsuario = _reservasLivros.Item1.Where
                (r => r.UsuarioComunidadeAcademica == usuario).ToList();
            return reservasUsuario;
        }       
        
        internal static void SelecionarReserva(ReservaLivro numeroReserva)
        {
            //esse eu não sei o que faz T.T
        }
        internal static void ExcluirReservas(ReservaLivro numeroReserva)
        {
           _reservasLivros.Item1.Remove(numeroReserva);
        }
        internal static void AdicionarReserva(ReservaLivro reserva)
        {
            _reservasLivros.Item1.Add(reserva);
        }
    }
}
