//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Boletim
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROFESSOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROFESSOR()
        {
            this.NOTA = new HashSet<NOTA>();
            this.PROFMATERIATURMA = new HashSet<PROFMATERIATURMA>();
        }
    
        public int COD_PROF { get; set; }
        public string EMAIL_PROFESSOR { get; set; }
        public string NOME { get; set; }
        public Nullable<int> UsuarioId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTA> NOTA { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROFMATERIATURMA> PROFMATERIATURMA { get; set; }
    }
}
