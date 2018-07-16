using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PuntoVentaServidor.Modelos;
using Newtonsoft.Json;

namespace PuntoVentaServidor.WebService
{
    /// <summary>
    /// Descripción breve de WSProveedores
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSProveedores : System.Web.Services.WebService
    {
        MySQLConexion conexion;
        Proveedores proveedores;

        // Instanciamos la conexion y al proveedor
        public WSProveedores()
        {
            conexion = new MySQLConexion();
            proveedores = new Proveedores();
        }
        
        [WebMethod]
        public String ConsultarProveedores()
        {
            string json = "";

            // Verifico si la conexion es correcta
            if (conexion.connection()) {
                // Creo el query que mandare
                String query = "call ConsultarProveedores()";

                // Mando llamar el metodo de MYSQLConexion el cual me devuelve un datatable y lo serializo
                json = JsonConvert.SerializeObject(conexion.consulta_busqueda(query));
            }

            //Retorno la cadena con formato json
            return json;
        }

        [WebMethod]
        public String InsertarProveedores(string json)
        {
            string operacion = "0";

            //Desserializo la cadena que manda el cliente en formato json y lo convierto en el modelo que tengo de Provedores
            proveedores = JsonConvert.DeserializeObject<Proveedores>(json);

            // Verifico si la conexion es correcta
            if (conexion.connection()) {

                // Creo el query que mandare
                String query = "call InsertarProveedor('" + proveedores.Id.ToString() + "','" + proveedores.RazonSocial + "','" 
                    + proveedores.DireccionFiscal + "','" + proveedores.DireccionUbicacion + "','" 
                    + proveedores.Rfc + "','" + proveedores.NombreContacto + "','" 
                    + proveedores.Telefono + "','" + proveedores.Correo + "')";

                //Mando llamar al metodo para inssertar el cual me devolvera un booleano y asi retorno un 1 si todo salio bien 
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = "1";
            }

            //Retorno un string con un 1 o 0 para saber si la operacion fue exitosa
            return operacion;
            
        }

        [WebMethod]
        public String EliminarProveedores(string id)
        {
            string operacion = "0";

            // Verifico si la conexion es correcta
            if (conexion.connection()) {

                // Creo el query que mandare
                String query = "call EliminarProveedor('" + id + "')";

                //Mando llamar al metodo para eliminar el cual me devolvera un booleano y asi retorno un 1 si todo salio bien 
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = "1";
            }

            //Retorno un string con un 1 o 0 para saber si la operacion fue exitosa
            return operacion;
        }

        [WebMethod]
        public String ActualizarProveedores(string json)
        {
            string operacion = "0";

            //Desserializo la cadena que manda el cliente en formato json y lo convierto en el modelo que tengo de Provedores
            proveedores = JsonConvert.DeserializeObject<Proveedores>(json);

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                String query = "call ActualizarProveedor('" + proveedores.Id.ToString() + "','" + proveedores.RazonSocial + "','"
                    + proveedores.DireccionFiscal + "','" + proveedores.DireccionUbicacion + "','"
                    + proveedores.Rfc + "','" + proveedores.NombreContacto + "','"
                    + proveedores.Telefono + "','" + proveedores.Correo + "')";

                //Mando llamar al metodo para actualizar el cual me devolvera un booleano y asi retorno un 1 si todo salio bien 
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = "1";
            }

            //Retorno un string con un 1 o 0 para saber si la operacion fue exitosa
            return operacion;
        }

        [WebMethod]
        public String BuscarProveedores(string busqueda)
        {
            string json = "";

            // Verifico si la conexion es correcta
            if (conexion.connection()) {

                // Creo el query que mandare
                String query = "call BusquedaProveedores('" + busqueda + "')";

                // Mando llamar el metodo de MYSQLConexion el cual me devuelve un datatable y lo serializo
                json = JsonConvert.SerializeObject(conexion.consulta_busqueda(query));
            }

            //Retorno la cadena con formato json
            return json;
        }

    }
}
