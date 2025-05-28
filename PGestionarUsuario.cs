using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Proyecto_finalPOO
{

    public partial class PGestionarUsuario : Form
    {
        string ruta = "Host=caboose.proxy.rlwy.net;Port=49656;Username=postgres;Password=xwWxhVadXdbkkiCQHtQlxtNxTQyhPVGp;Database=railway;SSL Mode=Require;Trust Server Certificate=true";
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
            txt_credito.Text = string.Empty;

            using (NpgsqlConnection conexion = new NpgsqlConnection(ruta))
            {
                conexion.Open();
                string consulta = "SELECT usuario, codigo FROM usuarios ORDER BY ID";

                using (NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codigo = Convert.ToInt32(reader["codigo"]);
                        if (codigo != 777)
                        {
                            string NombreUsuario = reader["usuario"].ToString();
                            listBox1.Items.Add(NombreUsuario);
                        }
                    }
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string usuarioSeleccionado = listBox1.SelectedItem.ToString();

            using (NpgsqlConnection conexion = new NpgsqlConnection(ruta))
            {
                conexion.Open();
                string consulta = "SELECT correo, contrasena, credito, usuario FROM usuarios WHERE usuario = @usuario";

                using (NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuarioSeleccionado);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txt_Nombre.Text = reader.GetString("usuario");
                            txt_correo.Text = reader.GetString("correo");
                            txt_contraseña.Text = reader.GetString("contrasena");
                            txt_credito.Text = reader.GetInt32("credito").ToString();
                        }
                    }
                }
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            string usuarioAntiguo = listBox1.SelectedItem.ToString().Trim();
            string nuevoUsuario = txt_Nombre.Text.Trim(), correo = txt_correo.Text.Trim(), contraseña = txt_contraseña.Text.Trim();
            int credito = Convert.ToInt16(txt_credito.Text.Trim());
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
            using (NpgsqlConnection conexion = new NpgsqlConnection(ruta))
            {
                conexion.Open();

                // Actualizar datos del usuario en tabla usuarios
                string consultaUsuarios = "UPDATE usuarios SET correo = @correo, contrasena = @contrasena, credito = @credito, usuario = @nuevoUsuario WHERE usuario = @usuarioAntiguo";
                using (NpgsqlCommand cmd = new NpgsqlCommand(consultaUsuarios, conexion))
                {
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@contrasena", contraseña);
                    cmd.Parameters.AddWithValue("@credito", credito);
                    cmd.Parameters.AddWithValue("@nuevoUsuario", nuevoUsuario);
                    cmd.Parameters.AddWithValue("@usuarioAntiguo", usuarioAntiguo);
                    cmd.ExecuteNonQuery();
                }

                // Actualizar el usuario en tabla juegos para mantener coherencia
                string consultaJuegos = "UPDATE juegos SET usuario = @nuevoUsuario WHERE usuario = @usuarioAntiguo";
                using (NpgsqlCommand cmd = new NpgsqlCommand(consultaJuegos, conexion))
                {
                    cmd.Parameters.AddWithValue("@nuevoUsuario", nuevoUsuario);
                    cmd.Parameters.AddWithValue("@usuarioAntiguo", usuarioAntiguo);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cambio realizado con éxito", "Ejecutado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            listBox1.Items.Clear();
            imprimirNombres();
        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            string usuario = txt_Nombre.Text.Trim();
            using (NpgsqlConnection conexion = new NpgsqlConnection(ruta))
            {
                conexion.Open();
                string consulta = "DELETE FROM usuarios WHERE usuario = @usuario";
                using (NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario borrada con exito", "Eliminacion con exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                string consultaa = "DELETE FROM juegos WHERE usuario = @usuario";
                using (NpgsqlCommand cmd = new NpgsqlCommand(consultaa, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.ExecuteNonQuery();
                }
            }
            listBox1.Items.Clear();
            imprimirNombres();
        }
    }
}
