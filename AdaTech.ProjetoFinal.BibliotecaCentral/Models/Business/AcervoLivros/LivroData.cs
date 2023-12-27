﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.AcervoLivros
{
    internal static class LivroData
    {
        private static List<Livro> _acervoLivros = new List<Livro>();

        internal static void IncluirLivros(List<Livro> livros)
        {
            _acervoLivros.AddRange(livros);
        }

        internal static void IncluirLivros(string titulo, string autor, string isbn, int anoPublicacao, int edicao, string editora, 
            int exemplares)
        {
            _acervoLivros.Add(new Livro(titulo, autor, isbn, anoPublicacao, edicao, editora, exemplares-1, TipoAcervoLivro.AcervoPublico));
            _acervoLivros.Add(new Livro(titulo, autor, isbn+'b', anoPublicacao, edicao, editora, 1, TipoAcervoLivro.AcervoParticular));

        }

        internal static void LerBinLivros()
        {
        }

        internal static void AtualizarLivros(List<Livro> livros)
        {

        }

        internal static List<Livro> ListarLivros(TipoAcervoLivro? tipoAcervoLivro)
        {
            List<Livro> livrosAcervo = _acervoLivros.Where(l => l.TipoAcervoLivro == tipoAcervoLivro).ToList();
            return livrosAcervo;
        }

        internal static void ExcluirLivros(string[] isbnLivros)
        {
            foreach (string isbn in isbnLivros)
            {
                Livro livro = _acervoLivros.Where(l => l.Isbn == isbn).FirstOrDefault();
                _acervoLivros.Remove(livro);
            }
        }

        internal static Livro SelecionarLivro(string isbn)
        {
            return _acervoLivros.Where(l => l.Isbn == isbn).FirstOrDefault();
        }
    }
}