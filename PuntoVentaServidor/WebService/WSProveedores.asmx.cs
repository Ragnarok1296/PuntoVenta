﻿using System;
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
        private MySQLConexion conexion;
        private Proveedores proveedores;

        // Instanciamos la conexion y al modelo
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
        public Boolean InsertarProveedores(string json)
        {
            Boolean operacion = false;

            //Desserializo la cadena que manda el cliente en formato json y lo convierto en el modelo que tengo 
            proveedores = JsonConvert.DeserializeObject<Proveedores>(json.Replace("[", "").Replace("]", ""));

            // Verifico si la conexion es correcta
            if (conexion.connection()) {

                // Creo el query que mandare
                String query = "call InsertarProveedor('" + proveedores.RazonSocial + "','" 
                    + proveedores.DireccionFiscal + "','" + proveedores.DireccionUbicacion + "','" 
                    + proveedores.Rfc + "','" + proveedores.NombreContacto + "','" 
                    + proveedores.Telefono + "','" + proveedores.Correo + "')";

                //Mando llamar al metodo para inssertar el cual me devolvera un booleano 
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;
            
        }

        [WebMethod]
        public Boolean EliminarProveedores(int id)
        {
            Boolean operacion = false;

            proveedores.Id = id;

            // Verifico si la conexion es correcta
            if (conexion.connection()) {

                // Creo el query que mandare
                String query = "call EliminarProveedor('" + proveedores.Id.ToString() + "')";

                //Mando llamar al metodo para eliminar el cual me devolvera un booleano 
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
            return operacion;
        }

        [WebMethod]
        public Boolean ActualizarProveedores(string json)
        {
            Boolean operacion = false;

            //Desserializo la cadena que manda el cliente en formato json y lo convierto en el modelo que tengo 
            proveedores = JsonConvert.DeserializeObject<Proveedores>(json.Replace("[", "").Replace("]", ""));

            // Verifico si la conexion es correcta
            if (conexion.connection())
            {

                String query = "call ActualizarProveedor('" + proveedores.Id.ToString() + "','" + proveedores.RazonSocial + "','"
                    + proveedores.DireccionFiscal + "','" + proveedores.DireccionUbicacion + "','"
                    + proveedores.Rfc + "','" + proveedores.NombreContacto + "','"
                    + proveedores.Telefono + "','" + proveedores.Correo + "')";

                //Mando llamar al metodo para actualizar el cual me devolvera un booleano
                if (conexion.insertar_actualizar_eliminar(query))
                    operacion = true;
            }

            //Retorno un booleano para saber si la operacion fue exitosa
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
