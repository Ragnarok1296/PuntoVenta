using Newtonsoft.Json;
using PuntoVentaServidor.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PuntoVentaServidor.WebService
{
    /// <summary>
    /// Descripción breve de WSVentas
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSVentas : System.Web.Services.WebService
    {
        private MySQLConexion conexion;
        private ProductosVentas productosVentas;
        private Ventas ventas;

        // Instanciamos la conexion y al modelo
        public WSVentas()
        {
            conexion = new MySQLConexion();
            productosVentas = new ProductosVentas();
            ventas = new Ventas();
        }

        [WebMethod]
        public String ConsultarVentas()
        {
            string json = "";

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {
                // Creo el query que mandare
                String query = "call ConsultarVentas()";

                // Mando llamar el metodo de MYSQLConexion el cual me devuelve un datatable y lo serializo
                json = JsonConvert.SerializeObject(conexion.consulta_busqueda(query));
            }

            //Retorno la cadena con formato json
            return json;
        }

        [WebMethod]
        public Boolean InsertarVentaGeneral(string json)
        {
            Boolean operacion = false;

            //Desserializo la cadena que manda el cliente en formato json y lo convierto en el modelo que tengo
            ventas = JsonConvert.DeserializeObject<Ventas>(json.Replace("[", "").Replace("]", ""));

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call InsertarVentaGeneral('" + ventas.SubTotal.ToString() + "','"
                    + ventas.Total.ToString() + "','" + ventas.FechaVenta + "','" + ventas.Empleados_Id.ToString() + "')";

                //Mando llamar al metodo para inssertar el cual me devolvera un booleano 
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;

        }

        [WebMethod]
        public Boolean InsertarVentaDetalles(string json)
        {
            Boolean operacion = false;

            //Desserializo la cadena que manda el cliente en formato json y lo convierto en el modelo que tengo
            productosVentas = JsonConvert.DeserializeObject<ProductosVentas>(json.Replace("[", "").Replace("]", ""));

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call InsertarVentaDetalles('" + productosVentas.PrecioUnitario.ToString() + "','"
                    + productosVentas.Cantidad.ToString() + "','" + productosVentas.PrecioTotal.ToString() + "','" 
                    + productosVentas.Productos_Id.ToString() + "')";

                //Mando llamar al metodo para inssertar el cual me devolvera un booleano 
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;

        }

        [WebMethod]
        public String BuscarVentas(string empleado, string fechaInicio, string fechaFinal)
        {
            string json = "";

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call BusquedaVentas('" + empleado + "','" + fechaInicio + "','" + fechaFinal + "')";

                // Mando llamar el metodo de MYSQLConexion el cual me devuelve un datatable y lo serializo
                json = JsonConvert.SerializeObject(conexion.consulta_busqueda(query));
            }

            //Retorno la cadena con formato json
            return json;
        }

        [WebMethod]
        public String DetallesVenta(int id)
        {
            string json = "";

            ventas.Id = id;
            
            // Verifico si la conexion es correcta
            if (conexion.connection())
            {
                // Creo el query que mandare
                String query = "call VentasDetalles('" + ventas.Id + "')";

                // Mando llamar el metodo de MYSQLConexion el cual me devuelve un datatable y lo serializo
                json = JsonConvert.SerializeObject(conexion.consulta_busqueda(query));
            }

            //Retorno la cadena con formato json
            return json;
        }
    }
}
