using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace adonet_db_videogame
{
  


    public class Videogame
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public int SoftwareHouseId { get; set; }


        internal Videogame(string _name, string _overview, DateTime _releaseDate, int _SoftwareHouseId)
        {
            this.Name = _name;
            this.Overview = _overview;
            this.ReleaseDate = _releaseDate;
            this.UpdatedAt = DateTime.Now;
            this.SoftwareHouseId = _SoftwareHouseId;
        }

        public static Videogame DataValidator()
        {

            Console.WriteLine("CREA un nuovo videogame");

            string user_VName=null, user_VOverview = null, user_VReleaseDate = null, user_VSoftwareHouse = null;

            bool isValidName = false, isValidOverview =false, isValidReleaseDate=false, isValidSoftwareHouse=false;
 

            while (!isValidName)
            {
                Console.WriteLine("inserisci il nome");
               user_VName = Console.ReadLine();
                isValidName = user_VName.Validatestring(false, false, false, 1, 255);
            }
            while (!isValidOverview)
            {
                Console.WriteLine("inserisci una descrizione");
                user_VOverview = Console.ReadLine();
                isValidOverview = user_VOverview.Validatestring(false, false, false, 1, 255);
            }
            while (!isValidReleaseDate)
            {
                Console.WriteLine("Inserisci la data di rilascio: dd/mm/YY");
                user_VReleaseDate = Console.ReadLine();
                isValidReleaseDate = user_VReleaseDate.Validatestring(false, false, true, null, null);
            }
            while (!isValidSoftwareHouse)
            {
                //dovrei aggiungere un controllo se quell'id esiste in tabella
                Console.WriteLine("inserisci l'id della casa produttrice");
                user_VSoftwareHouse = Console.ReadLine();
                isValidSoftwareHouse = user_VSoftwareHouse.Validatestring(false, true, false, 1, null);
            }

            return new Videogame(user_VName, user_VOverview, Convert.ToDateTime(user_VReleaseDate), Convert.ToInt16(user_VSoftwareHouse) );
        }

    }
}
