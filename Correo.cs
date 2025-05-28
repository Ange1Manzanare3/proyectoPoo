using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_finalPOO
{
    class Correo
    {
        public bool ValidarCorreo(string correo)
        {
            return correo.EndsWith("@gmail.com") || correo.EndsWith("@hotmail.com") || correo.EndsWith("@outlook.com") || correo.EndsWith("@yahoo.com");
        }
    }
}
