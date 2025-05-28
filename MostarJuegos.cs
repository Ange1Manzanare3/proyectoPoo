using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Proyecto_finalPOO
{
    internal class MostarJuegos
    {
        private string cadenaConexion;
        private bool Juego1, Juego2, Juego3;
        public MostarJuegos(bool nuevo_Juego1, bool nuevo_Juego2, bool nuevo_Juego3, string nueva_ruta)
        {
            Juego1 = nuevo_Juego1;
            Juego2 = nuevo_Juego2;
            Juego3 = nuevo_Juego3;
            cadenaConexion = nueva_ruta;
        }
        public void agregar_pantalla()
        {
            using (NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = "INSERT INTO pantalla (MostrarJuego1, MostrarJuego2, MostrarJuego3) VALUES (@Juego1, @Juego2, @Juego3)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@Juego1", Juego1);
                    cmd.Parameters.AddWithValue("@Juego2", Juego2);
                    cmd.Parameters.AddWithValue("@Juego3", Juego3);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
