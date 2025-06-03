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
        private Carrito carritoVentana;
        private PRegistrar formPrincipal;
        string ruta = "Host=caboose.proxy.rlwy.net;Port=49656;Username=postgres;Password=xwWxhVadXdbkkiCQHtQlxtNxTQyhPVGp;Database=railway;SSL Mode=Require;Trust Server Certificate=true";
        int id;

        public PPrograma(PRegistrar formPrincipal)
        {
            InitializeComponent();
            this.Load += PProgramaAdmin_Load;
            this.formPrincipal = formPrincipal;
            carroCompras.compraActualizada += compra_Actualizado;
            lblUsuario.Text = UsuarioActivo.nombre.ToString();
        }

        //public PPrograma()
        //{
        //    InitializeComponent();
        //    this.Load += PProgramaAdmin_Load;
        //    //this.Activated += PPrograma_Activated;
        //    lblUsuario.Text = UsuarioActivo.nombre.ToString();
        //}
        private void compra_Actualizado()
        {
            PProgramaAdmin_Load(this, EventArgs.Empty);
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
            public bool carritoVisible { get; set; }
            public string RutaImagen { get; set; }
            public decimal PrecioJuego { get; set; }
        }

        private List<DatosJuego> ObtenerDatosJuegos()
        {
            nombreJuegoRegistrado registro = new nombreJuegoRegistrado(ruta);
            List<DatosJuego> listaDatos = new List<DatosJuego>();

            for (int i = 0; i < 6; i++)
            {
                registro.obtenerDatosJuego(i + 1, UsuarioActivo.nombre.ToString());
                DatosJuego datos = new DatosJuego
                {
                    NombreJuego = registro.obtener_nombreJuego(),
                    JuegoVisible = registro.obtener_Juegovisible(),
                    carritoVisible = registro.obtener_carritoVisible(),
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
            List<Button> buttons = new List<Button>
            {
                btn_agregar_juego1, btn_agregar_juego2, btn_agregar_juego3, btn_agregar_Juego4, btn_agregar_Juego5, btn_agregar_Juego6,
                btn_jugar1, btn_jugar2, btn_jugar3, btn_jugar4, btn_jugar5, btn_jugar6,
                btn_regresar_Juego1, btn_regresar_Juego2, btn_regresar_Juego3, btn_regresar_Juego4, btn_regresar_Juego5, btn_regresar_Juego6,
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
                buttons[i].Visible = !datos[i].carritoVisible;
                buttons[i + 6].Visible = datos[i].carritoVisible;
                buttons[i + 12].Visible = datos[i].carritoVisible;
                pictures[i].ImageLocation = datos[i].RutaImagen;
                labels[i + 6].Text = datos[i].PrecioJuego.ToString("C"); // Formato moneda
            }
        }


        // Métodos que inician los juegos cuando ya se realizaron las compras
        private void btn_Jugar_Loteria_Click(object sender, EventArgs e)
        {
            id = 1;
            nombreJuegoRegistrado registro = new nombreJuegoRegistrado(ruta);
            string usuario = UsuarioActivo.nombre;
            registro.obtenerDatosJuego(id, usuario);

            if (registro.obtener_carritoVisible())
            {
                Process.Start(registro.obtener_rutaEjecucion());
            }
            else
            {
                MessageBox.Show("Este juego no está disponible para tu usuario.");
            }
        }

        private void btn_Juego_preguntas_Click(object sender, EventArgs e)
        {
            id = 3;
            nombreJuegoRegistrado registro = new nombreJuegoRegistrado(ruta);
            string usuario = UsuarioActivo.nombre;
            registro.obtenerDatosJuego(id, usuario);

            if (registro.obtener_carritoVisible())
            {
                Process.Start(registro.obtener_rutaEjecucion());
            }
            else
            {
                MessageBox.Show("Este juego no está disponible para tu usuario.");
            }
        }

        private void btn_jugar_musica_Click(object sender, EventArgs e)
        {
            id = 2;
            nombreJuegoRegistrado registro = new nombreJuegoRegistrado(ruta);
            string usuario = UsuarioActivo.nombre;
            registro.obtenerDatosJuego(id, usuario);

            if (registro.obtener_carritoVisible())
            {
                Process.Start(registro.obtener_rutaEjecucion());
            }
            else
            {
                MessageBox.Show("Este juego no está disponible para tu usuario.");
            }
        }

        private void btn_Jugar_Battlefield_Click(object sender, EventArgs e)
        {
            id = 4;
            nombreJuegoRegistrado registro = new nombreJuegoRegistrado(ruta);
            string usuario = UsuarioActivo.nombre;
            registro.obtenerDatosJuego(id, usuario);

            if (registro.obtener_carritoVisible())
            {
                Process.Start(registro.obtener_rutaEjecucion());
            }
            else
            {
                MessageBox.Show("Este juego no está disponible para tu usuario.");
            }
        }

        private void PPrograma_Load(object sender, EventArgs e)
        {
            carritoVentana = new Carrito();
        }

        // MÉTODOS DE "OBTENER" (AGREGAR AL CARRITO) – NO activan botones de jugar
        private void btn_agregar_juego1_Click(object sender, EventArgs e)
        {
            id = 1;
            string nombreJuego = label1.Text;
            string precioJuego = label7.Text;
            bool agregado = carroCompras.AgregarJuego(nombreJuego, precioJuego, id);
            if (agregado)
            {
                MessageBox.Show($"Juego '{nombreJuego}' fue agregado al carrito");

                if (carritoVentana != null && !carritoVentana.IsDisposed)
                {
                    carritoVentana.ActualizarLista();
                }
            }
            else
            {
                MessageBox.Show("Este juego ya está en el carrito.");
            }
        }

        private void btn_agregar_juego3_Click(object sender, EventArgs e)
        {
            id = 3;
            string nombreJuego = Convert.ToString(label3.Text);
            string precioJuego = Convert.ToString(label9.Text);
            bool agregado = carroCompras.AgregarJuego(nombreJuego, precioJuego, id);
            if (agregado)
            {
                MessageBox.Show($"Juego '{nombreJuego}' fue agregado al carrito");

                if (carritoVentana != null && !carritoVentana.IsDisposed)
                {
                    carritoVentana.ActualizarLista();
                }
            }
            else
            {
                MessageBox.Show("Este juego ya está en el carrito.");
            }
        }

        // El botón de "Música", que ya funcionaba según lo esperado:
        private void btn_agregar_juego2_Click(object sender, EventArgs e)
        {
            id = 2;
            string nombreJuego = Convert.ToString(label2.Text);
            string precioJuego = Convert.ToString(label8.Text);
            bool agregado = carroCompras.AgregarJuego(nombreJuego, precioJuego, id);
            if (agregado)
            {
                MessageBox.Show($"Juego '{nombreJuego}' fue agregado al carrito");

                if (carritoVentana != null && !carritoVentana.IsDisposed)
                {
                    carritoVentana.ActualizarLista();
                }
            }
            else
            {
                MessageBox.Show("Este juego ya está en el carrito.");
            }
        }

        // Método que actualiza la visibilidad de los botones para jugar según los juegos comprados
        //private void ActualizarBotonesDeJugar()
        //{
        //    btn_jugar1.Visible = PPrograma.juegosComprados.Any(j => j.Contains("Lotería"));
        //    btn_jugar3.Visible = PPrograma.juegosComprados.Any(j => j.Contains("Quiz Preguntas"));
        //    btn_jugar2.Visible = PPrograma.juegosComprados.Any(j => j.Contains("Música"));
        //    btn_jugar4.Visible = PPrograma.juegosComprados.Any(j => j.Contains("Battlefield"));
        //}

        //private void PPrograma_Activated(object sender, EventArgs e)
        //{
        //    ActualizarBotonesDeJugar();
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process.Start("D:\\POO\\Unidad 3\\Proyecto_finalPOO\\bin\\Debug\\net8.0-windows\\Juegos\\Debug\\ProyectoFinalQuiz.exe");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            carritoVentana.ActualizarLista();
            carritoVentana.Show();
            carritoVentana.BringToFront();
        }

        // Otros botones de "agregar" se corrigen de forma similar:
        private void btn_agregar_juego4_Click(object sender, EventArgs e)
        {
            id = 4;
            string nombreJuego = Convert.ToString(label4.Text);
            string precioJuego = Convert.ToString(label10.Text);
            bool agregado = carroCompras.AgregarJuego(nombreJuego, precioJuego, id);
            if (agregado)
            {
                MessageBox.Show($"Juego '{nombreJuego}' fue agregado al carrito");

                if (carritoVentana != null && !carritoVentana.IsDisposed)
                {
                    carritoVentana.ActualizarLista();
                }
            }
            else
            {
                MessageBox.Show("Este juego ya está en el carrito.");
            }
        }

        private void btn_agregar_juego5_Click(object sender, EventArgs e)
        {
            id = 5;
            string nombreJuego = Convert.ToString(label5.Text);
            string precioJuego = Convert.ToString(label11.Text);
            bool agregado = carroCompras.AgregarJuego(nombreJuego, precioJuego, id);
            if (agregado)
            {
                MessageBox.Show($"Juego '{nombreJuego}' fue agregado al carrito");

                if (carritoVentana != null && !carritoVentana.IsDisposed)
                {
                    carritoVentana.ActualizarLista();
                }
            }
            else
            {
                MessageBox.Show("Este juego ya está en el carrito.");
            }
        }

        private void btn_agregar_juego6_Click(object sender, EventArgs e)
        {
            id = 6;
            string nombreJuego = Convert.ToString(label6.Text);
            string precioJuego = Convert.ToString(label12.Text);
            bool agregado = carroCompras.AgregarJuego(nombreJuego, precioJuego, id);
            if (agregado)
            {
                MessageBox.Show($"Juego '{nombreJuego}' fue agregado al carrito");

                if (carritoVentana != null && !carritoVentana.IsDisposed)
                {
                    carritoVentana.ActualizarLista();
                }
            }
            else
            {
                MessageBox.Show("Este juego ya está en el carrito.");
            }
        }
        public decimal ObtenerSaldoUsuario()
        {
            decimal saldo = 0;
            string usuario = UsuarioActivo.nombre.ToString();

            using (NpgsqlConnection conexion = new NpgsqlConnection(ruta))
            {
                conexion.Open();
                string consulta = "SELECT credito FROM usuarios WHERE usuario = @usuario";

                using (NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            saldo = reader.GetDecimal(0);
                        }
                    }
                }
            }
            return saldo;
        }

        private void btn_regresar_Juego1_Click(object sender, EventArgs e)
        {
            id = 1;
            decimal saldoUsuario = ObtenerSaldoUsuario();
            string nombreJuego = label1.Text;
            string pecioRegistrado = label7.Text;
            string[] partes = pecioRegistrado.Split('$');
            decimal precioJuego = Convert.ToDecimal(partes[1].Trim());
            MessageBox.Show($"Juego reembolsado.");
            carroCompras.NotificarCompraActualizada();
            carritoVentana.Refresh();
            carroCompras.RegresarJuego(precioJuego, ruta, saldoUsuario, id);
        }

        private void btn_regresar_Juego2_Click(object sender, EventArgs e)
        {
            id = 2;
            decimal saldoUsuario = ObtenerSaldoUsuario();
            string nombreJuego = Convert.ToString(label2.Text);
            string pecioRegistrado = label8.Text;
            string[] partes = pecioRegistrado.Split('$');
            decimal precioJuego = Convert.ToDecimal(partes[1].Trim());
            MessageBox.Show($"Juego reembolsado.");
            carroCompras.NotificarCompraActualizada();
            carritoVentana.Refresh();

            carroCompras.RegresarJuego(precioJuego, ruta, saldoUsuario, id);
        }

        private void btn_regresar_Juego3_Click(object sender, EventArgs e)
        {
            id = 3;

            decimal saldoUsuario = ObtenerSaldoUsuario();
            string nombreJuego = Convert.ToString(label3.Text);
            string pecioRegistrado = label9.Text;
            string[] partes = pecioRegistrado.Split('$');
            decimal precioJuego = Convert.ToDecimal(partes[1].Trim());
            MessageBox.Show($"Juego reembolsado.");
            carroCompras.NotificarCompraActualizada();
            carritoVentana.Refresh();

            carroCompras.RegresarJuego(precioJuego, ruta, saldoUsuario, id);
        }

        private void btn_regresar_Juego4_Click(object sender, EventArgs e)
        {
            id = 4;

            decimal saldoUsuario = ObtenerSaldoUsuario();
            string nombreJuego = Convert.ToString(label4.Text);
            string pecioRegistrado = label10.Text;
            string[] partes = pecioRegistrado.Split('$');
            decimal precioJuego = Convert.ToDecimal(partes[1].Trim());
            MessageBox.Show($"Juego reembolsado.");
            carroCompras.NotificarCompraActualizada();
            carritoVentana.Refresh();

            carroCompras.RegresarJuego(precioJuego, ruta, saldoUsuario, id);
        }

        private void btn_regresar_Juego5_Click(object sender, EventArgs e)
        {
            id = 5;

            decimal saldoUsuario = ObtenerSaldoUsuario();
            string nombreJuego = Convert.ToString(label5.Text);
            string pecioRegistrado = label11.Text;
            string[] partes = pecioRegistrado.Split('$');
            decimal precioJuego = Convert.ToDecimal(partes[1].Trim());
            MessageBox.Show($"Juego reembolsado.");
            carroCompras.NotificarCompraActualizada();
            carritoVentana.Refresh();

            carroCompras.RegresarJuego(precioJuego, ruta, saldoUsuario, id);
        }

        private void btn_regresar_Juego6_Click(object sender, EventArgs e)
        {
            id = 6;

            decimal saldoUsuario = ObtenerSaldoUsuario();
            string nombreJuego = Convert.ToString(label6.Text);
            string pecioRegistrado = label12.Text;
            string[] partes = pecioRegistrado.Split('$');
            decimal precioJuego = Convert.ToDecimal(partes[1].Trim());
            MessageBox.Show($"Juego reembolsado.");
            carroCompras.NotificarCompraActualizada();
            carritoVentana.Refresh();

            carroCompras.RegresarJuego(precioJuego, ruta, saldoUsuario, id);
        }

        private void btn_jugar5_Click(object sender, EventArgs e)
        {
            id = 5;
            nombreJuegoRegistrado registro = new nombreJuegoRegistrado(ruta);
            string usuario = UsuarioActivo.nombre;
            registro.obtenerDatosJuego(id, usuario);

            if (registro.obtener_carritoVisible())
            {
                Process.Start(registro.obtener_rutaEjecucion());
            }
            else
            {
                MessageBox.Show("Este juego no está disponible para tu usuario.");
            }
        }

        private void btn_jugar6_Click(object sender, EventArgs e)
        {
            id = 6;
            nombreJuegoRegistrado registro = new nombreJuegoRegistrado(ruta);
            string usuario = UsuarioActivo.nombre;
            registro.obtenerDatosJuego(id, usuario);

            if (registro.obtener_carritoVisible())
            {
                Process.Start(registro.obtener_rutaEjecucion());
            }
            else
            {
                MessageBox.Show("Este juego no está disponible para tu usuario.");
            }
        }

        private void reseñasloteria_Click(object sender, EventArgs e)
        {
            int idJuego = 1;
            string usuarioActual = UsuarioActivo.nombre;

            Reseñas formularioReseñas = new Reseñas(idJuego, usuarioActual, ruta);
            formularioReseñas.ShowDialog();


        }

        private void reseñasmusica_Click(object sender, EventArgs e)
        {
            int idJuego = 2;
            string usuarioActual = UsuarioActivo.nombre;

            Reseñas formularioReseñas = new Reseñas(idJuego, usuarioActual, ruta);
            formularioReseñas.ShowDialog();

        }

        private void reseñasquiz_Click(object sender, EventArgs e)
        {
            int idJuego = 3;
            string usuarioActual = UsuarioActivo.nombre;

            Reseñas formularioReseñas = new Reseñas(idJuego, usuarioActual, ruta);
            formularioReseñas.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void reseñasbattlefield_Click(object sender, EventArgs e)
        {
            int idJuego = 4;
            string usuarioActual = UsuarioActivo.nombre;

            Reseñas formularioReseñas = new Reseñas(idJuego, usuarioActual, ruta);
            formularioReseñas.ShowDialog();

        }

        private void reseñasgta_Click(object sender, EventArgs e)
        {
            int idJuego = 5;
            string usuarioActual = UsuarioActivo.nombre;

            Reseñas formularioReseñas = new Reseñas(idJuego, usuarioActual, ruta);
            formularioReseñas.ShowDialog();

        }

        private void reseñasMineraft_Click(object sender, EventArgs e)
        {
            int idJuego = 6;
            string usuarioActual = UsuarioActivo.nombre;

            Reseñas formularioReseñas = new Reseñas(idJuego, usuarioActual, ruta);
            formularioReseñas.ShowDialog();

        }
    }
}
