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
    /// Descripción breve de WSUnidades
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSUnidades : System.Web.Services.WebService
    {
        private MySQLConexion conexion;
        private Unidades unidades;

        // Instanciamos la conexion y al modelo
        public WSUnidades()
        {
            conexion = new MySQLConexion();
            unidades = new Unidades();
        }

        [WebMethod]
        public String ConsultarUnidades()
        {
            string json = "";

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {
                // Creo el query que mandare
                String query = "call ConsultarUnidades()";

                // Mando llamar el metodo de MYSQLConexion el cual me devuelve un datatable y lo serializo
                json = JsonConvert.SerializeObject(conexion.consulta_busqueda(query));
            }

            //Retorno la cadena con formato json
            return json;
        }

        [WebMethod]
        public Boolean InsertarUnidad(string unidad)
        {
            Boolean operacion = false;

            unidades.Unidad = unidad;

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call InsertarUnidad('" + unidades.Unidad + "')";

                //Mando llamar al metodo para inssertar el cual me devolvera un booleano
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;

        }

        [WebMethod]
        public Boolean EliminarUnidad(int id)
        {
            Boolean operacion = false;

            unidades.Id = id;

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call EliminarUnidade('" + unidades.Id.ToString() + "')";

                //Mando llamar al metodo para eliminar el cual me devolvera un booleano
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;
        }
    }
}
