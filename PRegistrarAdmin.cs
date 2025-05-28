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
using usuario_iniciar;


namespace Proyecto_finalPOO
{
    public partial class PRegistrarAdmin : Form
    {
        private PRegistrar formPrincipal;
        string ruta = "Host=caboose.proxy.rlwy.net;Port=49656;Username=postgres;Password=xwWxhVadXdbkkiCQHtQlxtNxTQyhPVGp;Database=railway;SSL Mode=Require;Trust Server Certificate=true";
        private Correo correito = new Correo();
        public PRegistrarAdmin(PRegistrar formPrincipal)
        {
            InitializeComponent();
            txt_reg_Us.PlaceholderText = "Ingresa tu usuario:";
            txt_reg_con.PlaceholderText = "Ingresa tu contraseña:";
            txt_reg_Corr.PlaceholderText = "Ingresa tu correo:";
            this.formPrincipal = formPrincipal;
        }
       
        private void btn_registrar_Admin_Click(object sender, EventArgs e)
        {
            lbl_usuario.Text = string.Empty;
            string usuario = txt_reg_Us.Text.Trim();
            string contraseña = txt_reg_con.Text.Trim();
            string correo = txt_reg_Corr.Text.Trim();
            if (txt_reg_code.Text == string.Empty)
            {
                MessageBox.Show("Por favor, completa todos los campos antes de iniciar sesion.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int codigo = Convert.ToInt32(txt_reg_code.Text);
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

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña) || string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Por favor, completa todos los campos antes de registrarte.",
                    "Campos vacíos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            else if (!correito.ValidarCorreo(correo))
            {
                MessageBox.Show("Por favor, ingresa un correo válido (@gmail.com, @hotmail.com, @outlook.com).");
                return;
            }
            RegistarUsuario registro = new RegistarUsuario(usuario, contraseña, correo, ruta, codigo);
            string resultado = registro.Comprobar_registro(codigo);
            lbl_usuario.Text = resultado;
            if (resultado == "El registro fue exitoso")
            {
                registro.agregar_registro(codigo);
                string nombre_usuario = registro.obtener_usuario();
                UsuarioActivo.nombre = nombre_usuario;
                this.Hide();
                PProgramaAdmin form = new PProgramaAdmin(formPrincipal);
                form.ShowDialog();
                this.Close();
            }
            else
            {
                lbl_usuario.ForeColor = Color.DarkRed;
            }
        }

        private void btn_cambiarForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            PIniciarAdmin form = new PIniciarAdmin(formPrincipal);
            form.ShowDialog();
            this.Close();
        }

        private void btn_cambiarRegistroNormal_Click(object sender, EventArgs e)
        {
            this.Hide();
            formPrincipal.Show();
            this.Close();
        }

        private void PRegistrarAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            formPrincipal.Show();
        }

        private void txt_reg_code_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
