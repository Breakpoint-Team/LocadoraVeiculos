﻿using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract void Inserir();

        public abstract void Editar();

        public abstract void Excluir();

        public abstract UserControl ObtemListagem();

        public abstract ConfiguracaoToolboxBase ObtemConfiguracaoToolbox();

    }
}