using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class Productos
    {
        private int id;
        private string nombre;
        private string marca;
        private string descripcion;
        private float costoCompra;
        private float costoVenta;
        private int stock;
        private int proveedores_Id;
        private int departamentos_Id;
        private int unidades_Id;

        public Productos() { }

        public int Id {
            get => id;
            set => id = value;
        }

        public string Nombre {
            get => nombre;
            set => nombre = value;
        }

        public string Marca {
            get => marca;
            set => marca = value;
        }

        public string Descripcion {
            get => descripcion;
            set => descripcion = value;
        }

        public float CostoCompra {
            get => costoCompra;
            set => costoCompra = value;
        }

        public float CostoVenta {
            get => costoVenta;
            set => costoVenta = value;
        }

        public int Stock {
            get => stock;
            set => stock = value;
        }

        public int Proveedores_Id {
            get => proveedores_Id;
            set => proveedores_Id = value;
        }

        public int Departamentos_Id {
            get => departamentos_Id;
            set => departamentos_Id = value;
        }

        public int Unidades_Id {
            get => unidades_Id;
            set => unidades_Id = value;
        }
    }
}