using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class Productos
    {
        private int id;
        private string codigo;
        private string nombre;
        private string marca;
        private string descripcion;
        private Decimal costoCompra;
        private Decimal costoVenta;
        private int stock;
        private string proveedor;
        private string departamento;
        private string unidad;

        public Productos() { }

        public int Id {
            get => id;
            set => id = value;
        }

        public string Codigo {
            get => codigo;
            set => codigo = value;
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

        public Decimal CostoCompra {
            get => costoCompra;
            set => costoCompra = value;
        }

        public Decimal CostoVenta {
            get => costoVenta;
            set => costoVenta = value;
        }

        public int Stock {
            get => stock;
            set => stock = value;
        }

        public string Proveedor {
            get => proveedor;
            set => proveedor = value;
        }

        public string Departamento {
            get => departamento;
            set => departamento = value;
        }

        public string Unidad {
            get => unidad;
            set => unidad = value;
        }
        
    }
}