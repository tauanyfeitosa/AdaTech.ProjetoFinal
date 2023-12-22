using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosComunidadeAcademica
{
    internal sealed class Sessao
    {
        
        private static Sessao instance;
        private Usuario usuarioLogado;
        public static Sessao getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Sessao();
                }
                return instance;
            }
        }
        private Sessao() { }


        public bool UsuarioEstaLogado => usuarioLogado != null;

        public void IniciarSessao(Usuario usuario)
        {
            if (UsuarioEstaLogado)
            {
                throw new InvalidOperationException("Já existe um usuário logado. Encerre a sessão atual para iniciar outra.");
            }

            usuarioLogado = usuario;
        }

        public Usuario ObterUsuarioLogado()
        {
            if (!UsuarioEstaLogado)
            {
                throw new InvalidOperationException("Nenhum usuário está logado no momento.");
            }

            return usuarioLogado;
        }
     
        public void EncerrarSessao()
        {
            usuarioLogado = null;
        }
    }
}
