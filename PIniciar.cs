using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using usuario_iniciar;
using MySql.Data.MySqlClient;


namespace Proyecto_finalPOO
{
    public partial class PIniciar : Form
    {
        private PRegistrar formPrincipal;
        string ruta = "Server=sql5.freesqldatabase.com;Database=sql5779968;User ID=sql5779968;Password=vwYgj6Syxs;Port=3306;";
        public PIniciar(PRegistrar formPrincipal)
        {
            InitializeComponent();
            txt_Usuario.PlaceholderText = "Ingresa tu usuario:";
            txt_contraseña.PlaceholderText = "Ingresa tu contraseña:";
            txt_Correo.PlaceholderText = "Ingresa tu correo:";
            this.formPrincipal = formPrincipal;
        }

        private void btn_iniciar_sesion_Click(object sender, EventArgs e)
        {
            lbl_usuario.Text = string.Empty;
            string usuario = txt_Usuario.Text.Trim();
            string contraseña = txt_contraseña.Text.Trim();
            string correo = txt_Correo.Text.Trim();
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña) || string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Por favor, completa todos los campos antes de iniciar sesion.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            IniciarUsuario inicio = new IniciarUsuario(usuario, contraseña, correo, ruta);
            string mensaje = inicio.Comprobar_Inicio();
            lbl_usuario.Text = mensaje;
            if (mensaje == "Inicio de sesion exitoso")
            {
                string nombre_usuario = inicio.obtener_usuario();
                UsuarioActivo.nombre = nombre_usuario;
                this.Hide();
                PPrograma form = new PPrograma(formPrincipal);
                form.ShowDialog();
                this.Close();
            }
            else
            {
                lbl_usuario.ForeColor = Color.DarkRed;
            }
        }


        private void btn_cerrar_sesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            formPrincipal.Show();
            this.Close();
        }

        private void btn_iniciar_administrador_Click(object sender, EventArgs e)
        {
            this.Hide();
            PIniciarAdmin form = new PIniciarAdmin(formPrincipal);
            form.ShowDialog();
            this.Close();
        }

        private void PIniciar_Leave(object sender, EventArgs e)
        {
            
        }

        private void PIniciar_FormClosing(object sender, FormClosingEventArgs e)
        {
            formPrincipal.Show();
        }
    }
}
