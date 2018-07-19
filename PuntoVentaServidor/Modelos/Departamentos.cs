using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class Departamentos
    {
        private int id;
        private string departamento;

        public Departamentos() { }

        public int Id {
            get => id;
            set => id = value;
        }

        public string Departamento {
            get => departamento;
            set => departamento = value;
        }
    }
}