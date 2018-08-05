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
    /// Descripción breve de WSProductos
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSProductos : System.Web.Services.WebService
    {
        private MySQLConexion conexion;
        private Productos productos;

        // Instanciamos la conexion y al modelo
        public WSProductos()
        {
            conexion = new MySQLConexion();
            productos = new Productos();
        }

        [WebMethod]
        public String ConsultarProductos()
        {
            string json = "";

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {
                // Creo el query que mandare
                String query = "call ConsultarProductos()";

                // Mando llamar el metodo de MYSQLConexion el cual me devuelve un datatable y lo serializo
                json = JsonConvert.SerializeObject(conexion.consulta_busqueda(query));
            }

            //Retorno la cadena con formato json
            return json;
        }

        [WebMethod]
        public Boolean InsertarProducto(string json)
        {
            Boolean operacion = false;

            //Desserializo la cadena que manda el cliente en formato json y lo convierto en el modelo que tengo
            productos = JsonConvert.DeserializeObject<Productos>(json.Replace("[", "").Replace("]", ""));

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call InsertarProducto('" + productos.Codigo + "','" + productos.Nombre + "','"
                    + productos.Marca + "','" + productos.Descripcion + "','" + productos.CostoCompra.ToString() + "','"
                    + productos.CostoVenta.ToString() + "','" + productos.Stock.ToString() + "','"
                    + productos.Proveedor + "','" + productos.Departamento + "','" + productos.Unidad + "')";

                //Mando llamar al metodo para inssertar el cual me devolvera un booleano 
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;

        }

        [WebMethod]
        public Boolean EliminarProducto(int id)
        {
            Boolean operacion = false;

            productos.Id = id;

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call EliminarProducto('" + productos.Id.ToString() + "')";

                //Mando llamar al metodo para eliminar el cual me devolvera un booleano 
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;
        }

        [WebMethod]
        public Boolean ActualizarProducto(string json)
        {
            Boolean operacion = false;

            //Desserializo la cadena que manda el cliente en formato json y lo convierto en el modelo que tengo
            productos = JsonConvert.DeserializeObject<Productos>(json.Replace("[", "").Replace("]", ""));

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                String query = "call ActualizarProducto('" + productos.Id.ToString() + "','" + productos.Codigo + "','" + productos.Nombre + "','"
                    + productos.Marca + "','" + productos.Descripcion + "','" + productos.CostoCompra.ToString() + "','"
                    + productos.CostoVenta.ToString() + "','" + productos.Stock.ToString() + "','"
                    + productos.Proveedor + "','" + productos.Departamento + "','" + productos.Unidad + "')";

                //Mando llamar al metodo para actualizar el cual me devolvera un booleano
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;
        }

        [WebMethod]
        public String BuscarProductos(string busqueda)
        {
            string json = "";

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call BusquedaProductos('" + busqueda + "')";

                // Mando llamar el metodo de MYSQLConexion el cual me devuelve un datatable y lo serializo
                json = JsonConvert.SerializeObject(conexion.consulta_busqueda(query));
            }

            //Retorno la cadena con formato json
            return json;
        }
    }
}
