using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;
using System;


namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal class Diretor: Funcionario
    {
        internal Diretor(string login, string senha, string nomeCompleto, string cpf, string email, bool ativo)
            : base(login, senha, nomeCompleto, cpf, email, ativo)
        {
            this.EhAdmin = true;
        }

        internal void AprovarSolicitacao(ISolicitacao solicitacao)
        {
            if (solicitacao == null)
                throw new ArgumentNullException(nameof(solicitacao));
            solicitacao.AprovarSolicitacao(this);
        }

        internal void CancelarSolicitacao(ISolicitacao solicitacao)
        {
            if (solicitacao == null)
                throw new ArgumentNullException(nameof(solicitacao));
            solicitacao.CancelarSolicitacao(this);
        }

        internal void ReprovarSolicitacao(ISolicitacao solicitacao)
        {
            if (solicitacao == null)
                throw new ArgumentNullException(nameof(solicitacao));
            solicitacao.ReprovarSolicitacao(this);
        }

        //private Funcionario CadastrarFuncionario(string nomeCompleto, string cpf, string email, string tipoFuncionario)
        //{
            
        //}
        //private Funcionario CadastroFuncionario()
        //{

        //}

    }
}
