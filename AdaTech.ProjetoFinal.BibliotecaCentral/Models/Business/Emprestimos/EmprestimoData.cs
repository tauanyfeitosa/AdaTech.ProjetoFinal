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

        //internal static List<Emprestimo> LerEmprestimosTxt()
        //{
        //    List<Emprestimo> emprestimos = new List<Emprestimo>();

        //    try
        //    {
        //        using (StreamReader sr = new StreamReader(_FILE_PATH))
        //        {
        //            while (!sr.EndOfStream)
        //            {
        //                string linha = sr.ReadLine();
        //                Emprestimo emprestimo = ConverterLinhaParaEmprestimo(linha);
        //                emprestimos.Add(emprestimo);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
        //    }

        //    return emprestimos;
        //}

        //internal static Emprestimo ConverterLinhaParaEmprestimo(string linha)
        //{
        //    string[] partes = linha.Split(',');
        //    string partesReserva = string.Join(",", partes.Skip(0).Take(18));
        //    ReservaLivro reservaLivro = ReservaLivroData.ConverterLinhaParaReservaLivro(partesReserva);
        //    string partesLivro = string.Join(",", partes.Skip(19).Take(29));
        //    Livro livro = LivroData.ConverterLinhaParaLivro(partesLivro);
        //    string partesCA = string.Join(",", partes.Skip(30).Take(32));
        //    ComunidadeAcademica userCA = UsuarioData.ConverterLinhaParaComunidadeAcademica(partesCA);

        //    return new Emprestimo(reservaLivro,livro, userCA);
        //} 

        //internal static void SalvarEmprestimosTxt(List<Emprestimo> emprestimos)
        //{
        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(_FILE_PATH))
        //        {
        //            foreach (Emprestimo emprestimo in emprestimos)
        //            {
        //                string linha = ConverterEmprestimoParaLinha(emprestimo);
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

        //internal static string ConverterEmprestimoParaLinha(Emprestimo emprestimo)
        //{
        //    string reservaLivroLinha = ReservaLivroData.ConverterReservaLivroParaLinha(emprestimo.ReservaLivro);
        //    string livroLinha = LivroData.ConverterLivroParaLinha(emprestimo.Livro);
        //    string usuarioComunidadeAcademicaLinha = UsuarioData.ConverterComunidadeAcademicaParaLinha(emprestimo.ComunidadeAcademica);

        //    return $"{reservaLivroLinha},{livroLinha},{usuarioComunidadeAcademicaLinha},{emprestimo.DataEmprestimo},{emprestimo.DataDevolucaoPrevista},{emprestimo.DataDevolucaoUsuario},{emprestimo.Devolucao}";
        //}

    }
}
