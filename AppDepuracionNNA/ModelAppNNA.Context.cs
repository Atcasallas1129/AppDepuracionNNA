﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppDepuracionNNA
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EncargoFiduciarioNNAEntities : DbContext
    {
        public EncargoFiduciarioNNAEntities()
            : base("name=EncargoFiduciarioNNAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DiviPola> DiviPola { get; set; }
        public virtual DbSet<EncargoFiduciarioDep> EncargoFiduciarioDep { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<EncargoFiduciario> EncargoFiduciario { get; set; }
        public virtual DbSet<vw_consultaHistoricoNNAS> vw_consultaHistoricoNNAS { get; set; }
    }
}