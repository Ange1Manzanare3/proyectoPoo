using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto_finalPOO
{
    public partial class PProgramaAdmin : Form
    {
        string ruta = "Server=sql5.freesqldatabase.com;Database=sql5779968;User ID=sql5779968;Password=vwYgj6Syxs;Port=3306;";
        private PRegistrar formPrincipal;
        int id;

        public PProgramaAdmin(PRegistrar formPrincipal)
        {
            InitializeComponent();
            this.formPrincipal = formPrincipal;
            this.Load += PProgramaAdmin_Load;
            lbl_usuario_activo.Text = UsuarioActivo.nombre;
        }

        public PProgramaAdmin()
        {
            InitializeComponent();
            this.Load += PProgramaAdmin_Load;
        }

        private void PProgramaAdmin_Load(object sender, EventArgs e)
        {
            checkSeleccionados();
        }

        public void checkSeleccionados()
        {
            List<CheckBox> checkBoxes = new List<CheckBox>
            {
                checkBox1,
                checkBox2,
                checkBox3,
                checkBox4,
                checkBox5,
                checkBox6
            };
            List<GroupBox> groupBoxes = new List<GroupBox>
            {
                groupBox1,
                groupBox2,
                groupBox3,
                groupBox4,
                groupBox5,
                groupBox6
            };

            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();
                string consulta = "SELECT Visible, NombreJuego FROM pantalla ORDER BY ID";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        bool visible = reader.GetBoolean("Visible");
                        string NombreJuego = reader.GetString("NombreJuego");
                        checkBoxes[i].Checked = visible;
                        groupBoxes[i].Text = NombreJuego;
                        i++;
                    }
                }
            }
        }

        private void btn_AdministrarUsuario_Click(object sender, EventArgs e)
        {
            PGestionarUsuario form = new PGestionarUsuario();
            form.ShowDialog();
        }

        public void registrarCheck(bool visible, int id)
        {
            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();

                string consulta = "UPDATE pantalla SET Visible = @visible WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@visible", visible);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            id = 1;
            bool visible = checkBox1.Checked;
            registrarCheck(visible, id);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            id = 2;
            bool visible = checkBox2.Checked;
            registrarCheck(visible, id);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            id = 3;
            bool visible = checkBox3.Checked;
            registrarCheck(visible, id);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            id = 4;
            bool visible = checkBox4.Checked;
            registrarCheck(visible, id);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            id = 5;
            bool visible = checkBox5.Checked;
            registrarCheck(visible, id);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            id = 6;
            bool visible = checkBox6.Checked;
            registrarCheck(visible, id);
        }

        public void registrarCambioNombre(int id, string nombreJuego)
        {
            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();

                string consulta = "UPDATE pantalla SET NombreJuego = @NombreJuego WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@NombreJuego", nombreJuego);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cambio realizado con exito", "Ejecutado con exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        public void registrarCambioPrecio(int id, int precioJuego)
        {
            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();

                string consulta = "UPDATE pantalla SET Precio = @Precio WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@Precio", precioJuego);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cambio realizado con exito", "Ejecutado con exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        public void registrarCambioPortada(int id, string rutaPortada)
        {
            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();

                string consulta = "UPDATE pantalla SET Imagen = @Imagen WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@Imagen", rutaPortada);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cambio realizado con exito", "Ejecutado con exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        public void registrarCambioEjecucion(int id, string rutaEjecucion)
        {
            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();

                string consulta = "UPDATE pantalla SET Ejecucion = @Ejecucion WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@Ejecucion", rutaEjecucion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cambio realizado con exito", "Ejecutado con exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        private void btn_cambiarNombre6_Click(object sender, EventArgs e)
        {
            id = 6;
            string nombreJuego = txt_nombre6.Text;
            registrarCambioNombre(id, nombreJuego);
        }

        private void btn_cambiarNombre5_Click(object sender, EventArgs e)
        {
            id = 5;
            string nombreJuego = txt_nombre5.Text;
            registrarCambioNombre(id, nombreJuego);
        }

        private void btn_cambiarNombre4_Click(object sender, EventArgs e)
        {
            id = 4;
            string nombreJuego = txt_nombre4.Text;
            registrarCambioNombre(id, nombreJuego);
        }

        private void btn_cambiarPortada4_Click(object sender, EventArgs e)
        {
            id = 4;
            AbrirArchivo archivo = new AbrirArchivo();
            archivo.OpenArchivo();
            registrarCambioPortada(id, archivo.get_ruta());
        }

        private void btn_cambiarPortada5_Click(object sender, EventArgs e)
        {
            id = 5;
            AbrirArchivo archivo = new AbrirArchivo();
            archivo.OpenArchivo();
            registrarCambioPortada(id, archivo.get_ruta());
        }

        private void btn_cambiarPortada6_Click(object sender, EventArgs e)
        {
            id = 6;
            AbrirArchivo archivo = new AbrirArchivo();
            archivo.OpenArchivo();
            registrarCambioPortada(id, archivo.get_ruta());
        }

        private void btn_cambiarEjecucion6_Click(object sender, EventArgs e)
        {
            id = 6;
            string extension = "Archivos .exe (*.exe)|*.exe";
            AbrirArchivo archivo = new AbrirArchivo();
            archivo.OpenArchivo(extension);
            registrarCambioEjecucion(id, archivo.get_ruta());
        }

        private void btn_cambiarEjecucion5_Click_1(object sender, EventArgs e)
        {
            id = 5;
            string extension = "Archivos .exe (*.exe)|*.exe";
            AbrirArchivo archivo = new AbrirArchivo();
            archivo.OpenArchivo(extension);
            registrarCambioEjecucion(id, archivo.get_ruta());
        }

        private void btn_cambiarEjecucion4_Click(object sender, EventArgs e)
        {
            id = 4;
            string extension = "Archivos .exe (*.exe)|*.exe";
            AbrirArchivo archivo = new AbrirArchivo();
            archivo.OpenArchivo(extension);
            registrarCambioEjecucion(id, archivo.get_ruta());
        }

        private void btn_cambiarEjecucion1_Click(object sender, EventArgs e)
        {
            id = 1;
            string extension = "Archivos .exe (*.exe)|*.exe";
            AbrirArchivo archivo = new AbrirArchivo();
            archivo.OpenArchivo(extension);
            registrarCambioEjecucion(id, archivo.get_ruta());
        }

        private void btn_cambiarEjecucion2_Click(object sender, EventArgs e)
        {
            id = 2;
            string extension = "Archivos .exe (*.exe)|*.exe";
            AbrirArchivo archivo = new AbrirArchivo();
            archivo.OpenArchivo(extension);
            registrarCambioEjecucion(id, archivo.get_ruta());
        }

        private void btn_cambiarEjecucion3_Click(object sender, EventArgs e)
        {
            id = 3;
            string extension = "Archivos .exe (*.exe)|*.exe";
            AbrirArchivo archivo = new AbrirArchivo();
            archivo.OpenArchivo(extension);
            registrarCambioEjecucion(id, archivo.get_ruta());
        }

        private void btn_cambiarPortada1_Click(object sender, EventArgs e)
        {
            id = 1;
            AbrirArchivo archivo = new AbrirArchivo();
            archivo.OpenArchivo();
            registrarCambioPortada(id, archivo.get_ruta());
        }

        private void btn_cambiarPortada2_Click(object sender, EventArgs e)
        {
            id = 2;
            AbrirArchivo archivo = new AbrirArchivo();
            archivo.OpenArchivo();
            registrarCambioPortada(id, archivo.get_ruta());
        }

        private void btn_cambiarPortada3_Click(object sender, EventArgs e)
        {
            id = 3;
            AbrirArchivo archivo = new AbrirArchivo();
            archivo.OpenArchivo();
            registrarCambioPortada(id, archivo.get_ruta());
        }

        private void btn_cambiarNombre1_Click(object sender, EventArgs e)
        {
            id = 1;
            string nombreJuego = txt_nombre1.Text;
            registrarCambioNombre(id, nombreJuego);
        }

        private void btn_cambiarNombre2_Click(object sender, EventArgs e)
        {
            id = 2;
            string nombreJuego = txt_nombre2.Text;
            registrarCambioNombre(id, nombreJuego);
        }

        private void btn_cambiarNombre3_Click(object sender, EventArgs e)
        {
            id = 3;
            string nombreJuego = txt_nombre3.Text;
            registrarCambioNombre(id, nombreJuego);
        }

        private void btn_CambiarPrecio1_Click(object sender, EventArgs e)
        {
            id = 1;
            int precio = Convert.ToInt16(txt_precio1.Text);
            registrarCambioPrecio(id, precio);
        }

        private void btn_CambiarPrecio2_Click(object sender, EventArgs e)
        {
            id = 2;
            int precio = Convert.ToInt16(txt_precio2.Text);
            registrarCambioPrecio(id, precio);
        }

        private void btn_CambiarPrecio3_Click(object sender, EventArgs e)
        {
            id = 3;
            int precio = Convert.ToInt16(txt_precio3.Text);
            registrarCambioPrecio(id, precio);
        }

        private void btn_CambiarPrecio4_Click(object sender, EventArgs e)
        {
            id = 4;
            int precio = Convert.ToInt16(txt_precio4.Text);
            registrarCambioPrecio(id, precio);
        }

        private void btn_CambiarPrecio5_Click(object sender, EventArgs e)
        {
            id = 5;
            int precio = Convert.ToInt16(txt_precio5.Text);
            registrarCambioPrecio(id, precio);
        }

        private void btn_CambiarPrecio6_Click(object sender, EventArgs e)
        {
            id = 6;
            int precio = Convert.ToInt16(txt_precio6.Text);
            registrarCambioPrecio(id, precio);
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btn_cerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            formPrincipal.Show();
            this.Close();
        }
    }
}
