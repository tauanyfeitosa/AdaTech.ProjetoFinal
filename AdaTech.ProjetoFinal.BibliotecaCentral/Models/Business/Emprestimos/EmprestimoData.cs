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
        private static readonly string FILE_PATH = "../../../Data/Emprestimo.txt";

        static EmprestimoData()
        {
            _emprestimoLivros = LerEmprestimosTxt();
        }

        //internal List<Emprestimo> SelecionarEmprestimo(ComunidadeAcademica usuario)
        //{

        //}
        //internal List<Emprestimo> SelecionarEmprestimo(Emprestimo emprestimos)
        //{

        //}

        internal static List<Emprestimo> LerEmprestimosTxt()
        {
            List<Emprestimo> emprestimos = new List<Emprestimo>();

            try
            {
                using (StreamReader sr = new StreamReader(FILE_PATH))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        Emprestimo emprestimo = ConverterLinhaParaEmprestimo(linha);
                        emprestimos.Add(emprestimo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
            }

            return emprestimos;
        }

        private static Emprestimo ConverterLinhaParaEmprestimo(string linha)
        {
            string[] partes = linha.Split(',');
            string partesReserva = string.Join(",", partes.Skip(0).Take(18));
            ReservaLivro reservaLivro = ReservaLivroData.ConverterLinhaParaReservaLivro(partesReserva);
            string partesLivro = string.Join(",", partes.Skip(19).Take(29));
            Livro livro = LivroData.ConverterLinhaParaLivro(partesLivro);
            string partesCA = string.Join(",", partes.Skip(30).Take(32));
            ComunidadeAcademica userCA = UsuarioData.ConverterLinhaParaComunidadeAcademica(partesCA);
            DateTime dataEmprestimo = Conversores.StringParaDateTime(partes[33]);
            DateTime dataDevPrevista = Conversores.StringParaDateTime(partes[34]);
            DateTime dataDevUsuario = Conversores.StringParaDateTime(partes[35]);
            bool devolucao = Conversores.StringParaBool(partes[36]);
            string partesMulta = string.Join(",", partes.Skip(37).Take(40));
            Multa multaAtraso = ConverterLinhaParaMulta(partesMulta);

            return new Emprestimo(reservaLivro, livro, userCA, dataEmprestimo, dataDevPrevista, dataDevUsuario, devolucao, multaAtraso);
        } 

        internal static void SalvarEmprestimosTxt(List<Emprestimo> emprestimos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FILE_PATH))
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
            string reservaLivroLinha = ReservaLivroData.ConverterReservaLivroParaLinha(emprestimo.ReservaLivro);
            string livroLinha = LivroData.ConverterLivroParaLinha(emprestimo.Livro);
            string usuarioComunidadeAcademicaLinha = UsuarioData.ConverterComunidadeAcademicaParaLinha(emprestimo.ComunidadeAcademica);
            string multaAtrasoLinha = ConverterMultaParaLinha(emprestimo.Multa);

            return $"{reservaLivroLinha},{livroLinha},{usuarioComunidadeAcademicaLinha},{emprestimo.DataEmprestimo},{emprestimo.DataDevolucaoPrevista},{emprestimo.DataDevolucaoUsuario},{emprestimo.Devolucao},{multaAtrasoLinha}";
        }


        internal static Multa ConverterLinhaParaMulta(string linha)
        {
            string[] partes = linha.Split(',');
            decimal multas = Conversores.StringParaDecimal(partes[0]);
            decimal multaDiaria = Conversores.StringParaDecimal(partes[1]);
            decimal multaMauEstado = Conversores.StringParaDecimal(partes[2]);
            bool pagamentoMulta = Conversores.StringParaBool(partes[3]);

            return new Multa(multas, multaDiaria, multaMauEstado, pagamentoMulta);
        }

        internal static string ConverterMultaParaLinha(Multa multa)
        {
            return $"{multa.Multas},{multa.MultaDiaria},{multa.MultaMauEstado},{multa.PagamentoMulta}";
        }

    }
}
