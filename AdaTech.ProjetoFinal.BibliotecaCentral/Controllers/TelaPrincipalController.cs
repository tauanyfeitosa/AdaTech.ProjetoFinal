using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers
{
    internal class TelaPrincipalController
    {
        private readonly Usuario _usuario;

        internal TelaPrincipalController(Usuario usuario)
        {
            _usuario = usuario;            
        }

        internal string FiltrarLogin()
        {
            if (_usuario is Atendente)
            {                
                return "Atendente";
            }
            else if (_usuario is Bibliotecario)
            {
                return "Bibliotecário";
            }
            else if (_usuario is ComunidadeAcademica )
            {
                ComunidadeAcademica comunidadeAcademica = (ComunidadeAcademica) _usuario;
                return comunidadeAcademica.TipoUsuario.ToString();
            }
            else 
            {
                return "Diretor";
            }
        }

        internal void CarregarCSV(string caminhoArquivoCSV, string caminhoArquivoTxt, Usuario usuario, string tipoArquivo = null)
        {

            if (usuario is Diretor)
            {
                //CarregarCSVController.CarregarCSVFuncionario(caminhoArquivoCSV);
            }
            else if (usuario is Atendente || tipoArquivo != null)
            {
                if (tipoArquivo == "ComunidadeAcademica")
                {
                    CarregarCSVController.CarregarCSVComunidadeAcademica(caminhoArquivoCSV, caminhoArquivoTxt);
                }
                else if (tipoArquivo == "Emprestimo")
                {
                    CarregarCSVController.CarregarCSVEmprestimo(caminhoArquivoCSV, caminhoArquivoTxt);
                }
                else if (tipoArquivo == "ReservaLivro")
                {
                    CarregarCSVController.CarregarCSVReservaLivro(caminhoArquivoCSV, caminhoArquivoTxt);
                }

            }
            else if (usuario is Bibliotecario)
            {
                CarregarCSVController.CarregarCSVLivro(caminhoArquivoCSV);
            }
        }
    }
}
