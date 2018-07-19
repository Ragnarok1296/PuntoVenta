using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class Usuarios
    {
        private int id;
        private string usuario;
        private string password;
        private string privilegios;
        private int empleados_Id;

        public Usuarios() { }

        public int Id {
            get => id;
            set => id = value;
        }

        public string Usuario {
            get => usuario;
            set => usuario = value;
        }

        public string Password {
            get => password;
            set => password = value;
        }

        public string Privilegios {
            get => privilegios;
            set => privilegios = value;
        }

        public int Empleados_Id {
            get => empleados_Id;
            set => empleados_Id = value;
        }
    }
}