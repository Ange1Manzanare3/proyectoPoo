using MySql.Data.MySqlClient;
using Npgsql;


namespace usuario_iniciar
{
    internal class IniciarUsuario : Inicio
    {
        public IniciarUsuario(string nuevo_usuario, string nueva_contraseña, string nuevo_correo, string nueva_ruta)
        {
            this.usuario = nuevo_usuario;
            this.contraseña = nueva_contraseña;
            this.correo = nuevo_correo;
            this.cadenaConexion = nueva_ruta;
        }
        public string Comprobar_Inicio()
        {
            using (var conexion = new NpgsqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = "SELECT correo, contrasena FROM usuarios WHERE usuario = @usuario";

                using (var cmd = new NpgsqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string correoExistente = reader["correo"].ToString();
                            string contraseñaExistente = reader["contrasena"].ToString();

                            if (correo == correoExistente && contraseña == contraseñaExistente)
                                return "Inicio de sesión exitoso";
                            else if (correo == correoExistente)
                                return "Contraseña incorrecta";
                            else
                                return "Correo incorrecto";
                        }
                    }
                }
            }

            return "El usuario no existe";
        }
        public string Comprobar_Inicio(int codigo)
        {
            using (var conexion = new NpgsqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = "SELECT correo, contrasena, codigo FROM usuarios WHERE usuario = @usuario";

                using (var cmd = new NpgsqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string correoExistente = reader["correo"].ToString();
                            string contraseñaExistente = reader["contrasena"].ToString();
                            int codigo_existente = Convert.ToInt32(reader["codigo"]);


                            if (correo == correoExistente && contraseña == contraseñaExistente)
                                if (codigo == codigo_existente)
                                    return "Inicio de sesión exitoso";
                            else if (correo == correoExistente)
                                return "Contraseña incorrecta";
                            else
                                return "Correo incorrecto";
                        }
                    }
                }
            }

            return "El usuario no existe";
        }
    }
}


/*
 * Ejecutar consultas con él:

cmd.ExecuteReader() para consultas que devuelven resultados (como SELECT)

cmd.ExecuteNonQuery() para comandos que no devuelven resultados (como INSERT, UPDATE, DELETE)

cmd.ExecuteScalar() para obtener un único valor


 */