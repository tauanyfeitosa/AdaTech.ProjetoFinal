using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos
{
    using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
    using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
    using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
    using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Utilities;
    using System.IO;
    using System.Runtime.ConstrainedExecution;
    using System.Windows.Forms;
    using Usuarios.UsuariosComunidadeAcademica;
    internal class EmprestimoData
    {
        private static List<Emprestimo> _emprestimoLivros;

        private static readonly string _DIRECTORY_PATH = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Data");
        private static readonly string _FILE_PATH = Path.Combine(_DIRECTORY_PATH, "Emprestimo.txt");

        internal static List<Emprestimo> EmprestimoLivros { get => _emprestimoLivros;}

        static EmprestimoData()
        {
            _emprestimoLivros = new List<Emprestimo>();
            LerEmprestimosTxt();
        }

        //internal List<Emprestimo> SelecionarEmprestimo(ComunidadeAcademica usuario)
        //{

        //}
        //internal List<Emprestimo> SelecionarEmprestimo(Emprestimo emprestimos)
        //{

        //}

        internal static Emprestimo AdicionarEmprestimo(Emprestimo emprestimo)
        {       
            if (!_emprestimoLivros.Contains(emprestimo))
            {
                _emprestimoLivros.Add(emprestimo);
                SalvarEmprestimosTxt(_emprestimoLivros);
            }
            else
            {
                throw new InvalidOperationException("O empréstimo já existe.");
            }

            return emprestimo;
        }

        internal static void IncluirEmprestimos(List<Emprestimo> emprestimosParaAdd)
        {
            _emprestimoLivros.AddRange(emprestimosParaAdd);
            SalvarEmprestimosTxt(_emprestimoLivros);
        }


        internal static List<Emprestimo> SelecionarEmprestimo(Livro livro)
        {
            return _emprestimoLivros.Where(e => e.Livro == livro).ToList();
        }

        internal static List<Emprestimo> SelecionarEmprestimo(ComunidadeAcademica usuario)
        {
            return _emprestimoLivros.Where(e => e.ComunidadeAcademica == usuario).ToList();
        }

        internal static List<Emprestimo> SelecionarEmprestimo(ReservaLivro reserva)
        {
            return _emprestimoLivros.Where(e => e.ReservaLivro == reserva).ToList();
        }

        internal static void LerEmprestimosTxt()
        {

            try
            {
                using (StreamReader sr = new StreamReader(_FILE_PATH))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        Emprestimo emprestimo = ConverterLinhaParaEmprestimo(linha);
                        _emprestimoLivros.Add(emprestimo);
                        _emprestimoLivros.Count();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao ler o arquivo: {ex.Message}");
            }

        }

        internal static Emprestimo ConverterLinhaParaEmprestimo(string linha)
        {
            string[] partes = linha.Split(',');

            string titulo = partes[0];
            string autor = partes[1];
            string isbn = partes[2];
            int anoPublicacao = Conversores.StringParaInt(partes[3]);
            int edicao = Conversores.StringParaInt(partes[4]);
            string editora = partes[5];
            int exemplares = Conversores.StringParaInt(partes[6]);
            int exemplaresDisponiveis = Conversores.StringParaInt(partes[7]);
            int livrosBomEstado = Conversores.StringParaInt(partes[8]);
            int livrosEstadoMediano = Conversores.StringParaInt(partes[9]);
            int livrosMauEstado = Conversores.StringParaInt(partes[10]);
            TipoAcervoLivro tipoAcervoLivro = Conversores.StringParaTipoAcervoLivro(partes[11]);

            var livro = new Livro(titulo, autor, isbn, anoPublicacao, edicao, editora, exemplares, exemplaresDisponiveis, livrosBomEstado, livrosEstadoMediano, livrosMauEstado, tipoAcervoLivro);

            string senha = partes[12];
            string nomeCompleto = partes[13];
            string cpf = partes[14];
            string email = partes[15];
            string matricula = partes[16];
            string curso = partes[17];
            TipoUsuarioComunidade tipoUsuario = Conversores.StringParaTipoUsuarioComunidade(partes[18]);

            var usuarioCA = new ComunidadeAcademica(senha, nomeCompleto, cpf, email, matricula, curso, tipoUsuario);

            return new Emprestimo(null, livro, usuarioCA);         
        }


        internal static void SalvarEmprestimosTxt(List<Emprestimo> emprestimos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_FILE_PATH))
                {
                    foreach (Emprestimo emprestimo in emprestimos)
                    {
                        string linha = ConverterEmprestimoParaLinha(emprestimo);
                        sw.WriteLine(linha);
                    }
                }

                MessageBox.Show("Alterações salvas com sucesso no arquivo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show$"Erro ao salvar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static string ConverterEmprestimoParaLinha(Emprestimo emprestimo)
        {
            string livroLinha = LivroData.ConverterLivroParaLinha(emprestimo.Livro);
            string usuarioComunidadeAcademicaLinha = UsuarioData.ConverterComunidadeAcademicaParaLinha(emprestimo.ComunidadeAcademica);

            return $"{livroLinha},{usuarioComunidadeAcademicaLinha}";
        }

    }
}
