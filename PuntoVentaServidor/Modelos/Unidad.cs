using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class Unidad
    {
        private int id;
        private string medida;

        public Unidad() { }

        public int Id {
            get => id;
            set => id = value;
        }

        public string Medida {
            get => medida;
            set => medida = value;
        }
    }
}