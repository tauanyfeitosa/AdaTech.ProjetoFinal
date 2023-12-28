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

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva
{
    internal static class ReservaLivroData
    {
        private static Tuple<List<ReservaLivro>, List<ReservaLivro>> _reservasLivros;
        private static readonly string FILE_PATH = "../../../Data/Reservas.txt";

        static ReservaLivroData()
        {
            _reservasLivros = LerReservasTxt();
        }

        //internal static void AtualizarJsonResrvas()
        //{

        //}
        //internal static List<ReservaLivro> ListarReservasUsuario(Usuario usuario)
        //{


        //}
        //internal static void SelecionarReserva(ReservaLivro numeroReserva)
        //{

        //}
        //internal static void ExcluirReservas(ReservaLivro numeroReserva)
        //{

        //}

        internal static Tuple<List<ReservaLivro>, List<ReservaLivro>> LerReservasTxt()
        {
            List<ReservaLivro> reservasAluno = new List<ReservaLivro>();
            List<ReservaLivro> reservasProfessor = new List<ReservaLivro>();

            try
            {
                using (StreamReader sr = new StreamReader(FILE_PATH))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        ReservaLivro reservaLivro = ConverterLinhaParaReservaLivro(linha);

                        if (reservaLivro.UsuarioComunidadeAcademica.TipoUsuario == TipoUsuarioComunidade.Professor)
                        {
                            reservasProfessor.Add(reservaLivro);
                        }

                        reservasAluno.Add(reservaLivro);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
            }

            return new Tuple<List<ReservaLivro>, List<ReservaLivro>>(reservasProfessor, reservasAluno);
        }

        internal static ReservaLivro ConverterLinhaParaReservaLivro(string linha)
        {
            string[] partes = linha.Split(',');
            int numeroReserva = Conversores.StringParaInt(partes[0]);
            string partesLivro = string.Join(",", partes.Skip(1).Take(12));
            Livro livro = LivroData.ConverterLinhaParaLivro(partesLivro);
            string partesCA = string.Join(",", partes.Skip(13).Take(15));
            ComunidadeAcademica usuarioComunidadeAcademica = UsuarioData.ConverterLinhaParaComunidadeAcademica(partesCA);
            DateTime dataRetirada = Conversores.StringParaDateTime(partes[16]);
            DateTime dataReserva = Conversores.StringParaDateTime(partes[17]);
            StatusReserva statusReserva = Conversores.StringParaStatusReserva(partes[18]);

            return new ReservaLivro(numeroReserva, livro, usuarioComunidadeAcademica, dataRetirada, dataReserva, statusReserva);
    }

        internal static void SalvarReservaLivrosTxt(List<ReservaLivro> reservaLivros)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FILE_PATH))
                {
                    foreach (ReservaLivro reserva in reservaLivros)
                    {
                        string linha = ConverterReservaLivroParaLinha(reserva);
                        sw.WriteLine(linha);
                    }
                }

                Console.WriteLine("Alterações salvas com sucesso no arquivo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static string ConverterReservaLivroParaLinha(ReservaLivro reservaLivro)
        {
            return $"{reservaLivro.NumeroReserva},{LivroData.ConverterLivroParaLinha(reservaLivro.Livro)},{UsuarioData.ConverterComunidadeAcademicaParaLinha(reservaLivro.UsuarioComunidadeAcademica)},{reservaLivro.DataRetirarLivro},{reservaLivro.DataReserva},{reservaLivro.StatusReserva}";
        }

    }
}
