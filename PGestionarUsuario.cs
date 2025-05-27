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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Proyecto_finalPOO
{

    public partial class PGestionarUsuario : Form
    {
        string ruta = "Server=sql5.freesqldatabase.com;Database=sql5779968;User ID=sql5779968;Password=vwYgj6Syxs;Port=3306;";
        private Correo correito = new Correo();


        public PGestionarUsuario()
        {
            InitializeComponent();
            imprimirNombres();
        }
        public void imprimirNombres()
        {
            txt_contraseña.Text = string.Empty;
            txt_correo.Text = string.Empty;
            txt_Nombre.Text = string.Empty;
            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();
                string consulta = "SELECT usuario, codigo FROM usuarios ORDER BY ID";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codigo = reader.GetInt16("codigo");
                        if (codigo != 777)
                        {
                            string NombreUsuario = reader.GetString("usuario");
                            listBox1.Items.Add(NombreUsuario);
                        }
                    }
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreUsuario = listBox1.SelectedItem.ToString();
            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();
                string consulta = "SELECT correo, contrasena, credito FROM usuarios WHERE usuario = @usuario";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
                    txt_Nombre.Text = nombreUsuario;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string correo_existente = reader.GetString("correo");
                            txt_correo.Text = correo_existente;
                            string contraseña_existente = reader.GetString("contrasena");
                            txt_contraseña.Text = contraseña_existente;
                            int credito_existente = reader.GetInt16("credito");
                            txt_credito.Text = credito_existente.ToString();
                        }
                    }
                }
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            string usuario = txt_Nombre.Text.Trim(), correo = txt_correo.Text.Trim(), contraseña = txt_contraseña.Text.Trim(), credito = txt_credito.Text;
            if (string.IsNullOrWhiteSpace(contraseña) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(txt_credito.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!correito.ValidarCorreo(correo))
            {
                MessageBox.Show("Por favor, ingresa un correo válido (@gmail.com, @hotmail.com, @outlook.com).");
                return;
            }
            char[] separador = { ';', '@', '°', '(', ')', '*', '?', '¡', '¿', '-', '_', '{', '}', ',', '.', ':', '^', '+', '$', '"', '=', '%', '#', '&', '/', '<', '>' };

            bool contieneCaracterEspecial = false;

            foreach (char letra in contraseña)
            {
                if (separador.Contains(letra))
                {
                    contieneCaracterEspecial = true;
                    break;
                }
            }
            if (contraseña.Length < 8 || !contieneCaracterEspecial)
            {
                MessageBox.Show("La contraseña al menos debe tener 8 palabras y un caracter.",
                    "Campos sin acompletar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();

                string consulta = "UPDATE usuarios SET correo = @correo, contrasena = @contrasena, credito = @credito WHERE usuario = @usuario";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@contrasena", contraseña);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@credito", credito);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Cambio realizado con exito", "Ejecutado con exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            string usuario = txt_Nombre.Text.Trim();
            using (MySqlConnection conexion = new MySqlConnection(ruta))
            {
                conexion.Open();
                string consulta = "DELETE FROM usuarios WHERE usuario = @usuario";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario borrada con exito", "Eliminacion con exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            listBox1.Items.Clear();
            imprimirNombres();
        }
    }
}
