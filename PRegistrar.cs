using usuario_iniciar;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic.Logging;
using System.Linq;


namespace Proyecto_finalPOO
{
    public partial class PRegistrar : Form
    {
        string ruta = "Server=sql5.freesqldatabase.com;Database=sql5779968;User ID=sql5779968;Password=vwYgj6Syxs;Port=3306;";
        private Correo correito = new Correo();

        public PRegistrar()
        {
            InitializeComponent();
            txt_reg_Us.PlaceholderText = "Ingresa tu usuario:";
            txt_reg_con.PlaceholderText = "Ingresa tu contraseña:";
            txt_reg_Corr.PlaceholderText = "Ingresa tu correo:";
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            lbl_usuario.Text = string.Empty;
            string usuario = txt_reg_Us.Text.Trim();
            string contraseña = txt_reg_con.Text.Trim();
            string correo = txt_reg_Corr.Text.Trim();
            char[] separador = { ';', '@', '°', '(', ')', '*', '?', '¡', '¿', '-', '_', '{', '}', ',', '.',':','^','+','$','"','=','%','#','&','/','<','>' }; 

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
            RegistarUsuario registro = new RegistarUsuario(usuario, contraseña, correo, ruta);
            string resultado = registro.Comprobar_registro();
            lbl_usuario.Text = resultado;
            if (resultado == "El registro fue exitoso")
            {
                registro.agregar_registro();
                string nombre_usuario = registro.obtener_usuario();
                UsuarioActivo.nombre = nombre_usuario;
                this.Hide();
                PPrograma form = new PPrograma(this);
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
            PIniciar formIniciar = new PIniciar(this);
            formIniciar.Show();
            this.Hide();
        }

        private void PRegistrar_Load(object sender, EventArgs e)
        {

        }

        private void btn_cambiarRegistroAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            PRegistrarAdmin form = new PRegistrarAdmin(this);
            form.ShowDialog();
        }
    }
}
