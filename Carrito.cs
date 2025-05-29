using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_finalPOO
{
    //papuprueba
    public partial class Carrito : Form
    {
        private string ruta = "Host=caboose.proxy.rlwy.net;Port=49656;Username=postgres;Password=xwWxhVadXdbkkiCQHtQlxtNxTQyhPVGp;Database=railway;SSL Mode=Require;Trust Server Certificate=true";
        public Carrito()
        {
            InitializeComponent();
            this.Load += Carrito_Load;
        }

        private void Carrito_Load(object sender, EventArgs e)
        {
            ActualizarLista();
            lblCreditos.Text = $"Saldo: ${ObtenerSaldoUsuario()}";
        }
        //papucambiesito

        private void ActualizarLista()
        {
            listJuegos.Items.Clear();

            foreach (string juego in PPrograma.carrito)
            {
                listJuegos.Items.Add(juego);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            int indice = listJuegos.SelectedIndex;

            if (indice >= 0)
            {
                PPrograma.carrito.RemoveAt(indice);
                ActualizarLista();
            }
            else
            {
                MessageBox.Show("Selecciona un juego para quitar.");
            }
        }

        private void btnVaciar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Neta lo quieres vaciar we?", "Confirmar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                PPrograma.carrito.Clear();
                ActualizarLista();
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (PPrograma.carrito.Count == 0)
            {
                MessageBox.Show("Tu carrito está vacío.");
                return;
            }

            int total = 0;

            foreach (string item in PPrograma.carrito)
            {
                string[] partes = item.Split('$');
                if (partes.Length == 2 && int.TryParse(partes[1], out int precio))
                {
                    total += precio;
                }
            }
            int saldoDisponible = ObtenerSaldoUsuario();

            if (saldoDisponible >= total)
            {
                // Descontar saldo en la base de datos
                string usuario = UsuarioActivo.nombre.ToString();

                using (NpgsqlConnection conexion = new NpgsqlConnection(ruta))
                {
                    conexion.Open();
                    string consulta = "UPDATE usuarios SET credito = credito - @total WHERE usuario = @usuario";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Gracias por tu compra. Total: ${total}");
                PPrograma.carrito.Clear();
                ActualizarLista();
                lblCreditos.Text = $"Saldo: ${ObtenerSaldoUsuario()}"; // Actualizar saldo en la UI
            }
            else
            {
                MessageBox.Show("Saldo insuficiente. Agrega más balance.");
            }
        }

        private int ObtenerSaldoUsuario()
        {
            int saldo = 0;
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
                            saldo = reader.GetInt32(0);
                        }
                    }
                }
            }
            return saldo;
        }

        private void btnBalanza_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBalanza.Text.Trim(), out int monto) && monto > 0)
            {
                string usuario = UsuarioActivo.nombre.ToString();

                using (NpgsqlConnection conexion = new NpgsqlConnection(ruta))
                {
                    conexion.Open();
                    string consulta = "UPDATE usuarios SET credito = credito + @monto WHERE usuario = @usuario";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Saldo agregado: ${monto}");
                lblCreditos.Text = $"Saldo: ${ObtenerSaldoUsuario()}"; // Actualizar saldo
                txtBalanza.Clear();
            }
            else
            {
                MessageBox.Show("Ingresa un monto válido.");
            }
        }
    }
}