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
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva
{
    internal static class ReservaLivroData
    {
        private static Tuple<List<ReservaLivro>, List<ReservaLivro>> _reservasLivros;

        private static readonly string _DIRECTORY_PATH = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Data");
        private static readonly string _FILE_PATH = Path.Combine(_DIRECTORY_PATH, "Reservas.txt");

        //static ReservaLivroData()
        //{
        //    _reservasLivros = new Tuple<List<ReservaLivro>, List<ReservaLivro>>(new List<ReservaLivro>(), new List<ReservaLivro>());
        //    LerReservasTxt();
        //}

        internal static void CarregarReservas()
        {
            _reservasLivros = new Tuple<List<ReservaLivro>, List<ReservaLivro>>(new List<ReservaLivro>(), new List<ReservaLivro>());
            LerReservasTxt();
        }

        internal static Tuple<List<ReservaLivro>, List<ReservaLivro>> GetReservaLivros()
        {
            return _reservasLivros;
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

        internal static List<ReservaLivro> ListarReservasAprovadas(DateTime data)
        {
            List<ReservaLivro> reservaProfessor = _reservasLivros.Item1
                .Where(r => r.StatusReserva == StatusReserva.Aprovada && r.DataRetirarLivro.Date == data.Date)
                .ToList();
            List<ReservaLivro> reservaAluno = _reservasLivros.Item2.Where
                (r => r.StatusReserva == StatusReserva.Aprovada && r.DataRetirarLivro.Date == data.Date)
                .ToList();
            List<ReservaLivro> reservasAprovadas = new List<ReservaLivro>();
            reservasAprovadas.AddRange(reservaProfessor);
            reservasAprovadas.AddRange(reservaAluno);
            return reservasAprovadas;
        }


        internal static List<ReservaLivro> ListarTodasReservas()
        {
            List<ReservaLivro> reservasUsuarios = new List<ReservaLivro>();

            if (_reservasLivros != null && _reservasLivros.Item1 != null && _reservasLivros.Item2 != null)
            {
                reservasUsuarios.AddRange(_reservasLivros.Item1);
                reservasUsuarios.AddRange(_reservasLivros.Item2);
            }

            return reservasUsuarios;
        }

        internal static ReservaLivro SelecionarReserva(ReservaLivro reserva, ComunidadeAcademica usuario)
        {
            if (usuario.TipoUsuario == TipoUsuarioComunidade.Professor)
            {
                List<ReservaLivro> reservasUsuario = _reservasLivros.Item1.Where
                    (r => r.UsuarioComunidadeAcademica == usuario).ToList();
                ReservaLivro reservaSelecionada = reservasUsuario
                    .FirstOrDefault(r => r.NumeroReserva == reserva.NumeroReserva);
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

        internal static ReservaLivro SelecionarReserva(Emprestimo emprestimo)
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

        internal static void AdicionarReserva(ReservaLivro reserva)
        {
            if (reserva != null)
            {
                if (reserva.UsuarioComunidadeAcademica.TipoUsuario == TipoUsuarioComunidade.Professor)
                {
                    var numeroReserva = _reservasLivros.Item1.Count;
                    reserva.NumeroReserva = numeroReserva;
                    _reservasLivros.Item1.Add(reserva);
                }
                else if (reserva.UsuarioComunidadeAcademica.TipoUsuario == TipoUsuarioComunidade.Aluno)
                {
                    var numeroReserva = _reservasLivros.Item2.Count;
                    reserva.NumeroReserva = numeroReserva;
                    _reservasLivros.Item2.Add(reserva);
                }
            }
            else
            {
                throw new InvalidOperationException("Não foi possível adicionar a reserva.");
            }
        }


        /*
        internal static List<ReservaLivro> ListarReservasUsuario(Usuario usuario)
        {


        }
        internal static void SelecionarReserva(ReservaLivro numeroReserva)
        {

        }
        internal static void ExcluirReservas(ReservaLivro numeroReserva)
        {

        } */

        internal static void LerReservasTxt()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_FILE_PATH))
                {
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            string linha = sr.ReadLine();
                            ConverterLinhaParaReservaLivro(linha);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao ler o arquivo: {ex.Message}");
            }
        }

        internal static void ConverterLinhaParaReservaLivro(string linha)
        {

            string[] partes = linha.Split(',');

            string idEmprestimo = partes[0];
            string idUsuario = partes[1];

            Emprestimo emprestimo = EmprestimoData.SelecionarEmprestimo(idEmprestimo);
            ComunidadeAcademica usuarioCA = UsuarioData.SelecionarUsuarioCA(idUsuario);
            bool Conversao = DateTime.TryParse(partes[2], out DateTime DataReserva);

            var reserva = new ReservaLivro(emprestimo, usuarioCA);
            
            if (Conversao) reserva.DataReserva = DataReserva;
          
            if (partes.Length > 3)
            {
                DateTime dataRetirar = DateTime.Parse(partes[3]);
                reserva.DataRetirarLivro = dataRetirar;
            }
            
            AdicionarReserva(reserva); 
        }

        internal static void SalvarReservaLivrosTxt()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_FILE_PATH))
                {
                    foreach (ReservaLivro reserva in _reservasLivros.Item1)
                    {
                        string linha = ConverterReservaLivroParaLinha(reserva);
                        sw.WriteLine(linha);
                    }

                    foreach (ReservaLivro reserva in _reservasLivros.Item2)
                    {
                        string linha = ConverterReservaLivroParaLinha(reserva);
                        sw.WriteLine(linha);
                    }
                }

                MessageBox.Show("Alterações salvas com sucesso no arquivo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static string ConverterReservaLivroParaLinha(ReservaLivro reservaLivro)
        {
            if (reservaLivro.DataRetirarLivro != DateTime.MinValue)
            {
                return $"{reservaLivro.Emprestimo.IdEmprestimo},{reservaLivro.UsuarioComunidadeAcademica.Cpf},{reservaLivro.DataReserva},{reservaLivro.DataRetirarLivro.Date.ToString("yyyy-MM-dd")}";
            }
            return $"{reservaLivro.Emprestimo.IdEmprestimo},{reservaLivro.UsuarioComunidadeAcademica.Cpf},{reservaLivro.DataReserva}";
        }

    }
}
