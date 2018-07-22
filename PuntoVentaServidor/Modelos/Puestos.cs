using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class Puestos
    {
        private int id;
        private string puesto;

        public Puestos() { }

        public int Id {
            get => id;
            set => id = value;
        }

        public string Puesto {
            get => puesto;
            set => puesto = value;
        }
    }
}