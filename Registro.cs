using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace usuario_iniciar
{
    internal class Registro
    {
        protected string usuario, contraseña, correo, cadenaConexion;
        protected int codigo;
        public Registro()
        {
            usuario = string.Empty;
            contraseña = string.Empty;
            correo = string.Empty;
            cadenaConexion = string.Empty;
        }
        
        public string obtener_usuario() { return usuario; }  
        public string obtener_contraseña() { return contraseña; }  
        public string obtener_correo() { return correo; }  
        public int obtener_codigo() { return codigo; }  
    }
}
