using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers
{
    internal class CarregarCSVController
    {
        internal static void CarregarCSV(string caminhoArquivoCSV, string caminhoArquivoTxt)
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
    }
}
