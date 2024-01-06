using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Emprestimos;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros
{
    internal class Livro
    {
        private string _titulo;
        private string _autor;
        private string _isbn;
        private int _anoPublicacao;
        private int _edicao;
        private string _editora;
        private int _exemplares;
        private int _exemplaresDisponiveis;
        private int _livrosBomEstado;
        private int _livrosEstadoMediano;
        private int _livrosMauEstado;
        private TipoAcervoLivro _tipoAcervoLivro;

        public string Titulo
        {
            get
            {
                return _titulo;
            }
            private set
            {
                _titulo = value;
            }
        }
        public string Autor
        {
            get
            {
                return _autor;
            }
            private set
            {
                _autor = value;
            }
        }
        public string Isbn
        {
            get
            {
                return _isbn;
            }
            private set
            {
                _isbn = value;
            }
        }
        internal int AnoPublicacao
        {
            get
            {
                return _anoPublicacao;
            }
            private set
            {
                _anoPublicacao = value;
            }
        }
        internal int Edicao
        {
            get
            {
                return _edicao;
            }
            private set
            {
                _edicao = value;
            }
        }
        internal string Editora
        {
            get
            {
                return _editora;
            }
            private set
            {
                _editora = value;
            }
        }
        internal int Exemplares
        {
            get
            {
                return _exemplares;
            }
            private set
            {
                _exemplares = value;
            }
        }
        internal int ExemplaresDisponiveis
        {
            get
            {
                return _exemplaresDisponiveis;
            } 
            set
            {
                _exemplaresDisponiveis = value;
            }
        }
        internal int LivrosBomEstado
        {
            get
            {
                return _livrosBomEstado;
            }
            private set
            {
                _livrosBomEstado = value;
            }
        }
        internal int LivrosEstadoMediano
        {
            get
            {
                return _livrosEstadoMediano;
            }
            private set
            {
                _livrosEstadoMediano = value;
            }
        }
        internal int LivrosMauEstado
        {
            get
            {
                return _edicao;
            }
            private set
            {
                _edicao = value;
            }
        }

        internal TipoAcervoLivro TipoAcervoLivro
        {
            get
            {
                return _tipoAcervoLivro;
            }
            set
            {
                _tipoAcervoLivro = value;
            }
        }

        internal Livro(string titulo, string autor, string isbn, int anoPublicacao, 
            int edicao, string editora, int exemplares, TipoAcervoLivro tipoAcervoLivro)
        {
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
            AnoPublicacao = anoPublicacao;
            Edicao = edicao;
            Editora = editora;
            Exemplares = exemplares;
            ExemplaresDisponiveis = exemplares;
            LivrosBomEstado = exemplares;
            LivrosEstadoMediano = 0;
            LivrosMauEstado = 0;
            this.TipoAcervoLivro = tipoAcervoLivro;
        }

        public Livro(
           string titulo,
           string autor,
           string isbn,
           int anoPublicacao,
           int edicao,
           string editora,
           int exemplares,
           int exemplaresDisponiveis,
           int livrosBomEstado,
           int livrosEstadoMediano,
           int livrosMauEstado,
           TipoAcervoLivro tipoAcervoLivro)
        {
            _titulo = titulo;
            _autor = autor;
            _isbn = isbn;
            _anoPublicacao = anoPublicacao;
            _edicao = edicao;
            _editora = editora;
            _exemplares = exemplares;
            _exemplaresDisponiveis = exemplaresDisponiveis;
            _livrosBomEstado = livrosBomEstado;
            _livrosEstadoMediano = livrosEstadoMediano;
            _livrosMauEstado = livrosMauEstado;
            _tipoAcervoLivro = tipoAcervoLivro;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Livro other = (Livro)obj;
            return string.Equals(_isbn, other._isbn);
        }

        public override int GetHashCode()
        {
            return _isbn?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return $"- Titulo: {_titulo}\r\n" +
                $"- Autor:{_autor}\r\n" +
                $"- Isbn: {_isbn}\r\n" +
                $"- Ano Publicação: {_anoPublicacao}\r\n" +
                $"- Edição: {_edicao}\r\n" +
                $"- Editora: {_editora}\r\n" +
                $"- Exemplares: {_exemplares}\r\n" +
                $"- Exemplares Disponiveis: {_exemplaresDisponiveis}\r\n" +
                $"- Livros em bom estado {_livrosBomEstado}\r\n" +
                $"- Livros em estado mediano {_livrosEstadoMediano}\r\n" +
                $"- Livros em mau estado {_livrosMauEstado}\r\n" +
                $"- Tipo de Acervo: {_tipoAcervoLivro}";
        }
    }
}