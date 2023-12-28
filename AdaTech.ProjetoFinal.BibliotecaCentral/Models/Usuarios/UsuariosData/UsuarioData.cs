using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Utilities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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
        private static List<Bibliotecario> _bibliotecario ;
        private static List<Diretor> _diretor ;

        private static List<ComunidadeAcademica> _comunidadeAcademica ;
        private static  readonly string _FILE_PATH_DIRETOR = "../../../Data/Diretor.txt";
        private static  readonly string _FILE_PATH_BIBLIOTECARIO = "../../../Data/BIBLIOTECARIO.txt";
        private static  readonly string _FILE_PATH_ATENDENTE = "../../../Data/Atendente.txt";

        static UsuarioData()
        {
            _diretor = LoadDataCsvDiretor(_FILE_PATH_DIRETOR);
            _bibliotecario = LoadDataCsvBibliotecario(_FILE_PATH_BIBLIOTECARIO);
            _atendente = LoadDataCsvAtendente(_FILE_PATH_ATENDENTE);
        }

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


        internal static List<Diretor> RecebeCsvDiretor(string FILE_PATH)
        {
            List<Diretor> listaDiretor = new List<Diretor>();

            try
            {
                if (File.Exists(FILE_PATH))
                {

                    using (StreamReader sr = new StreamReader(FILE_PATH))
                    {
                        while ((!sr.EndOfStream) != null)
                        {
                            string linha = sr.ReadLine();
                            Diretor diretor = ConverterLinhaParaDiretor(linha);
                            listaDiretor.Add(diretor);
                        }
                    }
                    Console.WriteLine("Dados carregados do arquivo json.");
                }
                else
                {
                    Console.WriteLine("O arquivo json não existe.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("O arquivo não pôde ser aberto: " + e.Message);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Erro ao desserializar os dados: " + e.Message);
            }
            return listaDiretor;
        }

        private static Diretor ConverterLinhaParaDiretor(string linha)
        {
            string[] objetoString = linha.Split(',');

            string senha = objetoString[0];
            string nomeCompleto = objetoString[1];
            string cpf = objetoString[2];
            string email = objetoString[3];
            bool ativo = bool.Parse(objetoString[4]);

            return new Diretor(senha, nomeCompleto, cpf, email, ativo);
        }



        internal static List<Atendente> RecebeCsvAtendente(string FILE_PATH)
        {
            List<Atendente> listaAtendente = new List<Atendente>();

            try
            {
                if (File.Exists(FILE_PATH))
                {

                    using (StreamReader sr = new StreamReader(FILE_PATH))
                    {
                        

                        while ((!sr.EndOfStream) != null)
                        {
                            linha = sr.ReadLine();
                            Atendente atendente = ConverterLinhaParaAtendente(linha);
                            listaAtendente.Add(atendente);
                        }
                    }
                    Console.WriteLine("Dados carregados do arquivo json.");
                }
                else
                {
                    Console.WriteLine("O arquivo json não existe.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("O arquivo não pôde ser aberto: " + e.Message);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Erro ao desserializar os dados: " + e.Message);
            }
            return listaAtendente;
        }

        private static Atendente ConverterLinhaParaAtendente(string linha)
        {
            string[] objetoString = linha.Split(',');

            string senha = objetoString[0];
            string nomeCompleto = objetoString[1];
            string cpf = objetoString[2];
            string email = objetoString[3];
            bool ativo = bool.Parse(objetoString[4]);

            return new Atendente(senha, nomeCompleto, cpf, email, ativo);
        }

            internal static List<Bibliotecario> LoadDataCsvBibliotecario(string FILE_PATH)
        {
            List<Bibliotecario> listaBibliotecario = new List<Bibliotecario>();

            try
            {
                if (File.Exists(FILE_PATH))
                {

                    using (StreamReader sr = new StreamReader(FILE_PATH))
                    {
                        while ((!sr.EndOfStream) != null)
                        {
                            string linha = sr.ReadLine();
                            Bibliotecario bibliotecario =ConverterLinhaParaBibliotecario(linha);
                            listaBibliotecario.Add(bibliotecario);
                        }
                    }
                    Console.WriteLine("Dados carregados do arquivo json.");
                }
                else
                {
                    Console.WriteLine("O arquivo json não existe.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("O arquivo não pôde ser aberto: " + e.Message);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Erro ao desserializar os dados: " + e.Message);
            }
            return listaBibliotecario;
        }

        private static Bibliotecario ConverterLinhaParaBibliotecario(string linha)
        {
            string[] objetoString = linha.Split(',');

            string senha = objetoString[0];
            string nomeCompleto = objetoString[1];
            string cpf = objetoString[2];
            string email = objetoString[3];
            bool ativo = bool.Parse(objetoString[4]);

            return new Bibliotecario(senha, nomeCompleto, cpf, email, ativo);
        }


        internal static List<ComunidadeAcademica> LoadDataCsvComunidadeAcademica(string FILE_PATH)
        {
            List<ComunidadeAcademica> listaComunidadeAcademica = new List<ComunidadeAcademica>();

            try
            {
                if (File.Exists(FILE_PATH))
                {

                    using (StreamReader sr = new StreamReader(FILE_PATH))
                    {
                        while ((!sr.EndOfStream) != null)
                        {
                            string linha = sr.ReadLine();
                            ComunidadeAcademica comunidadeAcademica = ConverterLinhaParaComunidadeAcademica(linha);
                            listaComunidadeAcademica.Add(comunidadeAcademica);
                        }
                    }
                    Console.WriteLine("Dados carregados do arquivo json.");
                }
                else
                {
                    Console.WriteLine("O arquivo json não existe.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("O arquivo não pôde ser aberto: " + e.Message);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Erro ao desserializar os dados: " + e.Message);
            }
            return listaBibliotecario;
        }

        private static ComunidadeAcademica ConverterLinhaParaComunidadeAcademica(string linha)
        {
            string[] objetoString = linha.Split(',');

            string senha = objetoString[0];
            string nomeCompleto = objetoString[1];
            string cpf = objetoString[2];
            string email = objetoString[3];
            string matricula = objetoString[4];
            string curso = objetoString[5];
            TipoUsuarioComunidade tipoUsuario = Conversores.StringParaTipoUsuarioComunidade(objetoString[6]);
            bool ativo = bool.Parse(objetoString[6]);

            return new ComunidadeAcademica(senha, nomeCompleto, cpf, email, matricula, curso, tipoUsuario);
        }

    }
}
