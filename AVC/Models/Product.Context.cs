﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AVCEntities : DbContext
    {
        public AVCEntities()
            : base("name=AVCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Subcategory> Subcategory { get; set; }
    
        public virtual ObjectResult<spMenuBuilder_Result> spMenuBuilder()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spMenuBuilder_Result>("spMenuBuilder");
        }
    }
}
