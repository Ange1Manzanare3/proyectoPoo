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
        public int idJuegoActual;




        public string conexionDB = "Host=caboose.proxy.rlwy.net;Port=49656;Username=postgres;Password=xwWxhVadXdbkkiCQHtQlxtNxTQyhPVGp;Database=railway;SSL Mode=Require;Trust Server Certificate=true";

        public Reseñas(int idJuego, string usuario, string conexion)
        {
            InitializeComponent();


            this.idJuegoActual = idJuego;
            this.usuarioActual = usuario;
            this.conexionDB = conexion;

        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Publicando reseña - idJuegoActual: {idJuegoActual}");

            try
            {
                using (var conexion = new Npgsql.NpgsqlConnection(conexionDB))
                {
                    conexion.Open();
                    string consultaInsert = "INSERT INTO reseñas (usuario, comentario, calificacion, juego) VALUES (@usuario, @comentario, @calificacion, @idJuego)";

                    using (var cmd = new Npgsql.NpgsqlCommand(consultaInsert, conexion))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuarioActual);
                        cmd.Parameters.AddWithValue("@comentario", txtReseña.Text); // Capturamos el comentario desde el TextBox
                        cmd.Parameters.AddWithValue("@calificacion", Convert.ToInt32(numCalificacion.Value)); // Capturamos la calificación desde el NumericUpDown
                        cmd.Parameters.AddWithValue("@idJuego", idJuegoActual);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Reseña publicada correctamente.");
                    }
                }

                CargarReseñas(); // Recargamos para ver la nueva reseña
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al publicar reseña: {ex.Message}\n{ex.StackTrace}");
            }
        }


        private void CargarReseñas()
        {
            MessageBox.Show($"Ejecutando CargarReseñas() - idJuegoActual: {idJuegoActual}");
            lstReseñas.Items.Clear();

            try
            {
                using (var conexion = new Npgsql.NpgsqlConnection(conexionDB))
                {
                    conexion.Open();
                    string consulta = "SELECT usuario, comentario, calificacion FROM reseñas WHERE juego = @idJuego ORDER BY id DESC";

                    using (var cmd = new Npgsql.NpgsqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idJuego", idJuegoActual.ToString());

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

                                // Corregimos la lectura de calificación
                                string calificacionTexto = reader["calificacion"].ToString();
                                int calificacion = int.TryParse(calificacionTexto, out int resultado) ? resultado : 0;

                                Console.WriteLine($"Usuario: {user}, Calificación: {calificacion}, Comentario: {comentario}");
                                lstReseñas.Items.Add($"⭐ {calificacion}/10 - {user}: {comentario}");
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
