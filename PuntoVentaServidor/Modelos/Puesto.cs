using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class Puesto
    {
        private int id;
        private string puestos;

        public Puesto() { }

        public int Id {
            get => id;
            set => id = value;
        }

        public string Puestos {
            get => puestos;
            set => puestos = value;
        }
    }
}