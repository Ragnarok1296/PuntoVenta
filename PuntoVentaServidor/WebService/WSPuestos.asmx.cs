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
    /// Descripción breve de WSPuestos
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSPuestos : System.Web.Services.WebService
    {
        private MySQLConexion conexion;
        private Puestos puestos;

        // Instanciamos la conexion y al modelo
        public WSPuestos()
        {
            conexion = new MySQLConexion();
            puestos = new Puestos();
        }

        [WebMethod]
        public String ConsultarPuestos()
        {
            string json = "";

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {
                // Creo el query que mandare
                String query = "call ConsultarPuestos()";

                // Mando llamar el metodo de MYSQLConexion el cual me devuelve un datatable y lo serializo
                json = JsonConvert.SerializeObject(conexion.consulta_busqueda(query));
            }

            //Retorno la cadena con formato json
            return json;
        }

        [WebMethod]
        public Boolean InsertarPuesto(string puesto)
        {
            Boolean operacion = false;

            puestos.Puesto = puesto;

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call InsertarPuesto('" + puestos.Puesto + "')";

                //Mando llamar al metodo para inssertar el cual me devolvera un booleano 
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;

        }

        [WebMethod]
        public Boolean EliminarPuesto(int id)
        {
            Boolean operacion = false;

            puestos.Id = id;

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call EliminarPuesto('" + puestos.Id.ToString() + "')";

                //Mando llamar al metodo para eliminar el cual me devolvera un booleano 
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;
        }
    }
}
