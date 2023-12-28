using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosComunidadeAcademica;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva
{
    internal static class ReservaLivroData
    {
        private static Tuple<List<ReservaLivro>, List<ReservaLivro>> _reservasLivros;

        //internal static void AtualizarJsonResrvas() 
        //{

        //}
        internal static List<ReservaLivro> ListarReservasUsuario(ComunidadeAcademica usuario)
        {
            if (usuario.TipoUsuario == TipoUsuarioComunidade.Professor)
            {
                List<ReservaLivro> reservasUsuario = _reservasLivros.Item1.Where
                    (r => r.UsuarioComunidadeAcademica == usuario).ToList();
                return reservasUsuario;
            }
            else if (usuario.TipoUsuario == TipoUsuarioComunidade.Aluno)
            {
                List<ReservaLivro> reservasUsuario = _reservasLivros.Item2.Where
                    (r => r.UsuarioComunidadeAcademica == usuario).ToList();
                return reservasUsuario;
            }
            else
            {
                return null;
            }
        }
        internal static ReservaLivro SelecionarReserva(ReservaLivro reserva, ComunidadeAcademica usuario)
        {
            if (usuario.TipoUsuario == TipoUsuarioComunidade.Professor)
            {
                List<ReservaLivro> reservasUsuario = _reservasLivros.Item1.Where
                    (r => r.UsuarioComunidadeAcademica == usuario).ToList();
                ReservaLivro reservaSelecionada = reservasUsuario
                    .FirstOrDefault(r =>r.NumeroReserva == reserva.NumeroReserva);
                return reservaSelecionada;
            }
            else if (usuario.TipoUsuario == TipoUsuarioComunidade.Aluno)
            {
                List<ReservaLivro> reservasUsuario = _reservasLivros.Item2.Where
                    (r => r.UsuarioComunidadeAcademica == usuario).ToList();
                ReservaLivro reservaSelecionada = reservasUsuario
                    .FirstOrDefault(r => r.NumeroReserva == reserva.NumeroReserva);
                return reservaSelecionada;               
            }
            else
            {
                throw new InvalidOperationException("Não foi possível encontrar a reserva.");
            }
        }
        internal static void ExcluirReservas(ReservaLivro numeroReserva, ComunidadeAcademica usuario)
        {
            if (usuario.TipoUsuario == TipoUsuarioComunidade.Professor)
            {
                List<ReservaLivro> reservasUsuario = _reservasLivros.Item1.Where
                    (r => r.UsuarioComunidadeAcademica == usuario).ToList();
                ReservaLivro reservaSelecionada = reservasUsuario
                    .FirstOrDefault(r => r.NumeroReserva == numeroReserva.NumeroReserva);
                reservasUsuario.Remove(reservaSelecionada);
            }
            else if (usuario.TipoUsuario == TipoUsuarioComunidade.Aluno)
            {
                List<ReservaLivro> reservasUsuario = _reservasLivros.Item2.Where
                    (r => r.UsuarioComunidadeAcademica == usuario).ToList();
                ReservaLivro reservaSelecionada = reservasUsuario
                    .FirstOrDefault(r => r.NumeroReserva == numeroReserva.NumeroReserva);
                reservasUsuario.Remove(reservaSelecionada);
            }
            else
            {
                throw new InvalidOperationException("Não foi possível excluir a reserva.");
            }   
        }
        internal static void AdicionarReserva(Livro livro, ComunidadeAcademica usuarioComunidadeAcademica,
            DateTime dataRetirarLivro, DateTime dataReserva)
        {
            if (usuarioComunidadeAcademica.TipoUsuario == TipoUsuarioComunidade.Professor)
            {
                var numeroReserva = _reservasLivros.Item1.Count;
                _reservasLivros.Item1.Add(new ReservaLivro(numeroReserva, livro, usuarioComunidadeAcademica, dataRetirarLivro, dataReserva));
            }
            else if (usuarioComunidadeAcademica.TipoUsuario == TipoUsuarioComunidade.Aluno)
            {
                var numeroReserva = _reservasLivros.Item2.Count;
                _reservasLivros.Item1.Add(new ReservaLivro(numeroReserva, livro, usuarioComunidadeAcademica, dataRetirarLivro, dataReserva));
            }
            else
            {
                throw new InvalidOperationException("Não foi possível adicionar a reserva.");
            }
        } 
    }
}
