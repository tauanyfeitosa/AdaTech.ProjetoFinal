using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Business.Reserva;
using AdaTech.ProjetoFinal.BibliotecaCentral.Models.Usuarios.UsuariosData;
using AdaTech.ProjetoFinal.BibliotecaCentral.Views.Janelas.JanelasCA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Controllers.PrincipalControllers.PainelComunidadeController
{
    internal class CancelarReservaController
    {
        private readonly JanelaCancelarReserva form;

        internal CancelarReservaController(JanelaCancelarReserva cancelarReserva)
        {
            form = cancelarReserva;
            form.CancelarReservaClick += CancelarReservaClick;
        }
        internal void CarregarReserva()
        {
            List<ReservaLivro> lista = new List<ReservaLivro>();
            List<ReservaLivro> listaReservas = ReservaLivroData.ListarReservasUsuario(form.UsuarioLogado);

            foreach(ReservaLivro reserva in listaReservas)
            {
                if (reserva.Emprestimo.Devolucao == false && reserva.StatusReserva != StatusReserva.Cancelada) 
                {
                    lista.Add(reserva);
                }
            }

            form.CmbReservas.DisplayMember = "NomeEstilo";
            form.CmbReservas.DataSource = lista;

            if(listaReservas == null)
            {
                form.MostrarMensagem("O usuário não possui reservas");
            }
        }

        private void CancelarReservaClick(object sender, EventArgs e)
        {
            if (form.CmbReservas.SelectedItem != null)
            {
                ReservaLivro reserva = form. CmbReservas.SelectedItem as ReservaLivro;
                reserva.CancelarReserva();
                form.MostrarMensagem("Reserva cancelada com sucesso!");
                LimparCampos();
                form.Close();
            }
            else
            {
                form.MostrarMensagem("Verifique o preenchimento de todos os campos");
            }
        }

        internal void LimparCampos()
        {
            form.CmbReservas.SelectedIndex = -1;
        }
    }
}
