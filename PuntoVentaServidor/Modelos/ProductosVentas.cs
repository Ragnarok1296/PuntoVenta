using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class ProductosVentas
    {
        private int id;
        private float precioUnitario;
        private int cantidad;
        private float precioTotal;
        private int productos_Id;
        private int ventas_Id;

        public ProductosVentas() { }

        public int Id {
            get => id;
            set => id = value;
        }

        public float PrecioUnitario {
            get => precioUnitario;
            set => precioUnitario = value;
        }

        public int Cantidad {
            get => cantidad; set => cantidad = value; }

        public float PrecioTotal {
            get => precioTotal;
            set => precioTotal = value;
        }

        public int Productos_Id {
            get => productos_Id;
            set => productos_Id = value;
        }

        public int Ventas_Id {
            get => ventas_Id;
            set => ventas_Id = value;
        }

    }
}