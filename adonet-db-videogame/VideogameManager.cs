using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace adonet_db_videogame
{
    public enum Options
    { Add, Find, Filter, Delete, Quit }


    internal class VideogameManager
    {
        public static void Add(SqlConnection connection)
        {       
            try
            {
                Videogame newVideogame = Videogame.DataValidator();

                string sqlQuery = "INSERT INTO videogames(name, overview, release_date, created_at, updated_at, software_house_id) " +
                 "VALUES(@name, @overview, @release_date, @created_at, @updated_at, @software_house_id)";

                using (SqlCommand comando = new SqlCommand(sqlQuery, connection))
                {
                    comando.Parameters.AddWithValue("@name", newVideogame.Name);
                    comando.Parameters.AddWithValue("@overview", newVideogame.Overview);
                    comando.Parameters.AddWithValue("@release_date", newVideogame.ReleaseDate);
                    comando.Parameters.AddWithValue("@created_at", newVideogame.CreatedAt);
                    comando.Parameters.AddWithValue("@updated_at", newVideogame.UpdatedAt);
                    comando.Parameters.AddWithValue("@software_house_id", newVideogame.SoftwareHouseId);
                    comando.ExecuteNonQuery();
                    Console.WriteLine("-- SUCCESS!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"-- FAL: {ex.ToString()}");
            }
        }

        public static void Find(SqlConnection connection)
        {
            string user_VId=null;
           bool isValidId=false;
            while (!isValidId)
            {
                Console.WriteLine("inserisci l'id del videogame che vuoi trovare");
               user_VId = Console.ReadLine();
                isValidId = user_VId.Validatestring(false, true, false, null, null);
            }
            int id = Convert.ToInt32(user_VId);
            try
            {
                string sqlQuery = "SELECT * FROM videogames WHERE id = @id";
                using (SqlCommand comando = new SqlCommand(sqlQuery, connection))
                {
                    comando.Parameters.AddWithValue("@id",id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                            Console.WriteLine($"VIDEOGAME n#: {reader["id"]} \ttitolo: {reader["name"]} \tdescrizione: {reader["overview"]} \tdata di rilascio: {reader["release_date"]}");
                        else
                        {
                            Console.WriteLine("Spiacente, nessun risultato trovato.");
                            //Console.WriteLine("premi(Y) per ritentare la ricerca");  
                            //if (Console.ReadLine() == "Y")
                            //{
                            //    reader.Close();//devo chiedere dove e come fare sta cosa
                            //    Find(connection);
                            //}
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void Filter(SqlConnection connection)   
            {

            Console.WriteLine("inserisci parte del titolo del videogioco che ti interessa ricercare:");
                string user_filterString =Console.ReadLine();
                try
                {
                    string sqlQuery = "SELECT * FROM videogames WHERE name LIKE '%' + @name + '%'";
                    using (SqlCommand comando = new SqlCommand(sqlQuery, connection))
                {
                        comando.Parameters.AddWithValue("@name", user_filterString);


                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                                Console.WriteLine($"VIDEOGAME n#: {reader["id"]} \ttitolo: {reader["name"]} \tdescrizione: {reader["overview"]} \tdata di rilascio: {reader["release_date"]}");
                            else
                            {
                                Console.WriteLine("Spiacente, nessun risultato trovato.");
                                //Console.WriteLine("premi(Y) per ritentare la ricerca");  
                                //if (Console.ReadLine() == "Y")
                                //{
                                //    reader.Close();//devo chiedere dove e come fare sta cosa
                                //    Filter(connection);
                                //}
                            }
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        
        public static void Delete(SqlConnection connection)
          {
            string user_VIdToDelete = null;
            bool isValidId = false;
            while (!isValidId)
            {
                Console.WriteLine("inserisci l'id del videogame che vuoi eliminare");
                user_VIdToDelete = Console.ReadLine();
                isValidId = user_VIdToDelete.Validatestring(false, true, false, null, null);
            }
            int id = Convert.ToInt32(user_VIdToDelete);
            try
            {
                string sqlQuery = "SELECT * FROM videogames WHERE id = @id";
                using (SqlCommand comando = new SqlCommand(sqlQuery, connection))
                {
                    comando.Parameters.AddWithValue("@id",id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                            Console.WriteLine($"VIDEOGAME ELIMINATO n#: {reader["id"]} \ttitolo: {reader["name"]} \tdescrizione: {reader["overview"]} \tdata di rilascio: {reader["release_date"]}");
                        else
                        {
                            Console.WriteLine("Spiacente, nessun risultato trovato.");
                            //Console.WriteLine("premi(Y) per ritentare la ricerca");  
                            //if (Console.ReadLine() == "Y")
                            //{
                            //    reader.Close();//devo chiedere dove e come fare sta cosa
                            //    Delete(connection);
                            //}
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void Quit(SqlConnection connection)
        {
            try { connection.Close(); Console.WriteLine("SESSIONE TERMINATA"); } catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
