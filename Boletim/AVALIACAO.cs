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
    
    public partial class AVALIACAO
    {
        public int COD_AVALIACAO { get; set; }
        public string NOME { get; set; }
        public string DESCRICAO { get; set; }
        public System.DateTime DATA { get; set; }
        public decimal PESO { get; set; }
        public int COD_PROF { get; set; }
        public int COD_MATERIA { get; set; }
        public int COD_TURMA { get; set; }
        public Nullable<int> PERIODO_LETIVO { get; set; }
    
        public virtual PROFMATERIATURMA PROFMATERIATURMA { get; set; }
    }
}
