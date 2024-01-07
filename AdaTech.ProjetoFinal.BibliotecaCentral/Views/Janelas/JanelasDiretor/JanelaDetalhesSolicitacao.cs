using System;
using System.Linq;
using System.Windows.Forms;
using AdaTech.ProjetoFinal.BibliotecaCentral.Controllers;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Solicitacoes;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasDiretor
{
    internal partial class JanelaDetalhesSolicitacao : Form
    {
        private ISolicitacao solicitacao;

        public JanelaDetalhesSolicitacao(ISolicitacao solicitacao)
        {
            this.solicitacao = solicitacao;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            Text = "Detalhes da Solicitação";
            Size = new System.Drawing.Size(400, 300);

            Label lblBibliotecario = new Label();
            lblBibliotecario.Dock = DockStyle.Top;
            lblBibliotecario.Text = $"Bibliotecário: {GetBibliotecarioNome()}";

            Label lblDescricao = new Label();
            lblDescricao.Dock = DockStyle.Top;
            lblDescricao.Text = $"Descrição: {GetDescricao()}";

            Label lblTipoAcervo = new Label();
            lblTipoAcervo.Dock = DockStyle.Top;
            lblTipoAcervo.Text = $"Tipo de Acervo: {GetTipoAcervo()}";

            Label lblLivroTitulo = new Label();
            lblLivroTitulo.Dock = DockStyle.Top;
            lblLivroTitulo.Text = $"Título do Livro: {GetLivroTitulo()}";

            Label lblLivroIsbn = new Label();
            lblLivroIsbn.Dock = DockStyle.Top;
            lblLivroIsbn.Text = $"ISBN do Livro: {GetLivroIsbn()}";

            Label lblAprovada = new Label();
            lblAprovada.Dock = DockStyle.Top;
            lblAprovada.Text = $"Aprovada: {GetAprovada()}";

            Button btnAprovar = new Button();
            btnAprovar.Dock = DockStyle.Bottom;
            btnAprovar.Text = "Aprovar";
            btnAprovar.Click += (sender, e) =>
            {
                AprovarSolicitacao();
            };

            Button btnReprovar = new Button();
            btnReprovar.Dock = DockStyle.Bottom;
            btnReprovar.Text = "Reprovar";
            btnReprovar.Click += (sender, e) =>
            {
                ReprovarSolicitacao();
            };

            Button btnFechar = new Button();
            btnFechar.Dock = DockStyle.Bottom;
            btnFechar.Text = "Fechar";
            btnFechar.Click += (sender, e) => Close();

            Controls.Add(lblBibliotecario);
            Controls.Add(lblDescricao);
            Controls.Add(lblTipoAcervo);
            Controls.Add(lblLivroTitulo);
            Controls.Add(lblLivroIsbn);
            Controls.Add(lblAprovada);

            Controls.Add(btnAprovar);
            Controls.Add(btnReprovar);
            Controls.Add(btnFechar);
        }

        private string GetBibliotecarioNome()
        {
            if (solicitacao is SolicitacaoMudarAcervoLivro mudarAcervo)
                return mudarAcervo.Bibliotecario.NomeCompleto;
            else if (solicitacao is SolicitacaoRequisicaoLivros requisicaoLivros)
                return requisicaoLivros.Bibliotecario.NomeCompleto;

            return string.Empty;
        }

        private string GetDescricao()
        {
            if (solicitacao is SolicitacaoMudarAcervoLivro mudarAcervo)
                return mudarAcervo.Descricao;
            else if (solicitacao is SolicitacaoRequisicaoLivros requisicaoLivros)
                return requisicaoLivros.Descricao;

            return string.Empty;
                
        }

        private string GetTipoAcervo()
        {
            if (solicitacao is SolicitacaoMudarAcervoLivro mudarAcervo)
                return mudarAcervo.TipoAcervo.ToString();
            else if (solicitacao is SolicitacaoRequisicaoLivros requisicaoLivros)
                return requisicaoLivros.TipoAcervo.ToString();

            return string.Empty;
        }

        private string GetLivroTitulo()
        {
            if (solicitacao is SolicitacaoMudarAcervoLivro mudarAcervo)
                return mudarAcervo.Livro.Titulo;
            else if (solicitacao is SolicitacaoRequisicaoLivros requisicaoLivros)
                return requisicaoLivros.Livro.Titulo;

            return string.Empty;
        }

        private string GetLivroIsbn()
        {
            if (solicitacao is SolicitacaoMudarAcervoLivro mudarAcervo)
                return mudarAcervo.Livro.Isbn;
            else if (solicitacao is SolicitacaoRequisicaoLivros requisicaoLivros)
                return requisicaoLivros.Livro.Isbn;

            return string.Empty;
        }

        private bool GetAprovada()
        {
            if (solicitacao is SolicitacaoMudarAcervoLivro mudarAcervo)
                return mudarAcervo.Aprovada;
            else if (solicitacao is SolicitacaoRequisicaoLivros requisicaoLivros)
                return requisicaoLivros.Aprovada;

            return false;
        }

        private void AprovarSolicitacao()
        {
            if (solicitacao is SolicitacaoMudarAcervoLivro mudarAcervo && !mudarAcervo.Aprovada)
            {
                mudarAcervo.Aprovada = true;
                AtualizarLabels();
            }
            else if (solicitacao is SolicitacaoRequisicaoLivros requisicaoLivros && !requisicaoLivros.Aprovada)
            {
                requisicaoLivros.Aprovada = true;
                AtualizarLabels();
            }
            else
            {
                MessageBox.Show("Você não pode aprovar uma solicitação que já foi aprovada!");
            }
        }

        private void ReprovarSolicitacao()
        {
            if (solicitacao is SolicitacaoMudarAcervoLivro mudarAcervo && mudarAcervo.Aprovada)
            {
                mudarAcervo.Aprovada = false;
                AtualizarLabels();
            }
            else if (solicitacao is SolicitacaoRequisicaoLivros requisicaoLivros && requisicaoLivros.Aprovada)
            {
                requisicaoLivros.Aprovada = false;
                AtualizarLabels();
            }
            else
            {
                MessageBox.Show("Você não pode reprovar uma solicitação que já foi reprovada!");
            }
        }

        private void AtualizarLabels()
        {
            GetLabel("lblBibliotecario").Text = $"Bibliotecário: {GetBibliotecarioNome()}";
            GetLabel("lblDescricao").Text = $"Descrição: {GetDescricao()}";
            GetLabel("lblTipoAcervo").Text = $"Tipo de Acervo: {GetTipoAcervo()}";
            GetLabel("lblLivroTitulo").Text = $"Título do Livro: {GetLivroTitulo()}";
            GetLabel("lblLivroIsbn").Text = $"ISBN do Livro: {GetLivroIsbn()}";
            GetLabel("lblAprovada").Text = $"Aprovada: {GetAprovada()}";
        }

        private Label GetLabel(string name)
        {
            return Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == name);
        }

        private string GetLabelText(string labelName)
        {
            switch (labelName)
            {
                case "lblBibliotecario":
                    return $"Bibliotecário: {GetBibliotecarioNome()}";
                case "lblDescricao":
                    return $"Descrição: {GetDescricao()}";
                case "lblTipoAcervo":
                    return $"Tipo de Acervo: {GetTipoAcervo()}";
                case "lblLivroTitulo":
                    return $"Título do Livro: {GetLivroTitulo()}";
                case "lblLivroIsbn":
                    return $"ISBN do Livro: {GetLivroIsbn()}";
                case "lblAprovada":
                    return $"Aprovada: {GetAprovada()}";
                default:
                    return string.Empty;
            }
        }
    }
}
