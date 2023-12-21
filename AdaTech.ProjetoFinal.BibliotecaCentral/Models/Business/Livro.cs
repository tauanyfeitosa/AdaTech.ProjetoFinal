using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal class Livro
    {
        private string _titulo { get; set; }
        private string _autor { get; set; }
        private string _isbn { get; set; }
        private int _anoPublicacao { get; set; }
        private int _edicao { get; set; }
        private string _editora { get; set; }
        private int _exemplares { get; set; }
        private int _exemplaresDisponiveis { get; set; }
        private int _livrosBomEstado { get; set; }
        private int _livrosEstadoMediano { get; set; }
        private int _livrosMauEstado { get; set; }
        private TipoAcervoLivro _tipoAcervoLivro { get; set; }

    }
}