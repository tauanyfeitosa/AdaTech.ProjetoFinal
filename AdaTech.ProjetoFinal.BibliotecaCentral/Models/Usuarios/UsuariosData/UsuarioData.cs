using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Utilities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData
{
    internal static class UsuarioData
    {
        private static List<Atendente> _atendentes = new List<Atendente>();
        private static List<Bibliotecario> _bibliotecarios = new List<Bibliotecario>();
        private static List<Diretor> _diretores = new List<Diretor>();
        private static List<ComunidadeAcademica> _comunidadeAcademica = new List<ComunidadeAcademica>();

        private static readonly string _DIRECTORY_PATH = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\Data";
        private static readonly string _FILE_PATH_DIRETOR = Path.Combine(_DIRECTORY_PATH, "Diretores.txt");
        private static readonly string _FILE_PATH_BIBLIOTECARIO = Path.Combine(_DIRECTORY_PATH, "Bibliotecarios.txt");
        private static readonly string _FILE_PATH_ATENDENTE = Path.Combine(_DIRECTORY_PATH, "Atendentes.txt");
        private static readonly string _FILE_PATH_CA = Path.Combine(_DIRECTORY_PATH, "ComunidadeAcademica.txt");

        internal  static string FilePathCA { get => _FILE_PATH_CA; }

        //static UsuarioData()
        //{
        //    _diretores = LerDiretoresTxt();
        //    _bibliotecarios = LerBibliotecariosTxt();
        //    _atendentes = LerAtendentesTxt();
        //    _comunidadeAcademica = LerComunidadeAcademicaTxt();
        //}

        internal static void CarregarUsuarios()
        {
            _diretores = LerDiretoresTxt();
            _bibliotecarios = LerBibliotecariosTxt();
            _atendentes = LerAtendentesTxt();
            _comunidadeAcademica = LerComunidadeAcademicaTxt();
        }

        public static List<Atendente> Atendentes
        {
            get { return _atendentes; }
        }

        public static List<Bibliotecario> Bibliotecarios
        {
            get { return _bibliotecarios; }
        }

        public static List<Diretor> Diretores
        {
            get { return _diretores; }
        }

        public static List<ComunidadeAcademica> ComunidadeAcademica
        {
            get { return _comunidadeAcademica; }
        }

        internal static List<ComunidadeAcademica> ListarCA (TipoUsuarioComunidade tipoUsuario)
        {
            return _comunidadeAcademica.Where(u => u.TipoUsuario == tipoUsuario).ToList();
        }


        internal static List<Funcionario> ObterFuncionarios()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            funcionarios.AddRange(_atendentes);
            funcionarios.AddRange(_bibliotecarios);
            funcionarios.AddRange(_diretores);

            return funcionarios;
        }

        internal static void IncluirUsuario(Usuario usuario)
        {
            if (usuario is Atendente)
            {
                _atendentes.Add((Atendente)usuario);
            }
            else if (usuario is Bibliotecario)
            {
                _bibliotecarios.Add((Bibliotecario)usuario);
            }
            else if (usuario is Diretor)
            {
                _diretores.Add((Diretor)usuario);
            }
            else if (usuario is ComunidadeAcademica)
            {
                _comunidadeAcademica.Add((ComunidadeAcademica)usuario);
            }
        }

        internal static ComunidadeAcademica AdicionarCA(ComunidadeAcademica CA)
        {
            if (!_comunidadeAcademica.Contains(CA))
            {
                _comunidadeAcademica.Add(CA);
                SalvarComunidadeAcademicaTxt(_comunidadeAcademica);
            }
            else
            {
                throw new InvalidOperationException("O livro já existe no acervo.");
            }

            return CA;
        }

        internal static void IncluirUsuario (List<Usuario> usuarios)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario is Atendente)
                {
                    _atendentes.Add((Atendente)usuario);
                }
                else if (usuario is Bibliotecario)
                {
                    _bibliotecarios.Add((Bibliotecario)usuario);
                }
                else if (usuario is Diretor)
                {
                    _diretores.Add((Diretor)usuario);
                }
                else if (usuario is ComunidadeAcademica)
                {
                    _comunidadeAcademica.Add((ComunidadeAcademica)usuario);
                }
            }
        }

        internal static List<ComunidadeAcademica> ObterAlunos ()
        {
            return _comunidadeAcademica.Where(u => u.TipoUsuario == TipoUsuarioComunidade.Aluno).ToList();
        }

        internal static List<ComunidadeAcademica> ObterProfessores()
        {
            return _comunidadeAcademica.Where(u => u.TipoUsuario == TipoUsuarioComunidade.Professor).ToList();
        }

        internal static void RemoverUsuario (Usuario usuario)
        {
            if (usuario is Atendente)
            {
                _atendentes.Remove((Atendente)usuario);
            }
            else if (usuario is Bibliotecario)
            {
                _bibliotecarios.Remove((Bibliotecario)usuario);
            }
            else if (usuario is Diretor)
            {
                _diretores.Remove((Diretor)usuario);
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
                    _atendentes.Remove((Atendente)usuario);
                }
                else if (usuario is Bibliotecario)
                {
                    _bibliotecarios.Remove((Bibliotecario)usuario);
                }
                else if (usuario is Diretor)
                {
                    _diretores.Remove((Diretor)usuario);
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
                _atendentes.Remove((Atendente)usuario);
                _atendentes.Add((Atendente)usuario);
            }
            else if (usuario is Bibliotecario)
            {
                _bibliotecarios.Remove((Bibliotecario)usuario);
                _bibliotecarios.Add((Bibliotecario)usuario);
            }
            else if (usuario is Diretor)
            {
                _diretores.Remove((Diretor)usuario);
                _diretores.Add((Diretor)usuario);
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
                    _atendentes.Remove((Atendente)usuario);
                    _atendentes.Add((Atendente)usuario);
                }
                else if (usuario is Bibliotecario)
                {
                    _bibliotecarios.Remove((Bibliotecario)usuario);
                    _bibliotecarios.Add((Bibliotecario)usuario);
                }
                else if (usuario is Diretor)
                {
                    _diretores.Remove((Diretor)usuario);
                    _diretores.Add((Diretor)usuario);
                }
                else if (usuario is ComunidadeAcademica)
                {
                    _comunidadeAcademica.Remove((ComunidadeAcademica)usuario);
                    _comunidadeAcademica.Add((ComunidadeAcademica)usuario);
                }
            }
        }
        internal static ComunidadeAcademica SelecionarComunidadeAcademica(string login)
        {
            ComunidadeAcademica usuario = _comunidadeAcademica.Where(u => u.Login == login).FirstOrDefault();
            if (usuario != null) return usuario;

            throw new InvalidOperationException("Usuário não encontrado.");
        }
        internal static Usuario SelecionarUsuario (string login)
        {
            Usuario usuario = _atendentes.Where(u => u.Login == login).FirstOrDefault();
            if (usuario != null) return usuario;

            usuario = _bibliotecarios.Where(u => u.Login == login).FirstOrDefault();
            if (usuario != null) return usuario;

            usuario = _diretores.Where(u => u.Login == login).FirstOrDefault();
            if (usuario != null) return usuario;

            usuario = _comunidadeAcademica.Where(u => u.Login == login).FirstOrDefault();
            if (usuario != null) return usuario;

            throw new InvalidOperationException("Usuário não encontrado.");
        }

        internal static ComunidadeAcademica SelecionarUsuarioCA (string cpf)
        {
            ComunidadeAcademica usuario = _comunidadeAcademica.Where(u => u.Cpf == cpf).FirstOrDefault();
            if (usuario != null) return usuario;

            throw new InvalidOperationException("Usuário não encontrado.");
        }

        internal static List<Usuario> LerUsuariosTxt(string _FILE_PATH, int tipoUsuario)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                if (File.Exists(_FILE_PATH))
                {

                    using (StreamReader sr = new StreamReader(_FILE_PATH))
                    {
                        while (!sr.EndOfStream)
                        {
                            string linha = sr.ReadLine();
                            if (tipoUsuario == 0)
                            {
                                Diretor diretor = ConverterLinhaParaDiretor(linha);
                                listaUsuarios.Add(diretor);
                            } else if (tipoUsuario == 1)
                            {
                                Bibliotecario bibliotecario = ConverterLinhaParaBibliotecario(linha);
                                listaUsuarios.Add(bibliotecario);
                            } else if (tipoUsuario == 2)
                            {
                                Atendente atendente = ConverterLinhaParaAtendente(linha);
                                listaUsuarios.Add(atendente);
                            } else if (tipoUsuario == 3)
                            {
                                ComunidadeAcademica comunidadeAcademica = ConverterLinhaParaComunidadeAcademica(linha);
                                listaUsuarios.Add(comunidadeAcademica);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt de diretor não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }
            return listaUsuarios;
        }

        internal static List<Diretor> LerDiretoresTxt()
        {
            List<Diretor> listaDiretor = new List<Diretor>();

            try
            {
                if (File.Exists(_FILE_PATH_DIRETOR))
                {
                    List<Usuario> lista = LerUsuariosTxt(_FILE_PATH_DIRETOR, 0);
                    if (lista.OfType<Diretor>().ToList().Count > 0)
                    {
                        listaDiretor = lista.OfType<Diretor>().ToList();
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt de diretor não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }
            return listaDiretor;
        }

        internal static List<Bibliotecario> LerBibliotecariosTxt()
        {
            List<Bibliotecario> listaBibliotecario = new List<Bibliotecario>();

            try
            {
                if (File.Exists(_FILE_PATH_BIBLIOTECARIO))
                {
                    List<Usuario> lista = LerUsuariosTxt(_FILE_PATH_BIBLIOTECARIO, 1);
                    if (lista.OfType<Bibliotecario>().ToList().Count > 0)
                    {
                        listaBibliotecario = lista.OfType<Bibliotecario>().ToList();
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt de bibliotecário não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }
            return listaBibliotecario;
        }

        internal static List<Atendente> LerAtendentesTxt()
        {
            List<Atendente> listaAtendente = new List<Atendente>();

            try
            {
                if (File.Exists(_FILE_PATH_ATENDENTE))
                {
                    List<Usuario> lista = LerUsuariosTxt(_FILE_PATH_ATENDENTE, 2);
                    if (lista.OfType<Atendente>().ToList().Count > 0)
                    {
                        listaAtendente = lista.OfType<Atendente>().ToList();
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt de atendente não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }
            return listaAtendente;
        }

        internal static List<ComunidadeAcademica> LerComunidadeAcademicaTxt()
        {
            List<ComunidadeAcademica> listaComunidadeAcademica = new List<ComunidadeAcademica>();

            try
            {
                if (File.Exists(_FILE_PATH_CA))
                {
                    List<Usuario> lista = LerUsuariosTxt(_FILE_PATH_CA, 3);
                    if (lista.OfType<ComunidadeAcademica>().ToList().Count > 0)
                    {
                        listaComunidadeAcademica = lista.OfType<ComunidadeAcademica>().ToList();
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt de comunidade acadêmica não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }
            return listaComunidadeAcademica;
        }

        private static Tuple<List<string>, bool> ConverterLinhaParaFuncionario(string linha)
        {
            string[] objetoString = linha.Split(',');

            string senha = objetoString[0];
            string nomeCompleto = objetoString[1];
            string cpf = objetoString[2];
            string email = objetoString[3];
            if (objetoString.Length > 4)
            {
                bool ativo = bool.Parse(objetoString[4]);

                return new Tuple<List<string>, bool>(new List<string> { senha, nomeCompleto, cpf, email }, ativo);
            }

            return new Tuple<List<string>, bool>(new List<string> { senha, nomeCompleto, cpf, email }, true);
        }

        internal static Diretor ConverterLinhaParaDiretor(string linha)
        {
            return new Diretor(ConverterLinhaParaFuncionario(linha).Item1[0],
                                    ConverterLinhaParaFuncionario(linha).Item1[1],
                                        ConverterLinhaParaFuncionario(linha).Item1[2],
                                            ConverterLinhaParaFuncionario(linha).Item1[3],
                                                ConverterLinhaParaFuncionario(linha).Item2);
        }

        internal static Atendente ConverterLinhaParaAtendente(string linha)
        {
            return new Atendente(ConverterLinhaParaFuncionario(linha).Item1[0],
                                        ConverterLinhaParaFuncionario(linha).Item1[1],
                                            ConverterLinhaParaFuncionario(linha).Item1[2],
                                                ConverterLinhaParaFuncionario(linha).Item1[3],
                                                    ConverterLinhaParaFuncionario(linha).Item2);
        }

        internal static Bibliotecario ConverterLinhaParaBibliotecario(string linha)
        {
            return new Bibliotecario(ConverterLinhaParaFuncionario(linha).Item1[0],
                                            ConverterLinhaParaFuncionario(linha).Item1[1],
                                                ConverterLinhaParaFuncionario(linha).Item1[2],
                                                    ConverterLinhaParaFuncionario(linha).Item1[3],
                                                        ConverterLinhaParaFuncionario(linha).Item2);
        }

        internal static ComunidadeAcademica ConverterLinhaParaComunidadeAcademica(string linha)
        {
            string[] objetoString = linha.Split(',');

            string senha = objetoString[0];
            string nomeCompleto = objetoString[1];
            string cpf = objetoString[2];
            string email = objetoString[3];
            string matricula = objetoString[4];
            string curso = objetoString[5];
            TipoUsuarioComunidade tipoUsuario = Conversores.StringParaTipoUsuarioComunidade(objetoString[6]);

            return new ComunidadeAcademica(senha, nomeCompleto, cpf, email, matricula, curso, tipoUsuario);
        }


        internal static void SalvarUsuariosTxt<T>(List<T> usuarios, string _FILE_PATH)
        {
            try
            {
                List<string> linhas = new List<string>();
                if (typeof(T) == typeof(Diretor))
                {
                    foreach (Diretor Di in usuarios.OfType<Diretor>())
                    {
                        string linha = ConverterFuncionarioParaLinha(Di);
                        linhas.Add(linha);
                    }
                }
                else if (typeof(T) == typeof(Bibliotecario))
                {
                    foreach (Bibliotecario Bi in usuarios.OfType<Bibliotecario>())
                    {
                        string linha = ConverterFuncionarioParaLinha(Bi);
                        linhas.Add(linha);
                    }
                }
                else if (typeof(T) == typeof(Atendente))
                {
                    foreach (Atendente At in usuarios.OfType<Atendente>())
                    {
                        string linha = ConverterFuncionarioParaLinha(At);
                        linhas.Add(linha);
                    }
                }
                else if (typeof(T) == typeof(ComunidadeAcademica))
                {
                    foreach (ComunidadeAcademica CA in usuarios.OfType<ComunidadeAcademica>())
                    {
                        string linha = ConverterComunidadeAcademicaParaLinha(CA);
                        linhas.Add(linha);
                    }
                }


                File.AppendAllLines(_FILE_PATH, linhas);

                MessageBox.Show($"Alterações adicionadas com sucesso no arquivo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static void SalvarBibliotecariosTxt(List<Bibliotecario> bibliotecarios)
        {
            try
            {
                SalvarUsuariosTxt<Bibliotecario>(bibliotecarios, _FILE_PATH_BIBLIOTECARIO);

                _bibliotecarios = LerBibliotecariosTxt();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static void SalvarAtendentesTxt(List<Atendente> atendentes)
        {
            try
            {
                SalvarUsuariosTxt<Atendente>(atendentes, _FILE_PATH_ATENDENTE);

                _atendentes = LerAtendentesTxt();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static void SalvarDiretoresTxt(List<Diretor> diretores)
        {
            try
            {
                SalvarUsuariosTxt<Diretor>(diretores, _FILE_PATH_DIRETOR);

                _diretores.AddRange(LerDiretoresTxt());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static void SalvarComunidadeAcademicaTxt(List<ComunidadeAcademica> comunidadeAcademica)
        {
            try
            {
                SalvarUsuariosTxt<ComunidadeAcademica>(comunidadeAcademica, _FILE_PATH_CA);

                _comunidadeAcademica = LerComunidadeAcademicaTxt();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static string ConverterFuncionarioParaLinha(Funcionario funcionario)
        {
            return $"{funcionario.SenhaCripto},{funcionario.NomeCompleto},{funcionario.Cpf},{funcionario.Email},{funcionario.Ativo}";
        }

        internal static string ConverterComunidadeAcademicaParaLinha(ComunidadeAcademica usuario)
        {
            return $"{usuario.SenhaCripto},{usuario.NomeCompleto},{usuario.Cpf},{usuario.Email},{usuario.Matricula},{usuario.Curso},{usuario.TipoUsuario}";
        }

    }
}
