using Proyecto.Models;
using System.Data.SqlClient;

namespace Proyecto.ContextBD
{
    public class InfoDB
    {
        string connectionString = ContextDB.connectionString;
        public List<Info> ListarInformacion()//Opcion Listar Datos////
        {
            List<Info> lstInfo = new List<Info>();
            using (SqlConnection context = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM informacion"; //lector de la base de datos
                SqlCommand comand = new SqlCommand(query, context);
                context.Open();
                SqlDataReader reader = comand.ExecuteReader(); //Pasar Data a una vista
                while (reader.Read())
                {
                    lstInfo.Add(new Info()
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),//convirtiendo a un entero--> campos de la tabla
                        Telefono = reader["telefono"].ToString(),
                        Direccion = reader["direccion"].ToString(),
                        Oficio = reader["oficio"].ToString()
                    });
                }
                reader.Close();
                context.Close();
            }
            return lstInfo;
        }

        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX OPCION GUARDAR XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        public void GuardarInfo(Info model)
        {
            using (SqlConnection contextDB = new SqlConnection(connectionString))
            {
                try
                {

                    string query = "INSERT INTO informacion(telefono, direccion, oficio)" +   //realizamos un query con los valores de la tabla
                                "VALUES(@telefono, @direccion, @oficio)";
                    string comand;
                    SqlCommand command = new SqlCommand(query, contextDB);
                    command.Parameters.AddWithValue("@telefono", model.Telefono);
                    command.Parameters.AddWithValue("@direccion", model.Direccion);
                    command.Parameters.AddWithValue("@oficio", model.Oficio);
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
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx OPCION DETALLE XXXXXXXXXXXXXXXXXXXXXXXXXXX
        public Info ObtenerInfo(int id)
        {
            Info informacion = new Info();
            using (SqlConnection contextDB = new SqlConnection(connectionString))
            {
                //@Id va a ser igual al valor que trae el parametro id
                string query = "Select * From informacion Where id = @Id";
                SqlCommand command = new SqlCommand(query, contextDB);
                command.Parameters.AddWithValue("@Id", id);
                contextDB.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    informacion.Id = Convert.ToInt32(reader["id"]);
                    informacion.Telefono = reader["telefono"].ToString();
                    informacion.Direccion = reader["direccion"].ToString();
                    informacion.Oficio= reader["oficio"].ToString();
                }
                reader.Close();
                contextDB.Close();
            }
            return informacion;
        }

        //xxxxxxxxxxxxxxxxxxxxxxxxxxxx ACTUALIZAR --> Eliminar
        public void ActualizarInfo(Info model)
        {
            using (SqlConnection contextDB = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE informacion SET telefono = @telefono, direccion = @direccion, oficio = @oficio " +   
                        " WHERE id = @Id";
                    SqlCommand command = new SqlCommand(query, contextDB);
                    command.Parameters.AddWithValue("@telefono", model.Telefono);
                    command.Parameters.AddWithValue("@direccion", model.Direccion);
                    command.Parameters.AddWithValue("@oficio", model.Oficio);
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

        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX ACCION ELIMINAR XXXXXXXXXXXXXX
        public void EliminarInfo(int id)
        {
            using (SqlConnection contextDB = new SqlConnection(connectionString))
            {
                string query = "Delete from informacion Where id = @Id";
                SqlCommand command = new SqlCommand(query, contextDB);
                command.Parameters.AddWithValue("@Id", id);

                contextDB.Open();
                command.ExecuteNonQuery();
                contextDB.Close();
            }
        }
    }
}

