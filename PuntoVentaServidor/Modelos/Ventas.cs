using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class Ventas
    {
        private int id;
        private float subTotal;
        private float total;
        private string fechaVenta;
        private int empleados_Id;

        public Ventas() { }

        public int Id {
            get => id;
            set => id = value;
        }

        public float SubTotal {
            get => subTotal;
            set => subTotal = value;
        }

        public float Total {
            get => total;
            set => total = value;
        }

        public string FechaVenta {
            get => fechaVenta;
            set => fechaVenta = value;
        }

        public int Empleados_Id {
            get => empleados_Id;
            set => empleados_Id = value;
        }

    }
}