using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
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

        private static readonly string _DIRECTORY_PATH = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Data");
        private static readonly string _FILE_PATH = Path.Combine(_DIRECTORY_PATH, "Reservas.txt");

        static ReservaLivroData()
        {
            //_reservasLivros = LerReservasTxt();
        }

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

        internal static ReservaLivro SelecionarReserva (Emprestimo emprestimo)
        {
            if (emprestimo.ComunidadeAcademica.TipoUsuario == TipoUsuarioComunidade.Professor)
            {
                List<ReservaLivro> reservasUsuario = _reservasLivros.Item1.Where
                    (r => r.UsuarioComunidadeAcademica == emprestimo.ComunidadeAcademica).ToList();
                ReservaLivro reservaSelecionada = reservasUsuario
                    .FirstOrDefault(r => r.Emprestimo == emprestimo);
                return reservaSelecionada;
            }
            else if (emprestimo.ComunidadeAcademica.TipoUsuario == TipoUsuarioComunidade.Aluno)
            {
                List<ReservaLivro> reservasUsuario = _reservasLivros.Item2.Where
                    (r => r.UsuarioComunidadeAcademica == emprestimo.ComunidadeAcademica).ToList();
                ReservaLivro reservaSelecionada = reservasUsuario
                    .FirstOrDefault(r => r.Emprestimo == emprestimo);
                return reservaSelecionada;
            }
            else
            {
                throw new InvalidOperationException("Não foi possível encontrar a reserva.");
            }
        }

        internal static (List<ReservaLivro> professor, List<ReservaLivro> aluno) ListarReservasPorLivro(Livro livro)
        {
            List<ReservaLivro> reservasAluno = _reservasLivros.Item1.Where
                (r => r.Livro == livro).ToList();
            List<ReservaLivro> reservasProfessor = _reservasLivros.Item2.Where
                (r => r.Livro == livro).ToList();
            return (reservasAluno, reservasProfessor);
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
        internal static void AdicionarReserva(Emprestimo emprestimo)
        {
            if (emprestimo.ComunidadeAcademica.TipoUsuario == TipoUsuarioComunidade.Professor)
            {
                var numeroReserva = _reservasLivros.Item1.Count;
                _reservasLivros.Item1.Add(new ReservaLivro(emprestimo, numeroReserva));
            }
            else if (emprestimo.ComunidadeAcademica.TipoUsuario == TipoUsuarioComunidade.Aluno)
            {
                var numeroReserva = _reservasLivros.Item2.Count;
                _reservasLivros.Item2.Add(new ReservaLivro(emprestimo, numeroReserva));
            }
            else
            {
                throw new InvalidOperationException("Não foi possível adicionar a reserva.");
            }
        } 
        //internal static List<ReservaLivro> ListarReservasUsuario(Usuario usuario)
        //{


        //}
        //internal static void SelecionarReserva(ReservaLivro numeroReserva)
        //{

        //}
        //internal static void ExcluirReservas(ReservaLivro numeroReserva)
        //{

        //}

        //internal static Tuple<List<ReservaLivro>, List<ReservaLivro>> LerReservasTxt()
        //{
        //    List<ReservaLivro> reservasAluno = new List<ReservaLivro>();
        //    List<ReservaLivro> reservasProfessor = new List<ReservaLivro>();

        //    try
        //    {
        //        using (StreamReader sr = new StreamReader(_FILE_PATH))
        //        {
        //            while (!sr.EndOfStream)
        //            {
        //                string linha = sr.ReadLine();
        //                ReservaLivro reservaLivro = ConverterLinhaParaReservaLivro(linha);

        //                if (reservaLivro.UsuarioComunidadeAcademica.TipoUsuario == TipoUsuarioComunidade.Professor)
        //                {
        //                    reservasProfessor.Add(reservaLivro);
        //                }

        //                reservasAluno.Add(reservaLivro);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
        //    }

        //    return new Tuple<List<ReservaLivro>, List<ReservaLivro>>(reservasProfessor, reservasAluno);
        //}

        //internal static ReservaLivro ConverterLinhaParaReservaLivro(string linha)
        //{
        //    string[] partes = linha.Split(',');
        //    int numeroReserva = Conversores.StringParaInt(partes[0]);
        //    string partesLivro = string.Join(",", partes.Skip(1).Take(12));
        //    Livro livro = LivroData.ConverterLinhaParaLivro(partesLivro);
        //    string partesCA = string.Join(",", partes.Skip(13).Take(15));
        //    ComunidadeAcademica usuarioComunidadeAcademica = UsuarioData.ConverterLinhaParaComunidadeAcademica(partesCA);
        //    DateTime dataRetirada = Conversores.StringParaDateTime(partes[16]);
        //    DateTime dataReserva = Conversores.StringParaDateTime(partes[17]);
        //    StatusReserva statusReserva = Conversores.StringParaStatusReserva(partes[18]);

        //    // PRECISA COLOCAR STATUS RESERVA

        //    return new ReservaLivro(numeroReserva, livro, usuarioComunidadeAcademica, dataReserva);
        //}

        //internal static void SalvarReservaLivrosTxt(List<ReservaLivro> reservaLivros)
        //{
        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(_FILE_PATH))
        //        {
        //            foreach (ReservaLivro reserva in reservaLivros)
        //            {
        //                string linha = ConverterReservaLivroParaLinha(reserva);
        //                sw.WriteLine(linha);
        //            }
        //        }

        //        Console.WriteLine("Alterações salvas com sucesso no arquivo.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erro ao salvar as alterações no arquivo: {ex.Message}");
        //    }
        //}

        //internal static string ConverterReservaLivroParaLinha(ReservaLivro reservaLivro)
        //{
        //    return $"{reservaLivro.NumeroReserva},{LivroData.ConverterLivroParaLinha(reservaLivro.Livro)},{UsuarioData.ConverterComunidadeAcademicaParaLinha(reservaLivro.UsuarioComunidadeAcademica)},{reservaLivro.DataRetirarLivro},{reservaLivro.DataReserva},{reservaLivro.StatusReserva}";
        //}

    }
}
