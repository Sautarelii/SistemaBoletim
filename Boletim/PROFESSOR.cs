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
            this.MATERIAs = new HashSet<MATERIA>();
        }
    
        public int idProfessor { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public Nullable<System.DateTime> dataNascimento { get; set; }
        public Nullable<System.DateTime> dataCadastro { get; set; }
        public Nullable<System.DateTime> dataUltAtualizacao { get; set; }
        public Nullable<int> IdTurma { get; set; }
        public Nullable<int> IdAluno { get; set; }
    
        public virtual Aluno Aluno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATERIA> MATERIAs { get; set; }
        public virtual Turma Turma { get; set; }
    }
}
