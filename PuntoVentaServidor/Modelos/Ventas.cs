using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class Ventas
    {
        private int id;
        private Double subTotal;
        private Double total;
        private string fechaVenta;
        private string empleados;

        public Ventas() { }

        public int Id {
            get => id;
            set => id = value;
        }

        public Double SubTotal {
            get => subTotal;
            set => subTotal = value;
        }

        public Double Total {
            get => total;
            set => total = value;
        }

        public string FechaVenta {
            get => fechaVenta;
            set => fechaVenta = value;
        }

        public string Empleados {
            get => empleados;
            set => empleados = value;
        }

    }
}