﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kitchen_WebService_OAMK
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<Exercises> Exercises { get; set; }
        public virtual DbSet<Kitchen> Kitchen { get; set; }
        public virtual DbSet<MemberLength> MemberLength { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<MemberWeight> MemberWeight { get; set; }
        public virtual DbSet<ProductsFridge> ProductsFridge { get; set; }
        public virtual DbSet<ShoppingBagProducts> ShoppingBagProducts { get; set; }
        public virtual DbSet<ShoppingBags> ShoppingBags { get; set; }
    }
}
