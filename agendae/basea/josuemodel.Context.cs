﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace agendae.basea
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class agendafEntiti : DbContext
    {
        public agendafEntiti()
            : base("name=agendafEntiti")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<correo> correo { get; set; }
        public virtual DbSet<persona> persona { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
