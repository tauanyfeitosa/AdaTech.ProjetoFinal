using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using System;
using System.Collections.Generic;


namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal class Diretor : Funcionario
    {
        internal Diretor(string senha, string nomeCompleto, string cpf, string email, bool ativo = true)
            : base(senha, nomeCompleto, cpf, email, ativo)
        {
            this.EhAdmin = true;
        }

        internal void AprovarSolicitacao(ISolicitacao solicitacao)
        {
            if (solicitacao == null)
                throw new ArgumentNullException(nameof(solicitacao));
            solicitacao.AprovarSolicitacao(this);
        }

        internal void AprovarSolicitacao(List<ISolicitacao> solicitacoes)
        {
            if (solicitacoes == null)
                throw new ArgumentNullException(nameof(solicitacoes));
            foreach (var solicitacao in solicitacoes)
            {
                solicitacao.AprovarSolicitacao(this);
            }
        }

        internal void CancelarSolicitacao(ISolicitacao solicitacao)
        {
            if (solicitacao == null)
                throw new ArgumentNullException(nameof(solicitacao));
            SolicitacoesData.RemoverSolicitacoes(solicitacao);
        }

        internal void CancelarSolicitacao(List<ISolicitacao> solicitacoes)
        {
            if (solicitacoes == null)
                throw new ArgumentNullException(nameof(solicitacoes));
            SolicitacoesData.RemoverSolicitacoes(solicitacoes);
        }

        internal void ReprovarSolicitacao(ISolicitacao solicitacao)
        {
            if (solicitacao == null)
                throw new ArgumentNullException(nameof(solicitacao));
            solicitacao.ReprovarSolicitacao(this);
        }

        internal void ReprovarSolicitacao(List<ISolicitacao> solicitacoes)
        {
            if (solicitacoes == null)
                throw new ArgumentNullException(nameof(solicitacoes));
            foreach (var solicitacao in solicitacoes)
            {
                solicitacao.ReprovarSolicitacao(this);
            }
        }

        private void CadastrarFuncionarios(List<Funcionario> novosFuncionarios)
        {
            HashSet<Atendente> setAtendentes = new HashSet<Atendente>();
            HashSet<Bibliotecario> setBibliotecarios = new HashSet<Bibliotecario>();
            HashSet<Diretor> setDiretores = new HashSet<Diretor>();

            foreach (var funcionario in novosFuncionarios)
            {
                if (funcionario is Atendente)
                {
                    setAtendentes.Add(funcionario as Atendente);
                }
                else if (funcionario is Bibliotecario)
                {
                    setBibliotecarios.Add(funcionario as Bibliotecario);
                }
                else if (funcionario is Diretor)
                {
                    setDiretores.Add(funcionario as Diretor);
                }


                foreach (var item in UsuarioData.Atendentes)
                {
                    setAtendentes.Add(item);
                }

                foreach (var item in UsuarioData.Bibliotecarios)
                {
                    setBibliotecarios.Add(item);
                }
                foreach (var item in UsuarioData.Diretores)
                {
                    setDiretores.Add(item);
                }

                List<Atendente> novalistaAtendentes = new List<Atendente>(setAtendentes);
                List<Bibliotecario> novalistaBibliotecarios = new List<Bibliotecario>(setBibliotecarios);
                List<Diretor> novalistaDiretores = new List<Diretor>(setDiretores);

                UsuarioData.SalvarAtendentesTxt(novalistaAtendentes);
                UsuarioData.SalvarBibliotecariosTxt(novalistaBibliotecarios);
                UsuarioData.SalvarDiretoresTxt(novalistaDiretores);

            }
        }

        private void CadastrarFuncionario(Funcionario novoFuncionario)
        {
            HashSet<Atendente> setAtendentes = new HashSet<Atendente>(UsuarioData.Atendentes);
            HashSet<Bibliotecario> setBibliotecarios = new HashSet<Bibliotecario>(UsuarioData.Bibliotecarios);
            HashSet<Diretor> setDiretores = new HashSet<Diretor>(UsuarioData.Diretores);

            if (novoFuncionario is Atendente)
            {
                setAtendentes.Add(novoFuncionario as Atendente);
            }
            else if (novoFuncionario is Bibliotecario)
            {
                setBibliotecarios.Add(novoFuncionario as Bibliotecario);
            }
            else if (novoFuncionario is Diretor)
            {
                setDiretores.Add(novoFuncionario as Diretor);
            }

            List<Atendente> novaListaAtendentes = new List<Atendente>(setAtendentes);
            List<Bibliotecario> novaListaBibliotecarios = new List<Bibliotecario>(setBibliotecarios);
            List<Diretor> novaListaDiretores = new List<Diretor>(setDiretores);

            UsuarioData.SalvarAtendentesTxt(novaListaAtendentes);
            UsuarioData.SalvarBibliotecariosTxt(novaListaBibliotecarios);
            UsuarioData.SalvarDiretoresTxt(novaListaDiretores);
        }
    }
}

