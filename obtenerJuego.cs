using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_finalPOO
{
    internal class obtenerJuego
    {
        protected string nombre_juego, usuario, cadenaConexion;
        public obtenerJuego()
        {
            nombre_juego = string.Empty;
            usuario = string.Empty;
            cadenaConexion = string.Empty;
        }
        public obtenerJuego(string nuevo_nombre_juego, string nuevo_usuario, string nueva_cadenaConexion)
        {
            this.nombre_juego = nuevo_nombre_juego;
            this.usuario = nuevo_usuario;
            this.cadenaConexion = nueva_cadenaConexion;
        }
        public void registrarJuego()
        {

        }
    }
}
