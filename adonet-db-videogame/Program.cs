using System.Data.SqlClient;
namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Data Source=localhost;Initial Catalog=db_videogames;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("sei connesso");
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }

                int choiche = Utilities.GetUserChoice();

                switch (choiche)
                {
                    case (int)Options.Add:
                        VideogameManager.Add(conn);
                     
                        break;
                    case (int)Options.Find:
                        VideogameManager.Find(conn);
                        break;
                    case (int)Options.Filter:
                        VideogameManager.Filter(conn);
                        break;
                    case (int)Options.Delete:
                        VideogameManager.Delete(conn);
                        break;
                    case (int)Options.Quit:
                        VideogameManager.Quit(conn);
                        break;
                    default:
                        break;
                }





            }
        }
    }
}