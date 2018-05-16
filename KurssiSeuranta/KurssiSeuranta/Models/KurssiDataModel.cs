using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KurssiSeuranta.Models
{
    public class KurssiDataModel
    {
        public DateTime? Kirjautuminen_sisään { get; set; }
        public DateTime? Kirjautuminen_ulos { get; set; }
        public string LuokanNimi { get; set; }
        public string  LuokkaKoodi { get; set; }
        public string Opiskelijanro { get; set; }
        public int? OpiskelijaID { get; set; }
        public string Kurssikoodi { get; set; }
        public int? KurssiID { get; set; }
    }
}
