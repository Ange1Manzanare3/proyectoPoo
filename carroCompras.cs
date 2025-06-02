using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Proyecto_finalPOO
{
    internal class carroCompras
    {
        private static List<string> carrito = new List<string>();
        public static List<int> idsJuegos = new List<int>();

        public static event Action CarritoActualizado;
        public static event Action compraActualizada;
        public static void NotificarCompraActualizada()
        {
            compraActualizada?.Invoke();
        }
        public static bool AgregarJuego(string nombre, string precio, int id)
        {
            string producto = $"{nombre} - {precio}";

            if (carrito.Contains(producto))
            {
                return false; 
            }

            carrito.Add(producto);
            idsJuegos.Add(id);
            CarritoActualizado?.Invoke(); // Lanza el evento
            return true; 
        }
        public static void ComprarJuego(decimal total, string ruta, decimal saldoUsuario)
        {
            string usuario = UsuarioActivo.nombre.ToString();

            using (NpgsqlConnection conexion = new NpgsqlConnection(ruta))
            {
                conexion.Open();

                string consultaUsuarios = "UPDATE usuarios SET credito = @credito WHERE usuario = @usuario";
                using (NpgsqlCommand cmd = new NpgsqlCommand(consultaUsuarios, conexion))
                {
                    cmd.Parameters.AddWithValue("@credito", saldoUsuario);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.ExecuteNonQuery();
                }
                foreach (int idJuego in carroCompras.ObtenerIds())
                {
                    if (idJuego < 1 || idJuego > 6)
                        continue;

                    string nombreColumna = $"juego{idJuego}";

                    string consulta = $"UPDATE juegos SET {nombreColumna} = @valor WHERE usuario = @usuario";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@valor", true);
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            carrito.Clear();
            idsJuegos.Clear();
            CarritoActualizado?.Invoke();
            compraActualizada?.Invoke();
        }
        public static void RegresarJuego(decimal precioJuego, string ruta, decimal saldoUsuario, int idJuego)
        {
            string usuario = UsuarioActivo.nombre.ToString();

            using (NpgsqlConnection conexion = new NpgsqlConnection(ruta))
            {
                conexion.Open();

                string consultaUsuarios = "UPDATE usuarios SET credito = @credito WHERE usuario = @usuario";
                using (NpgsqlCommand cmd = new NpgsqlCommand(consultaUsuarios, conexion))
                {
                    cmd.Parameters.AddWithValue("@credito", saldoUsuario+precioJuego);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.ExecuteNonQuery();
                }
                string nombreColumna = $"juego{idJuego}";
                string consulta = $"UPDATE juegos SET {nombreColumna} = @valor WHERE usuario = @usuario";
                using (NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@valor", false);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.ExecuteNonQuery();
                }
            }
            compraActualizada?.Invoke();
        }
        public static void EliminarJuego(string juego)
        {
            int index = carrito.IndexOf(juego);
            if (index >= 0)
            {
                carrito.RemoveAt(index);
                idsJuegos.RemoveAt(index);
                CarritoActualizado?.Invoke();
            }
        }
        public static void VaciarJuegos()
        {
            carrito.Clear();
            idsJuegos.Clear();
            CarritoActualizado?.Invoke(); 
        }

        public static List<string> ObtenerCarrito()
        {
            return new List<string>(carrito);
        }
        public static List<int> ObtenerIds() => new List<int>(idsJuegos);
    }
}
