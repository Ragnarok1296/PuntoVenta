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
        private int departamentos_Id;
        private int puestos_Id;

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

        public int Departamentos_Id {
            get => departamentos_Id;
            set => departamentos_Id = value;
        }

        public int Puestos_Id {
            get => puestos_Id;
            set => puestos_Id = value;
        }

    }
}