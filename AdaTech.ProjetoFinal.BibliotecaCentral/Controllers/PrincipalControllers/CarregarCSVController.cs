using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers
{
    internal class CarregarCSVController
    {
        internal static void CarregarCSVComunidadeAcademica(string caminhoArquivoCSV, string caminhoArquivoTxt)
        {
            try
            {
                List<ComunidadeAcademica> comunidadesAcademicas = new List<ComunidadeAcademica>();
                List<string> usuariosFaltantes = new List<string>();

                string[] linhasTxt = File.Exists(caminhoArquivoTxt) ? File.ReadAllLines(caminhoArquivoTxt) : new string[0];

                string[] linhasCSV = File.ReadAllLines(caminhoArquivoCSV);

                foreach (string linhaCSV in linhasCSV)
                {
                    string[] valoresCSV = linhaCSV.Split(',');

                    bool linhaExistente = linhasTxt.Any(l => l.Split(',')[2] == valoresCSV[2] || // CPF
                                                            l.Split(',')[3] == valoresCSV[3] || // E-mail
                                                            l.Split(',')[4] == valoresCSV[4]);  // Matrícula

                    if (!linhaExistente)
                    {
                        var comunidadeAcademica = UsuarioData.ConverterLinhaParaComunidadeAcademica(linhaCSV);
                        comunidadesAcademicas.Add(comunidadeAcademica);
                        continue;
                    }

                    usuariosFaltantes.Add(valoresCSV[1]);
                }

                if (usuariosFaltantes != null && usuariosFaltantes.Count > 0)
                {
                    MessageBox.Show($"Usuários não carregados pois já existem no sistema: {string.Join(",", usuariosFaltantes)}");
                }

                UsuarioData.SalvarComunidadeAcademicaTxt(comunidadesAcademicas);

            }
            catch
            {
                MessageBox.Show("Erro ao carregar arquivo CSV. Verifique se está no formato correto: senha, nomeCompleto, cpf, email, matricula, curso, tipoUsuario");
            }
        }

        internal static void CarregarCSVLivro(string caminhoDoArquivoCSV)
        {
            try
            {
                List<Livro> livrosParaAdd = new List<Livro>();

                string[] linhasCSV = File.ReadAllLines(caminhoDoArquivoCSV);

                foreach (string linhaCSV in linhasCSV)
                {
                    string[] valoresCSV = linhaCSV.Split(',');

                    var linhaString = string.Join(",", valoresCSV);

                    var Livro = LivroData.ConverterLinhaParaLivro(linhaString);

                    livrosParaAdd.Add(Livro);

                }

                MessageBox.Show($"Num livros: {livrosParaAdd.Count} \n");

                LivroData.IncluirLivros(livrosParaAdd);

            }
            catch
            {
                MessageBox.Show("Erro ao carregar arquivo CSV. Verifique se está no formato correto: titulo, autor, isbn, anoPublicacao, edicao, editora, exemplares, exemplaresDisponiveis, livrosBomEstado, livrosEstadoMediano, livrosMauEstado, tipoAcervoLivro");
            }
        }

        internal static void CarregarCSVEmprestimo(string caminhoDoArquivoCSV, string caminhoArquivoTxt)
        {
            try
            {
                var emprestimosParaAdd = new List<Emprestimo>();

                    string[] linhasCSV = File.ReadAllLines(caminhoDoArquivoCSV);

                    foreach (string linhaCSV in linhasCSV)
                    {
                        string[] valoresCSV = linhaCSV.Split(',');

                        var linhaString = string.Join(",", valoresCSV);

                        var emprestimo = EmprestimoData.ConverterLinhaParaEmprestimo(linhaCSV);

                        emprestimosParaAdd.Add(emprestimo);

                    }

                    MessageBox.Show($"Num emprestimos: {emprestimosParaAdd.Count} \n");

                EmprestimoData.IncluirEmprestimos(emprestimosParaAdd);

                }
                catch
                {
                    MessageBox.Show("Erro ao carregar arquivo CSV. Verifique se está no formato correto: titulo, autor, isbn, anoPublicacao, edicao, editora, exemplares, exemplaresDisponiveis, livrosBomEstado, livrosEstadoMediano, livrosMauEstado, tipoAcervoLivro, senha, nomeCompleto, cpf, email, matricula, curso, tipoUsuario");
             }
         }


        internal static void CarregarCSVReservaLivro(string caminhoDoArquivoCSV, string caminhoArquivoTxt)
        {
            try
            {
                var reservasAdicionadas = new List<ReservaLivro>();

                string[] linhasCSV = File.ReadAllLines(caminhoDoArquivoCSV);

                foreach (string linhaCSV in linhasCSV)
                {
                    string[] valoresCSV = linhaCSV.Split(',');

                    var linhaString = string.Join(",", valoresCSV);

                    ReservaLivroData.ConverterLinhaParaReservaLivro(linhaString);
                }

                ReservaLivroData.SalvarReservaLivrosTxt();

                MessageBox.Show($"Num reservas: {reservasAdicionadas.Count} \n");


            }
            catch
            {
                MessageBox.Show("Erro ao carregar arquivo CSV. Verifique se está no formato correto: titulo, autor, isbn, anoPublicacao, edicao, editora, exemplares, exemplaresDisponiveis, livrosBomEstado, livrosEstadoMediano, livrosMauEstado, tipoAcervoLivro, senha, nomeCompleto, cpf, email, matricula, curso, tipoUsuario");
            }
        }














        }
    }

