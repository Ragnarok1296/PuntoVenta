using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PuntoVentaServidor.Modelos
{
    public class MySQLConexion
    {

        private string server = "ragnarok-projects.mysql.database.azure.com";
        private string user = "Ragnarok1296@ragnarok-projects";
        private string password = "Ragnarok051296";
        private string database = "puntoventa";
        private MySqlConnection conn;


        private MySqlCommand cmd;


        public MySQLConexion() {
            conn = new MySqlConnection("SERVER=" + server + "; DATABASE=" + database + "; UID=" + user + "; PASSWORD=" + password + ";");
        }

        //Verifica si se puede conectar a la base de datos
        #region Conexion
        public bool connection() {

            bool conectado = false;

            try {
                conn.Open();
                conectado = true;
            } catch (Exception) {
                conectado = false;
            } finally {
                conn.Close();
            }

            return conectado;

        }
        #endregion

        //Este metodo devuelve un Datatable con la tabla seleccionada y los campos que le hayas mandado en el WebService
        #region Consulta Busqueda
        public DataTable consulta_busqueda(String query)
        {
            DataTable table = new DataTable();
            
            try {
                conn.Open();
                MySqlDataAdapter select = new MySqlDataAdapter(query, conn);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(select);
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                select.Fill(table);
            } catch (Exception) {

            } finally {
                conn.Close();
            }
            
            return table;

        }
        #endregion

        //Este metodo devuelve un Boleano para saber si la operacion fue un exito, se le pasa como parametro el query con la operacion segun el WebService
        #region Insertar Actualizar Eliminar
        public bool insertar_actualizar_eliminar(string query)
        {
            bool operacion = false;
            
            try {
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                operacion = true;
            }
            catch (Exception) {
                operacion = false;
            } finally {
                conn.Close();
            }
            
            return operacion;

        }
        #endregion

    }
}