using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class Proveedores
    {
        private int id;
        private string razonSocial;
        private string direccionFiscal;
        private string direccionUbicacion;
        private string rfc;
        private string nombreContacto;
        private string telefono;
        private string correo;

        public Proveedores() { }

        public int Id {
            get => id;
            set => id = value;
        }

        public string RazonSocial {
            get => razonSocial;
            set => razonSocial = value;
        }

        public string DireccionFiscal {
            get => direccionFiscal;
            set => direccionFiscal = value;
        }

        public string DireccionUbicacion {
            get => direccionUbicacion;
            set => direccionUbicacion = value;
        }

        public string Rfc {
            get => rfc;
            set => rfc = value;
        }

        public string NombreContacto {
            get => nombreContacto;
            set => nombreContacto = value;
        }

        public string Telefono {
            get => telefono;
            set => telefono = value;
        }

        public string Correo {
            get => correo;
            set => correo = value;
        }

    }
}