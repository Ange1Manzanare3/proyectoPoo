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
    public partial class Carrito : Form
    {
        public Carrito()
        {
            InitializeComponent();
            this.Load += Carrito_Load;
        }

        private void Carrito_Load(object sender, EventArgs e)
        {
            ActualizarLista();
        }


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

            MessageBox.Show($"Gracias por tu compra. Total: ${total}");
            PPrograma.carrito.Clear();
            ActualizarLista();
        }
    }
}