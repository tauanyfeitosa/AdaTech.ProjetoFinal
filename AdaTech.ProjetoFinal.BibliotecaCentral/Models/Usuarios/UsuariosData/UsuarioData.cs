using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Utilities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData
{
    internal static class UsuarioData
    {
        private static List<Atendente> _atendente = new List<Atendente>()
        {
            new Atendente("123", "Atendente 1", "12345678910", "atendente@gmail.com", true)
        };
        private static List<Bibliotecario> _bibliotecario = new List<Bibliotecario>();
        private static List<Diretor> _diretor = new List<Diretor>();

        private static List<ComunidadeAcademica> _comunidadeAcademica = new List<ComunidadeAcademica>();

        internal static void IncluirUsuario(Usuario usuario)
        {
            if (usuario is Atendente)
            {
                _atendente.Add((Atendente)usuario);
            }
            else if (usuario is Bibliotecario)
            {
                _bibliotecario.Add((Bibliotecario)usuario);
            }
            else if (usuario is Diretor)
            {
                _diretor.Add((Diretor)usuario);
            }
            else if (usuario is ComunidadeAcademica)
            {
                _comunidadeAcademica.Add((ComunidadeAcademica)usuario);
            }
        }

        internal static void IncluirUsuario (List<Usuario> usuarios)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario is Atendente)
                {
                    _atendente.Add((Atendente)usuario);
                }
                else if (usuario is Bibliotecario)
                {
                    _bibliotecario.Add((Bibliotecario)usuario);
                }
                else if (usuario is Diretor)
                {
                    _diretor.Add((Diretor)usuario);
                }
                else if (usuario is ComunidadeAcademica)
                {
                    _comunidadeAcademica.Add((ComunidadeAcademica)usuario);
                }
            }
        }   

        internal static void RemoverUsuario (Usuario usuario)
        {
            if (usuario is Atendente)
            {
                _atendente.Remove((Atendente)usuario);
            }
            else if (usuario is Bibliotecario)
            {
                _bibliotecario.Remove((Bibliotecario)usuario);
            }
            else if (usuario is Diretor)
            {
                _diretor.Remove((Diretor)usuario);
            }
            else if (usuario is ComunidadeAcademica)
            {
                _comunidadeAcademica.Remove((ComunidadeAcademica)usuario);
            }
        }

        internal static void RemoverUsuario (List<Usuario> usuarios)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario is Atendente)
                {
                    _atendente.Remove((Atendente)usuario);
                }
                else if (usuario is Bibliotecario)
                {
                    _bibliotecario.Remove((Bibliotecario)usuario);
                }
                else if (usuario is Diretor)
                {
                    _diretor.Remove((Diretor)usuario);
                }
                else if (usuario is ComunidadeAcademica)
                {
                    _comunidadeAcademica.Remove((ComunidadeAcademica)usuario);
                }
            }
        }


        internal static void AtualizarUsuario (Usuario usuario)
        {
            if (usuario is Atendente)
            {
                _atendente.Remove((Atendente)usuario);
                _atendente.Add((Atendente)usuario);
            }
            else if (usuario is Bibliotecario)
            {
                _bibliotecario.Remove((Bibliotecario)usuario);
                _bibliotecario.Add((Bibliotecario)usuario);
            }
            else if (usuario is Diretor)
            {
                _diretor.Remove((Diretor)usuario);
                _diretor.Add((Diretor)usuario);
            }
            else if (usuario is ComunidadeAcademica)
            {
                _comunidadeAcademica.Remove((ComunidadeAcademica)usuario);
                _comunidadeAcademica.Add((ComunidadeAcademica)usuario);
            }
        }

        internal static void AtualizarUsuario (List<Usuario> usuarios)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario is Atendente)
                {
                    _atendente.Remove((Atendente)usuario);
                    _atendente.Add((Atendente)usuario);
                }
                else if (usuario is Bibliotecario)
                {
                    _bibliotecario.Remove((Bibliotecario)usuario);
                    _bibliotecario.Add((Bibliotecario)usuario);
                }
                else if (usuario is Diretor)
                {
                    _diretor.Remove((Diretor)usuario);
                    _diretor.Add((Diretor)usuario);
                }
                else if (usuario is ComunidadeAcademica)
                {
                    _comunidadeAcademica.Remove((ComunidadeAcademica)usuario);
                    _comunidadeAcademica.Add((ComunidadeAcademica)usuario);
                }
            }
        }

        internal static Usuario SelecionarUsuario (string login)
        {
            Usuario usuario = _atendente.Where(u => u.Login == login).FirstOrDefault();
            if (usuario != null) return usuario;

            usuario = _bibliotecario.Where(u => u.Login == login).FirstOrDefault();
            if (usuario != null) return usuario;

            usuario = _diretor.Where(u => u.Login == login).FirstOrDefault();
            if (usuario != null) return usuario;

            usuario = _comunidadeAcademica.Where(u => u.Login == login).FirstOrDefault();
            if (usuario != null) return usuario;

            throw new InvalidOperationException("Usuário não encontrado.");
        }

        internal static string ConverterComunidadeAcademicaParaLinha(ComunidadeAcademica usuario)
        {
            return $"{usuario.Matricula},{usuario.Curso},{usuario.TipoUsuario}";
        }

        internal static Bibliotecario ConverterLinhaParaBibliotecario(string linha)
        {
            string[] partes = linha.Split(',');

            string senha = partes[0];
            string nomeCompleto = partes[1];
            string cpf = partes[2];
            string email = partes[3];
            bool ativo = Conversores.StringParaBool(partes[4]); 

            return new Bibliotecario(senha, nomeCompleto, cpf, email, ativo);
        }

        internal static string ConverterBibliotecarioParaLinha(Bibliotecario bibliotecario)
        {
            return $"{bibliotecario.SenhaCripto},{bibliotecario.NomeCompleto},{bibliotecario.Cpf},{bibliotecario.Email},{bibliotecario.Ativo}";
        }
    }
}
