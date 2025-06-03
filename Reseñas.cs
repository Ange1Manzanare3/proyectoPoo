using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_finalPOO
{
    public partial class Reseñas : Form
    {
        public int idJuego;
        public string usuarioActual;
       

        public string conexionDB = "Host=caboose.proxy.rlwy.net;Port=49656;Username=postgres;Password=xwWxhVadXdbkkiCQHtQlxtNxTQyhPVGp;Database=railway;SSL Mode=Require;Trust Server Certificate=true";

        public Reseñas(int idJuego, string usuario, string conexion)
        {
            InitializeComponent();


            this.idJuego = idJuego;
            this.usuarioActual = usuario;
            this.conexionDB = conexion;

        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ejecutando CargarReseñas()"); 
            lstReseñas.Items.Clear(); 

            try
            {
                using (var conexion = new Npgsql.NpgsqlConnection(conexionDB))
                {
                    conexion.Open();
                    string consulta = "SELECT usuario, comentario, calificacion FROM reseñas WHERE juego = @idJuego ORDER BY id DESC";

                    using (var cmd = new Npgsql.NpgsqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idJuego", idJuego.ToString());

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("No hay reseñas en la base de datos.");
                                lstReseñas.Items.Add("No hay reseñas para este juego aún.");
                                return;
                            }

                            while (reader.Read())
                            {
                                string user = reader["usuario"].ToString();
                                string comentario = reader["comentario"].ToString();
                                string calificacionTexto = reader["calificacion"].ToString();
                                int calificacion = int.TryParse(calificacionTexto, out int resultado) ? resultado : 0; //Convertir texto a numero

                                Console.WriteLine($"Usuario: {user}, Calificación: {calificacion}, Comentario: {comentario}");

                                lstReseñas.Items.Add($"⭐ {calificacion}/5 - {user}: {comentario}");
                            }

                            lstReseñas.Refresh();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reseñas: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void CargarReseñas()
        {
            MessageBox.Show("Ejecutando CargarReseñas()"); // Confirmar que se está ejecutando
            lstReseñas.Items.Clear(); // Limpia la lista antes de agregar nuevas reseñas

            try
            {
                using (var conexion = new Npgsql.NpgsqlConnection(conexionDB))
                {
                    conexion.Open();
                    string consulta = "SELECT usuario, comentario, calificacion FROM reseñas WHERE juego = @idJuego ORDER BY id DESC";

                    using (var cmd = new Npgsql.NpgsqlCommand(consulta, conexion))
                    {
                        // Convertimos idJuego a string para evitar el error de tipo
                        cmd.Parameters.AddWithValue("@idJuego", idJuego.ToString());

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("No hay reseñas en la base de datos.");
                                lstReseñas.Items.Add("No hay reseñas para este juego aún."); // Muestra mensaje en el ListBox
                                return;
                            }

                            while (reader.Read())
                            {
                                string user = reader["usuario"].ToString();
                                string comentario = reader["comentario"].ToString();
                                int calificacion = reader.GetInt32(reader.GetOrdinal("calificacion"));

                                // Muestra los datos en un MessageBox para verificar si están llegando
                                Console.WriteLine($"Usuario: {user}, Calificación: {calificacion}, Comentario: {comentario}");

                                // Agrega la reseña al ListBox de forma segura
                                lstReseñas.Items.Add($"⭐ {calificacion}/5 - {user}: {comentario}");
                            }

                            // Refresca el ListBox después de agregar todas las reseñas
                            lstReseñas.Refresh();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reseñas: {ex.Message}\n{ex.StackTrace}");
            }
        }



        private void Reseñas_Load(object sender, EventArgs e)
        {
            CargarReseñas();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
