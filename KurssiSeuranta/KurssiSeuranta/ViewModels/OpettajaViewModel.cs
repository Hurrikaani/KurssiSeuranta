using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KurssiSeuranta.ViewModels
{
    public class OpettajaViewModel
    {
        //public partial class Opettaja
        //{
        //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //    public Opettaja()
        //    {
        //        this.Läsnäolotiedot = new HashSet<Läsnäolotiedot>();
        //    }

            public int OpettajaID { get; set; }
            public string Etunimi { get; set; }
            public string Sukunimi { get; set; }
            public string Opettajanro { get; set; }

            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //public virtual ICollection<Läsnäolotiedot> Läsnäolotiedot { get; set; }
        }
    }

