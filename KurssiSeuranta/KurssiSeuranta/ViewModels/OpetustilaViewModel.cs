using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KurssiSeuranta.ViewModels
{
    public class OpetustilaViewModel
    {
        //public partial class OpetusTila
        //{
        //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //    public OpetusTila()
        //    {
        //        this.Läsnäolotiedot = new HashSet<Läsnäolotiedot>();
        //    }

            public int LuokkaID { get; set; }
            public string LuokanNimi { get; set; }
            public string LuokkaKoodi { get; set; }

            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //public virtual ICollection<Läsnäolotiedot> Läsnäolotiedot { get; set; }
        }
    }
