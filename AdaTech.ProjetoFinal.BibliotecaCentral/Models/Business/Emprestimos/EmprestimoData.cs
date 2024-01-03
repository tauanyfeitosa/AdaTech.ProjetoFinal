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
        private static List<Emprestimo> _emprestimoLivros = new List<Emprestimo>();

        private static readonly string _DIRECTORY_PATH = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Data");
        private static readonly string _FILE_PATH = Path.Combine(_DIRECTORY_PATH, "Emprestimo.txt");

        internal static List<Emprestimo> EmprestimoLivros { get => _emprestimoLivros;}

        static EmprestimoData()
        {
            //_emprestimoLivros = LerEmprestimosTxt();
        }

        //internal List<Emprestimo> SelecionarEmprestimo(ComunidadeAcademica usuario)
        //{

        //}
        //internal List<Emprestimo> SelecionarEmprestimo(Emprestimo emprestimos)
        //{

        //}

        internal static Emprestimo AdicionarEmprestimo(Livro livro, ComunidadeAcademica usuarioComunidadeAcademica)
        {       
            var emprestimo = new Emprestimo(null, livro, usuarioComunidadeAcademica);
            if (_emprestimoLivros.Contains(emprestimo))
            {
                _emprestimoLivros.Add(emprestimo);
            }
            else
            {
                throw new InvalidOperationException("O empréstimo já existe.");
            }

            return emprestimo;
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

        internal static List<Emprestimo> LerEmprestimosTxt()
        {
            List<Emprestimo> emprestimos = new List<Emprestimo>();

            try
            {
                using (StreamReader sr = new StreamReader(_FILE_PATH))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        Emprestimo emprestimo = ConverterLinhaParaEmprestimo(linha);
                        _emprestimoLivros.Add(emprestimo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
            }

            return emprestimos;
        }

        internal static Emprestimo ConverterLinhaParaEmprestimo(string linha)
        {
            string[] partes = linha.Split(',');

            //LIVRO
            string partesLivro = string.Join(",", partes.Take(11));
            Livro livro = LivroData.AdicionarLivro(LivroData.ConverterLinhaParaLivro(partesLivro));


            // USER CA
            string partesCA = string.Join(",", partes.Skip(12).Take(14));
            ComunidadeAcademica usuarioCA = UsuarioData.AdicionarCA(UsuarioData.ConverterLinhaParaComunidadeAcademica(partesCA));

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

                Console.WriteLine("Alterações salvas com sucesso no arquivo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar as alterações no arquivo: {ex.Message}");
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
