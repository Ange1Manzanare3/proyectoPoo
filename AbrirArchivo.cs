using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_finalPOO
{
    internal class AbrirArchivo
    {
        protected string rutaImagen = string.Empty, extension = string.Empty;
        public void OpenArchivo()
        {
            using (OpenFileDialog opfd = new OpenFileDialog())
            {
                string carpetaPermitida = @"D:\POO\Unidad 3\Proyecto_finalPOO\bin\Debug\net8.0-windows\Juegos\Portadas";

                opfd.InitialDirectory = carpetaPermitida;
                opfd.Filter = "Archivos de imagen (*.jpg; *.png)|*.jpg;*.png";
                opfd.Title = "Cambiar Portada";
                opfd.RestoreDirectory = true;

                if (opfd.ShowDialog() != DialogResult.OK)
                    return;

                rutaImagen = opfd.FileName;

                // Validar que el archivo esté en la carpeta permitida
                if (!rutaImagen.StartsWith(carpetaPermitida, StringComparison.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show("Solo puedes seleccionar archivos dentro de la carpeta permitida.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
        public void OpenArchivo(string extension)
        {
            using (OpenFileDialog opfd = new OpenFileDialog())
            {
                string carpetaPermitida = @"D:\POO\Unidad 3\Proyecto_finalPOO\bin\Debug\net8.0-windows\Juegos\";

                opfd.InitialDirectory = carpetaPermitida;
                opfd.Filter = extension;
                opfd.Title = "Cambiar Portada";
                opfd.RestoreDirectory = true;

                if (opfd.ShowDialog() != DialogResult.OK)
                    return;

                rutaImagen = opfd.FileName;

                // Validar que el archivo esté en la carpeta permitida
                if (!rutaImagen.StartsWith(carpetaPermitida, StringComparison.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show("Solo puedes seleccionar archivos dentro de la carpeta permitida.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
        public virtual string get_ruta() { return rutaImagen; }

    }
}
