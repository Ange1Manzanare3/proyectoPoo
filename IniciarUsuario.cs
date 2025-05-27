using MySql.Data.MySqlClient;


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
            //Conexion a la base de datos (usamos using para que esa conexión se abra, se use y se cierre correctamente automáticamente.)
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                // Aquí ejecutas tus consultas
                conexion.Open();

                /*SELECT que le pide a MySQL que busque un usuario específico y devuelva su correo y contraseña. 
                 * SELECT correo, contraseña: Le estás diciendo a MySQL que solo quieres obtener los valores de las columnas correo y contraseña.
                   FROM usuarios: Le estás diciendo de qué tabla vas a obtener esos datos. En este caso, de la tabla usuarios.
                 * (WHERE usuario = @usuario)Le estás diciendo que solo busque la fila donde el valor de la columna usuario coincida con el parámetro @usuario.
                */
                string consulta = "SELECT correo, contrasena FROM usuarios WHERE usuario = @usuario";

                /*
                 * MySql.Data. Sirve para ejecutar comandos SQL en una base de datos MySQL.
                 * new MySqlCommand(consulta, conexion) Estás creando un nuevo comando
                 */
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    /*
                     * cmd: es el objeto que contiene la consulta SQL (MySqlCommand).
                     * .Parameters: es una colección donde se guardan los parámetros que usas en la consulta SQL.
                     * "@usuario": es el nombre del parámetro en la consulta SQL.
                     * Usar .AddWithValue() le dice a cmd: Reemplaza @usuario por el valor real que tengo en la variable usuario.
                     */
                    cmd.Parameters.AddWithValue("@usuario", usuario);

                    /*
                     * MySqlDataReader: Es un objeto que sirve para leer datos que vienen de una base de datos fila por fila, de forma eficiente.
                     * (reader) para leer fila por fila lo que devuelve la base de datos.
                     * usar using asegura que reader se cierre automáticamente después de usarse, liberando recursos correctamente.
                     */
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        //significa: "¿hay al menos una fila de resultado en la consulta?"
                        if (reader.Read())
                        {
                            //significa que estás leyendo el valor de la columna correo de la fila actual del resultado y lo estás guardando en una variable llamada correo_existente.
                            string correo_existente = reader.GetString("correo");
                            string contraseña_existente = reader.GetString("contrasena");

                            if (correo_existente == correo && contraseña_existente == contraseña)
                                return "Inicio de sesion exitoso";
                            if (correo_existente == correo)
                                return "La contraseña es incorrecta";
                            if (contraseña_existente == contraseña)
                                return "El correo es incorrecto";
                            return "Correo y contraseña incorrectos";
                        }
                    }
                }
            }
            return "El usuario no existe";
        }
        public string Comprobar_Inicio(int codigo)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = "SELECT correo, contrasena, codigo FROM usuarios WHERE usuario = @usuario";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string correo_existente = reader.GetString("correo");
                            string contraseña_existente = reader.GetString("contrasena");
                            int codigo_existente = reader.GetInt32("codigo");

                            if (codigo_existente != codigo)
                                return "Codigo invalido";
                            if (correo_existente == correo && contraseña_existente == contraseña)
                                return "Inicio de sesion exitoso";
                            if (correo_existente == correo)
                                return "La contraseña es incorrecta";
                            if (contraseña_existente == contraseña)
                                return "El correo es incorrecto";
                            return "Correo y contraseña incorrectos";
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