using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Proyecto_finalPOO
{
    public partial class PPrograma : Form
    {
        public static List<string> carrito = new List<string>();
        public static List<string> juegosComprados = new List<string>();

        private PRegistrar formPrincipal;
        string ruta = "Host=caboose.proxy.rlwy.net;Port=49656;Username=postgres;Password=xwWxhVadXdbkkiCQHtQlxtNxTQyhPVGp;Database=railway;SSL Mode=Require;Trust Server Certificate=true";

        public PPrograma(PRegistrar formPrincipal)
        {
            InitializeComponent();
            this.Load += PProgramaAdmin_Load;
            this.formPrincipal = formPrincipal;
            this.Activated += PPrograma_Activated;
        }

        public PPrograma()
        {
            InitializeComponent();
            this.Load += PProgramaAdmin_Load;
            this.Activated += PPrograma_Activated;
        }

        private async void PProgramaAdmin_Load(object sender, EventArgs e)
        {
            var datos = await Task.Run(() => ObtenerDatosJuegos());
            ActualizarControles(datos);
        }

        // Clase para guardar los datos de cada juego
        private class DatosJuego
        {
            public string NombreJuego { get; set; }
            public bool JuegoVisible { get; set; }
            public string RutaImagen { get; set; }
            public decimal PrecioJuego { get; set; }
        }

        private List<DatosJuego> ObtenerDatosJuegos()
        {
            nombreJuegoRegistrado registro = new nombreJuegoRegistrado(ruta);
            List<DatosJuego> listaDatos = new List<DatosJuego>();

            for (int i = 0; i < 6; i++)
            {
                registro.obtenerDatosJuego(i + 1);
                DatosJuego datos = new DatosJuego
                {
                    NombreJuego = registro.obtener_nombreJuego(),
                    JuegoVisible = registro.obtener_Juegovisible(),
                    RutaImagen = registro.obtener_rutaImagen(),
                    PrecioJuego = registro.obtener_PrecioJuego()
                };
                listaDatos.Add(datos);
            }

            return listaDatos;
        }

        private void ActualizarControles(List<DatosJuego> datos)
        {
            if (InvokeRequired)
            {
                Invoke(() => ActualizarControles(datos));
                return;
            }

            // Se actualizan Labels, GroupBoxes y PictureBoxes
            List<Label> labels = new List<Label>
            {
                label1, label2, label3, label4, label5, label6,
                label7, label8, label9, label10, label11, label12
            };
            List<GroupBox> groups = new List<GroupBox>
            {
                groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6
            };
            List<PictureBox> pictures = new List<PictureBox>
            {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6
            };

            for (int i = 0; i < datos.Count; i++)
            {
                labels[i].Text = datos[i].NombreJuego;
                groups[i].Visible = datos[i].JuegoVisible;
                pictures[i].ImageLocation = datos[i].RutaImagen;
                labels[i + 6].Text = datos[i].PrecioJuego.ToString("C"); // Formato moneda
            }
        }

        // Métodos que inician los juegos cuando ya se realizaron las compras
        private void btn_Jugar_Loteria_Click(object sender, EventArgs e)
        {
            Process.Start("Juegos\\loteria\\JuegoLoteria.exe");
        }

        private void btn_Juego_preguntas_Click(object sender, EventArgs e)
        {
            Process.Start("Juegos\\preguntas\\ProyectoFinal.exe");
        }

        private void btn_jugar_musica_Click(object sender, EventArgs e)
        {
            Process.Start("Juegos\\debug\\ProyectoFinalQuiz.exe");
        }

        private void btn_Jugar_Battlefield_Click(object sender, EventArgs e)
        {
            Process.Start("Juegos\\debug\\BATTLESHIP P.FINAL.exe");
        }

        private void PPrograma_Load(object sender, EventArgs e)
        {
        }

        // MÉTODOS DE "OBTENER" (AGREGAR AL CARRITO) – NO activan botones de jugar
        private void btn_obtener_loteria_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Juego 'Loteria' fue agregado al carrito");
            PPrograma.carrito.Add("Lotería - $240");
            // Se elimina la línea que activa el botón para jugar
            string usuario = UsuarioActivo.nombre.ToString(), nombre_juego = "Loteria";
            lblUsuario.Text = usuario;
        }

        private void btn_obtener_preguntas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Juego 'Quiz Preguntas' fue agregado al carrito");
            PPrograma.carrito.Add("Quiz Preguntas - $310");
            // Se elimina la línea que activa el botón para jugar
            string usuario = UsuarioActivo.nombre.ToString(), nombre_juego = "Quiz Preguntas";
            lblUsuario.Text = usuario;
        }

        // El botón de "Música", que ya funcionaba según lo esperado:
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Juego 'Musica' fue agregado al carrito");
            PPrograma.carrito.Add("Música - $310");
            string usuario = UsuarioActivo.nombre.ToString(), nombre_juego = "¨Musica";
            lblUsuario.Text = usuario;

            // No se activa el botón para jugar aquí; se hará tras la compra.
        }

        // Método que actualiza la visibilidad de los botones para jugar según los juegos comprados
        private void ActualizarBotonesDeJugar()
        {
            btn_Jugar_Loteria.Visible = PPrograma.juegosComprados.Any(j => j.Contains("Lotería"));
            btn_Juego_preguntas.Visible = PPrograma.juegosComprados.Any(j => j.Contains("Quiz Preguntas"));
            btn_jugar_musica.Visible = PPrograma.juegosComprados.Any(j => j.Contains("Música"));
            btn_Jugar_Battlefield.Visible = PPrograma.juegosComprados.Any(j => j.Contains("Battlefield"));
        }

        private void PPrograma_Activated(object sender, EventArgs e)
        {
            ActualizarBotonesDeJugar();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process.Start("D:\\POO\\Unidad 3\\Proyecto_finalPOO\\bin\\Debug\\net8.0-windows\\Juegos\\Debug\\ProyectoFinalQuiz.exe");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Carrito carritoVentana = new Carrito();
            carritoVentana.Show();
        }

        // Otros botones de "agregar" se corrigen de forma similar:
        private void btn_agregar_Juego4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Juego 'Battlefield' fue agregado al carrito");
            PPrograma.carrito.Add("Battlefield - $240");
            string usuario = UsuarioActivo.nombre.ToString(), nombre_juego = "Battlefield";
            lblUsuario.Text = usuario;
        }

        private void btn_agregar_Juego5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Juego 'Gta 7' fue agregado al carrito");
            PPrograma.carrito.Add("Gta 7 - $89");
            string usuario = UsuarioActivo.nombre.ToString(), nombre_juego = "Gta 7";
            lblUsuario.Text = usuario;
        }

        private void btn_agregar_Juego6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Juego 'Minecraft 2' fue agregado al carrito");
            PPrograma.carrito.Add("Minecraft 2 - $89");
            string usuario = UsuarioActivo.nombre.ToString(), nombre_juego = "Minecraft 2";
            lblUsuario.Text = usuario;
        }
    }
}
