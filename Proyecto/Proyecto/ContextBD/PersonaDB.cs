
//Todo relacionado a Base de Datos

using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.Win32;
using Proyecto.Models;
using System.Data.SqlClient;

namespace Proyecto.ContextBD
{
    public class PersonaDB
    {       //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX CREACION DE UN METODO XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        string connectionString = ContextDB.connectionString;
        public List<Persona> ListarTodosRegistros()//Opcion Listar Datos////
        {
            List<Persona> lstPersonas = new List<Persona>();
            using (SqlConnection ContextDB = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM persona"; //lector de la base de datos
                SqlCommand comand = new SqlCommand(query, ContextDB);
                ContextDB.Open();
                SqlDataReader reader = comand.ExecuteReader(); //Pasar Data a una vista
                while (reader.Read())
                {
                    lstPersonas.Add(new Persona
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),//convirtiendo a un entero--> campos de la tabla
                        Nombre = reader["nombre"].ToString(),
                        Apellido = reader["apellido"].ToString()
                    });
                }
                reader.Close();
                ContextDB.Close();
            }
            return lstPersonas;
        }
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX OPCION GUARDAR XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        public void Guardar(Persona model)
        {
            using (SqlConnection contextDB = new SqlConnection(connectionString))
            {
                try
                {

                    string query = "INSERT INTO persona(nombre, apellido)" +   //realizamos un query con los valores de la tabla
                                "VALUES(@nombre, @apellido)";
                    SqlCommand command = new SqlCommand(query, contextDB);
                    command.Parameters.AddWithValue("@nombre", model.Nombre);
                    command.Parameters.AddWithValue("@apellido", model.Apellido);

                    contextDB.Open();
                    //ExecuteNonQuery: Solo va a ejecutar no va a retornar ningun valor
                    command.ExecuteNonQuery();
                    contextDB.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX ACCION DE DETALLE XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        //Metodo para obtener un registro por id
        public Persona ObtenerPersona(int id)
        {
            Persona persona = new Persona();
            using (SqlConnection contextDB = new SqlConnection(connectionString))
            {
                //@Id va a ser igual al valor que trae el parametro id
                string query = "Select * From persona Where id = @Id";
                SqlCommand command = new SqlCommand(query, contextDB);
                command.Parameters.AddWithValue("@Id", id);
                contextDB.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    persona.Id = Convert.ToInt32(reader["id"]);
                    persona.Nombre = reader["nombre"].ToString();
                    persona.Apellido = reader["apellido"].ToString();
                }
                reader.Close();
                contextDB.Close();
            }
            return persona;
        }

        //xxxxxxxxxxxxxxxxxxxxxxxxxxxx ACTUALIZAR --> Eliminar
        public void Actualizar(Persona model) 
        {
            using (SqlConnection contextDB = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE persona SET nombre = @nombre, apellido = @apellido " +   //realizamos un query con los valores de la tabla
                        " WHERE id = @Id";
                    SqlCommand command = new SqlCommand(query, contextDB);
                    command.Parameters.AddWithValue("@nombre", model.Nombre);
                    command.Parameters.AddWithValue("@apellido", model.Apellido);
                    command.Parameters.AddWithValue("@Id", model.Id);

                    contextDB.Open();
                    command.ExecuteNonQuery();
                    contextDB.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX ACCION ELIMINAR XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        public void Eliminar(int id)
        {
            using (SqlConnection contextDB = new SqlConnection(connectionString))
            {
                string query = "Delete from persona Where id = @Id";
                SqlCommand command = new SqlCommand(query, contextDB);
                command.Parameters.AddWithValue("@Id", id);

                contextDB.Open();
                command.ExecuteNonQuery();
                contextDB.Close();
            }
        }

    }
}