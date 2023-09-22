using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    public class Videogame
    {
        public long VideogameId { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime Release_date { get; set; }

        public int SoftwareHouseId { get; set; }
        public SoftwareHouse? SoftwareHouse { get;  set; }

        public override string ToString()
        {
            string result = $@"
ID: {VideogameId} 
Nome videogame: {Name}
Trama: {Overview}
Data di rilascio: {Release_date.ToString("dd/MM/yyyy")}";

            if(SoftwareHouse != null)
            {
                result += $@"
ID: {VideogameId} 
Nome videogame: {Name}
Trama: {Overview}
Data di rilascio: {Release_date.ToString("dd/MM/yyyy")}
Software House: {SoftwareHouse.Name}";
            }

            return result;
        }
    }
}

