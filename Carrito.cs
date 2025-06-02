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
        decimal total;
        private string ruta = "Host=caboose.proxy.rlwy.net;Port=49656;Username=postgres;Password=xwWxhVadXdbkkiCQHtQlxtNxTQyhPVGp;Database=railway;SSL Mode=Require;Trust Server Certificate=true";
        public Carrito()
        {
            InitializeComponent();
            this.Load += Carrito_Load;
            //carroCompras.CarritoActualizado += Carrito_Actualizado;
            carroCompras.compraActualizada += Carrito_Actualizado;

        }
        private void Carrito_Actualizado()
        {
            decimal saldoActualizado = ObtenerSaldoUsuario();
            lblCreditos.Text = $"Crédito: ${saldoActualizado:F2}";
            ActualizarLista();
            CalcularTotal();
        }
        private void CalcularTotal()
        {
            total = 0;

            foreach (var item in carroCompras.ObtenerCarrito())
            {
                string[] partes = item.Split('$');

                if (partes.Length == 2)
                {
                    string precioTexto = partes[1].Trim();

                    if (decimal.TryParse(precioTexto, out decimal precio))
                    {
                        total += precio;
                    }
                }
            }
            lblTotal.Text = $"Total: ${total:F2}";
        }
        private void Carrito_Load(object sender, EventArgs e)
        {
            ActualizarLista();
            lblCreditos.Text = $"Saldo: ${ObtenerSaldoUsuario()}";
            carroCompras.NotificarCompraActualizada();
        }
        //papucambiesito

        public void ActualizarLista()
        {
            listJuegos.Items.Clear();
            foreach (var item in carroCompras.ObtenerCarrito())
            {
                listJuegos.Items.Add(item);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (listJuegos.SelectedItem != null)
            {
                string juego = listJuegos.SelectedItem.ToString();
                carroCompras.EliminarJuego(juego);
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
                carroCompras.VaciarJuegos();
                ActualizarLista();
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (carroCompras.ObtenerCarrito().Count == 0)
            {
                MessageBox.Show("Tu carrito está vacío.");
                return;
            }

            decimal saldoDisponible = ObtenerSaldoUsuario();

            if (saldoDisponible >= total)
            {
                carroCompras.ComprarJuego(total, ruta, saldoDisponible-total);
                MessageBox.Show($"Gracias por tu compra. Total: ${total}");
                ActualizarLista();
                lblCreditos.Text = $"Saldo: ${ObtenerSaldoUsuario()}";
            }
            else
            {
                MessageBox.Show("Saldo insuficiente. Agrega más balance.");
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

        private void btnBalanza_Click(object sender, EventArgs e)
        {
            carroCompras.NotificarCompraActualizada();
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
                lblCreditos.Text = $"Saldo: ${ObtenerSaldoUsuario()}";
                txtBalanza.Clear();
            }
            else
            {
                MessageBox.Show("Ingresa un monto válido.");
            }
        }

        private void listJuegos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Carrito_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();    
        }
    }
}