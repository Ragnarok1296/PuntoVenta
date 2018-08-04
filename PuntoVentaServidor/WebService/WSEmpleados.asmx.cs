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
    /// Descripción breve de WSEmpleados
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSEmpleados : System.Web.Services.WebService
    {
        private MySQLConexion conexion;
        private Empleados empleados;
        private Usuarios usuarios;

        // Instanciamos la conexion y al modelo
        public WSEmpleados()
        {
            conexion = new MySQLConexion();
            empleados = new Empleados();
            usuarios = new Usuarios();
        }

        [WebMethod]
        public String ConsultarEmpleados(string usuario)
        {
            string json = "";

            usuarios.Usuario = usuario;

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {
                // Creo el query que mandare
                String query = "call ConsultarEmpleados('" + usuarios.Usuario + "')";

                // Mando llamar el metodo de MYSQLConexion el cual me devuelve un datatable y lo serializo
                json = JsonConvert.SerializeObject(conexion.consulta_busqueda(query));
            }

            //Retorno la cadena con formato json
            return json;
        }

        [WebMethod]
        public Boolean InsertarEmpleados(string jsonEmpleado, string jsonUsuario)
        {
            Boolean operacion = false;

            //Desserializo la cadena que manda el cliente en formato json y lo convierto en el modelo que tengo
            empleados = JsonConvert.DeserializeObject<Empleados>(jsonEmpleado.Replace("[", "").Replace("]", ""));
            usuarios = JsonConvert.DeserializeObject<Usuarios>(jsonUsuario.Replace("[", "").Replace("]", ""));

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call InsertarEmpleado('" + empleados.Nombre + "','"
                    + empleados.Apellido + "','" + empleados.Telefono + "','" + empleados.FechaIngreso + "','"
                    + empleados.Departamento + "','" + empleados.Puesto + "','"
                    + usuarios.Usuario + "','" + usuarios.Password + "','" + usuarios.Privilegios + "')";

                //Mando llamar al metodo para inssertar el cual me devolvera un booleano 
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;

        }

        [WebMethod]
        public Boolean EliminarEmpleado(int id)
        {
            Boolean operacion = false;

            empleados.Id = id;

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call EliminarEmpleado('" + empleados.Id.ToString() + "')";

                //Mando llamar al metodo para eliminar el cual me devolvera un booleano 
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;
        }

        [WebMethod]
        public Boolean ActualizarEmpleado(string jsonEmpleados, string jsonUsuarios)
        {
            Boolean operacion = false;

            //Desserializo la cadena que manda el cliente en formato json y lo convierto en el modelo que tengo
            empleados = JsonConvert.DeserializeObject<Empleados>(jsonEmpleados.Replace("[", "").Replace("]", ""));
            usuarios = JsonConvert.DeserializeObject<Usuarios>(jsonUsuarios.Replace("[", "").Replace("]", ""));

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                String query = "call ActualizarEmpleado('" + empleados.Id.ToString() + "','" + empleados.Nombre + "','"
                    + empleados.Apellido + "','" + empleados.Telefono + "','" + empleados.FechaIngreso + "','"
                    + empleados.Departamento + "','" + empleados.Puesto + "','" + usuarios.Id + "','"
                    + usuarios.Usuario + "','" + usuarios.Password + "','" + usuarios.Privilegios + "')";

                //Mando llamar al metodo para actualizar el cual me devolvera un booleano
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;
        }

        [WebMethod]
        public String BuscarEmpleado(string busqueda, string usuario)
        {
            string json = "";

            usuarios.Usuario = usuario;

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call BusquedaEmpleados('" + busqueda + "','" + usuarios.Usuario +"')";

                // Mando llamar el metodo de MYSQLConexion el cual me devuelve un datatable y lo serializo
                json = JsonConvert.SerializeObject(conexion.consulta_busqueda(query));
            }

            //Retorno la cadena con formato json
            return json;
        }

        [WebMethod]
        public String Login(string usuario, string password)
        {
            string json = "";

            usuarios.Usuario = usuario;
            usuarios.Password = password;

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call Login('" + usuarios.Usuario + "','" + usuarios.Password + "')";

                // Mando llamar el metodo de MYSQLConexion el cual me devuelve un datatable y lo serializo
                json = JsonConvert.SerializeObject(conexion.consulta_busqueda(query));
            }

            //Retorno la cadena con formato json
            return json.Replace("[", "").Replace("]", "");
        }

        [WebMethod]
        public String UsuarioDatos(string usuario)
        {
            string json = "";

            usuarios.Usuario = usuario;

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                // Creo el query que mandare
                String query = "call UsuarioDatos('" + usuarios.Usuario + "')";

                // Mando llamar el metodo de MYSQLConexion el cual me devuelve un datatable y lo serializo
                json = JsonConvert.SerializeObject(conexion.consulta_busqueda(query));
            }

            //Retorno la cadena con formato json
            return json.Replace("[", "").Replace("]", "");
        }

        [WebMethod]
        public Boolean UsuarioActualizar(string json)
        {
            Boolean operacion = false;

            //Desserializo la cadena que manda el cliente en formato json y lo convierto en el modelo que tengo
            usuarios = JsonConvert.DeserializeObject<Usuarios>(json.Replace("[", "").Replace("]", ""));

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                String query = "call UsuarioActualizar('" + usuarios.Id.ToString() + "','" + usuarios.Usuario + "','"
                    + usuarios.Password + "','" + usuarios.Privilegios + "')";

                //Mando llamar al metodo para actualizar el cual me devolvera un booleano
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;
        }

    }
}
