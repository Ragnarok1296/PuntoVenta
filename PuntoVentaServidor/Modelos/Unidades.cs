using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class Unidades
    {
        private int id;
        private string unidad;

        public Unidades() { }

        public int Id {
            get => id;
            set => id = value;
        }

        public string Unidad {
            get => unidad;
            set => unidad = value;
        }
    }
}