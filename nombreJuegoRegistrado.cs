using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proyecto_finalPOO
{
    internal class nombreJuegoRegistrado
    {
        protected string nombreJuego = string.Empty, ruta = string.Empty, rutaImagen = string.Empty, rutaEjecucion = string.Empty;
        protected int id, precio;
        protected bool visible;
        public nombreJuegoRegistrado(string nueva_ruta)
        {
            this.ruta = nueva_ruta;
        }
        //public  nombreJuegoRegistrado(int nueva_id, string nueva_ruta)
        //{
        //    this.ruta = nueva_ruta;
        //    this.id = nueva_id;
        //}
        public void obtenerNombreJuego(int id)
        {
            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();
                string consulta = "SELECT NombreJuego FROM pantalla WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nombreJuego = reader.GetString("NombreJuego");
                        }
                    }
                }
            }
        }
        public void obtenerPrecioJuego(int id)
        {
            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();
                string consulta = "SELECT Precio FROM pantalla WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            precio = reader.GetInt16("Precio");
                        }
                    }
                }
            }
        }
        public void obtenerGruposVisibles(int id)
        {
            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();
                string consulta = "SELECT Visible FROM pantalla WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            visible = reader.GetBoolean("Visible");
                        }
                    }
                }
            }
        }
        public void obtenerEJecuciones(int id)
        {
            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();
                string consulta = "SELECT Imagen, Ejecucion FROM pantalla WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rutaImagen = reader.GetString("Imagen");
                            rutaEjecucion = reader.GetString("Ejecucion");
                        }
                    }
                }
            }
        }

        public string obtener_nombreJuego() { return nombreJuego; }
        public bool obtener_Juegovisible() { return visible; }
        public int obtener_PrecioJuego() { return precio; }
        public string obtener_rutaImagen() { return rutaImagen; }
        public string obtener_rutaEjecucion() { return rutaEjecucion; }
    }
}
