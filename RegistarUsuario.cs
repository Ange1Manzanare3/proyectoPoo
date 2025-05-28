using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Npgsql;


namespace usuario_iniciar
{
    internal class RegistarUsuario : Registro
    {
        public RegistarUsuario(string nuevo_usuario, string nueva_contraseña, string nuevo_correo, string nueva_ruta)
        {
            this.usuario = nuevo_usuario;
            this.contraseña = nueva_contraseña;
            this.correo = nuevo_correo;
            this.cadenaConexion = nueva_ruta;
        }
        public RegistarUsuario(string nuevo_usuario, string nueva_contraseña, string nuevo_correo, string nueva_ruta, int nuevo_codigo)
        {
            this.usuario = nuevo_usuario;
            this.contraseña = nueva_contraseña;
            this.correo = nuevo_correo;
            this.cadenaConexion = nueva_ruta;
            this.codigo = nuevo_codigo;
        }
        private string ejecutarConsulta()
        {
            using (NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion))
            {
                conexion.Open();
                string consulta = "SELECT usuario, correo FROM usuarios WHERE usuario = @usuario OR correo = @correo";

                using (NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@correo", correo);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        //significa que vas a recorrer todas las filas devueltas por una consulta SQL, una por una.
                        while (reader.Read())
                        {
                            string usuario_existente = reader["usuario"].ToString();
                            string correo_existente = reader["correo"].ToString();

                            if (usuario_existente == usuario && correo_existente == correo)
                                return "Usuario y Correo ya existentes";
                            else if (usuario_existente == usuario)
                                return "Usuario ya existente";
                            else if (correo_existente == correo)
                                return "Correo ya existente";
                        }
                    }
                }
            }
            return "El registro fue exitoso";
        }
        public string Comprobar_registro()
        {
            return ejecutarConsulta();
        }
        public string Comprobar_registro(int codigo)
        {
            if (codigo == 777)
                return ejecutarConsulta();
            return "Codigo incorrecto";
        }
        public void agregar_registro()
        {
            using (NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = "INSERT INTO usuarios (usuario, correo, contrasena, credito) VALUES (@usuario, @correo, @contrasena, @credito)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@contrasena", contraseña);
                    cmd.Parameters.AddWithValue("@credito", 0);
                    cmd.ExecuteNonQuery();
                }
                string consultaJuegos = "INSERT INTO juegos (usuario) VALUES (@usuario)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(consultaJuegos, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void agregar_registro(int codigo)
        {
            using (NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion))
            {
                conexion.Open();

              
                string consulta = "INSERT INTO usuarios (usuario, correo, contrasena, codigo) VALUES (@usuario, @correo, @contrasena, @codigo)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@contrasena", contraseña);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
