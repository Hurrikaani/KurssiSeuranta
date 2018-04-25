using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KurssiSeuranta.ViewModels
{
    public class KurssiViewModel
    {
        //public partial class Kurssi
        //{
        //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //    public Kurssi()
        //    {
        //        this.Läsnäolotiedot = new HashSet<Läsnäolotiedot>();
        //    }

            public string Kurssinimi { get; set; }
            public string Kurssikoodi { get; set; }
            public int KurssiID { get; set; }

            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //public virtual ICollection<Läsnäolotiedot> Läsnäolotiedot { get; set; }
        }
    }
