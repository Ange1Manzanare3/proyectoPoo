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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Proyecto_finalPOO
{

    public partial class PPrograma : Form
    {
        private PRegistrar formPrincipal;
        string ruta = "Host=caboose.proxy.rlwy.net;Port=49656;Username=postgres;Password=xwWxhVadXdbkkiCQHtQlxtNxTQyhPVGp;Database=railway;SSL Mode=Require;Trust Server Certificate=true";
        public PPrograma(PRegistrar formPrincipal)
        {
            InitializeComponent();
            //lblUsuario.Text = UsuarioActivo.nombre;
            this.Load += PProgramaAdmin_Load;
            this.formPrincipal = formPrincipal;
        }
        public PPrograma()
        {
            InitializeComponent();
            this.Load += PProgramaAdmin_Load;
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
                labels[i + 6].Text = datos[i].PrecioJuego.ToString("C"); // formato moneda
            }
        }
        private void btn_Jugar_Loteria_Click(object sender, EventArgs e)
        {
            Process.Start("Juegos\\loteria\\JuegoLoteria.exe");
        }

        private void btn_Juego_preguntas_Click(object sender, EventArgs e)
        {
            Process.Start("Juegos\\preguntas\\ProyectoFinal.exe");
        }

        private void PPrograma_Load(object sender, EventArgs e)
        {

        }

        private void btn_obtener_loteria_Click(object sender, EventArgs e)
        {
            btn_Jugar_Loteria.Visible = true;
            // nombre se usuario, nombre juego, obtener
            string usuario = UsuarioActivo.nombre.ToString(), nombre_juego = "Loteria";
            lblUsuario.Text = usuario;
            //obtenerJuego obtenerJuego = new obtenerJuego(nombre_juego, usuario);
        }

        private void btn_obtener_preguntas_Click(object sender, EventArgs e)
        {

        }

        private void btn_jugar_musica_Click(object sender, EventArgs e)
        {
            Process.Start("Juegos\\ProyectoFinalQuiz\\ProyectoFinalQuiz\\bin\\Debug\\ProyectoFinalQuiz.exe");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_jugar_musica.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process.Start("D:\\POO\\Unidad 3\\Proyecto_finalPOO\\bin\\Debug\\net8.0-windows\\Juegos\\Debug\\ProyectoFinalQuiz.exe");

        }
    }
}
