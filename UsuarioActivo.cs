using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Proyecto_finalPOO
{
    internal class UsuarioActivo
    {
        public static string nombre { get; set; }=string.Empty;
        public UsuarioActivo()
        {

        }
        public UsuarioActivo(string nuevo_nombre)
        {
            nombre = nuevo_nombre;
        }
    }
}
