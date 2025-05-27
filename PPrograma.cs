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
using MySql.Data.MySqlClient;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Proyecto_finalPOO
{

    public partial class PPrograma : Form
    {
        private PRegistrar formPrincipal;
        string ruta = "Server=sql5.freesqldatabase.com;Database=sql5779968;User ID=sql5779968;Password=vwYgj6Syxs;Port=3306;";
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
            //lblUsuario.Text = UsuarioActivo.nombre;
            this.Load += PProgramaAdmin_Load;
        }

        private void PProgramaAdmin_Load(object sender, EventArgs e)
        {
            iniciosEjecucion();
        }
        public void iniciosEjecucion()
        {
            nombreJuegoRegistrado registro = new nombreJuegoRegistrado(ruta);
            List<Label> labels = new List<Label>
            {
                label1,
                label2,
                label3,
                label4,
                label5,
                label6,
                label7,
                label8,
                label9,
                label10,
                label11,
                label12
            };
            List<GroupBox> groups = new List<GroupBox>
            {
                groupBox1,
                groupBox2,
                groupBox3,
                groupBox4,
                groupBox5,
                groupBox6
            };
            List<PictureBox> pictures = new List<PictureBox>
            {
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6
            };
            
            for (int i = 0; i < 6; i++)
            {
                registro.obtenerNombreJuego(i+1);
                labels[i].Text = registro.obtener_nombreJuego();
                registro.obtenerGruposVisibles(i+1);
                groups[i].Visible = registro.obtener_Juegovisible();
                registro.obtenerEJecuciones(i+1);
                pictures[i].ImageLocation = registro.obtener_rutaImagen();
                registro.obtenerPrecioJuego(i+1);
                labels[i+6].Text = registro.obtener_PrecioJuego().ToString();
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
    }
}
