using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

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
        public void obtenerDatosJuego(int id)
        {
            using (var conexion = new NpgsqlConnection(ruta))
            {
                conexion.Open();


                // Tablas de juego
                // Select: Nombre de columna
                string consulta = @"SELECT nombrejuego, precio, visible, imagen, ejecutable FROM pantalla WHERE id = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nombreJuego = reader["nombrejuego"]?.ToString() ?? string.Empty;

                            if (!reader.IsDBNull(reader.GetOrdinal("precio")))
                                precio = Convert.ToInt32(reader["precio"]);

                            if (!reader.IsDBNull(reader.GetOrdinal("visible")))
                                visible = Convert.ToBoolean(reader["visible"]);

                            rutaImagen = reader["imagen"]?.ToString() ?? string.Empty;
                            rutaEjecucion = reader["ejecutable"]?.ToString() ?? string.Empty;
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
