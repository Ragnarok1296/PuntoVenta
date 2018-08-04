using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class Empleados
    {
        private int id;
        private string nombre;
        private string apellido;
        private string telefono;
        private string fechaIngreso;
        private string departamento;
        private string puesto;

        public Empleados() { }

        public int Id {
            get => id;
            set => id = value;
        }

        public string Nombre {
            get => nombre;
            set => nombre = value;
        }

        public string Apellido {
            get => apellido;
            set => apellido = value;
        }

        public string Telefono {
            get => telefono;
            set => telefono = value;
        }

        public string FechaIngreso {
            get => fechaIngreso;
            set => fechaIngreso = value;
        }

        public string Departamento {
            get => departamento;
            set => departamento = value;
        }

        public string Puesto {
            get => puesto;
            set => puesto = value;
        }

    }
}