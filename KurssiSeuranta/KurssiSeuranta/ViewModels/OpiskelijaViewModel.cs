using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KurssiSeuranta.ViewModels
{
    public class OpiskelijaViewModel
    {
        //public partial class Opiskelija
        //{
        //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //    public Opiskelija()
        //    {
        //        this.Läsnäolotiedot = new HashSet<Läsnäolotiedot>();
        //    }

            public string Etunimi { get; set; }
            public string Sukunimi { get; set; }
            public string Opiskelijanro { get; set; }
            public int OpiskelijaID { get; set; }
            public string Tutkinto { get; set; }

            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //public virtual ICollection<Läsnäolotiedot> Läsnäolotiedot { get; set; }
        }
    }
