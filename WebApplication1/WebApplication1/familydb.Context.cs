﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BigFamilyWeb
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class familydbEntities : DbContext
    {
        public familydbEntities()
            : base("name=familydbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
