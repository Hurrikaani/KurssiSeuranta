using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KurssiSeuranta.ViewModels
{
    public class LasnaolotietoViewModel
    {
        //public partial class Läsnäolotiedot
        //{
            public Nullable<System.DateTime> Kirjautuminen_sisään { get; set; }
            public  Nullable<System.DateTime> Kirjautuminen_ulos { get; set; }
            public string Luokkanumero { get; set; }
            public int RekisteriID { get; set; }
            public Nullable<int> OpettajaID { get; set; }
            public Nullable<int> KurssiID { get; set; }
            public Nullable<int> OpiskelijaID { get; set; }
            public Nullable<int> LuokkaID { get; set; }
            public string Kurssinimi { get; set; }
            public string Kurssikoodi { get; set; }
             public string LuokanNimi { get; set; }
             public string LuokkaKoodi { get; set; }
            [Display(Name = "Opiskelijan nimi")]
               public string OpiskelijaNimi { get; set; }
                [Display(Name = "Opettajan nimi")]
                public string OpettajaNimi { get; set; }
                public string Etunimi { get; set; }
                public string Sukunimi { get; set; }
                public string Opettajanro { get; set; }
                 public int? KirjattuID { get; set; }
                 public int? KurssiRekisteriID { get; set; }
               public string Opiskelijanro { get; set; }
                public int? KirjattuUlosID { get; set; }
                public int? KurssiUlosID { get; set; }





        //public virtual Kurssi Kurssi { get; set; }
        //public virtual OpetusTila OpetusTila { get; set; }
        //public virtual Opettaja Opettaja { get; set; }
        //public virtual Opiskelija Opiskelija { get; set; }
    }
    }
