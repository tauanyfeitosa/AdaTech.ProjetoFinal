﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoFinal.BibliotecaCentral
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary> teste git
        [STAThread]
        static void Main()
        {
            LivroData.imprimirLivros();
        }
    }
}
