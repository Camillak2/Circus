﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Circus.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Circus_SagdievaEntities : DbContext
    {
        public Circus_SagdievaEntities()
            : base("name=Circus_SagdievaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<AnimalType> AnimalType { get; set; }
        public virtual DbSet<Applicationn> Applicationn { get; set; }
        public virtual DbSet<Cage> Cage { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Perfomance> Perfomance { get; set; }
        public virtual DbSet<PerfomanceType> PerfomanceType { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Taskk> Taskk { get; set; }
        public virtual DbSet<Timetable> Timetable { get; set; }
        public virtual DbSet<TimetableForAnimal> TimetableForAnimal { get; set; }
        public virtual DbSet<TypeOfArtist> TypeOfArtist { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }
    }
}
