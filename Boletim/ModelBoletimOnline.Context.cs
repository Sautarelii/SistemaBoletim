﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BoletimOnline2Entities3 : DbContext
    {
        public BoletimOnline2Entities3()
            : base("name=BoletimOnline2Entities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<ALUNO> ALUNO { get; set; }
        public virtual DbSet<AVALIACAO> AVALIACAO { get; set; }
        public virtual DbSet<MATERIA> MATERIA { get; set; }
        public virtual DbSet<NOTA> NOTA { get; set; }
        public virtual DbSet<PROFESSOR> PROFESSOR { get; set; }
        public virtual DbSet<PROFMATERIATURMA> PROFMATERIATURMA { get; set; }
        public virtual DbSet<TURMA> TURMA { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        public System.Data.Entity.DbSet<Boletim.Models.PROFMATERIATURMA> PROFMATERIATURMAs { get; set; }
    }
}