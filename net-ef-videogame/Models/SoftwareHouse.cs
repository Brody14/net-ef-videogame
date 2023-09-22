using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    public class SoftwareHouse
    {

        public int SoftwareHouseId { get; set; }
        public string Name { get; set; }
        public string VatNumber {  get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Videogame> Videogames {  get; set; }

        public override string ToString()
        {
            return @$"
Id: {SoftwareHouseId}
Nome: {Name},
Partita Iva: {VatNumber}
Città: {City}
Nazione: {Country}";        }
    }
}
