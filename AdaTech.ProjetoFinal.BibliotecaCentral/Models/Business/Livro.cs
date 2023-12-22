using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
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

        internal string Titulo
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
        internal string Autor
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
        internal string Isbn
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
            private set
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

        internal TipoAcervoLivro tipoAcervoLivro
        {
            get
            {
                return _tipoAcervoLivro;
            }
            private set
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
            this.tipoAcervoLivro = tipoAcervoLivro;
        }
    }
}