using ExamApi.Domain.Entities;
using ExamApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Repository.Context
{
    public class Context : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardEntity>().HasKey(k=>k.CardId);
            modelBuilder.Entity<CardEntity>().Property(k => k.CardId).ValueGeneratedOnAdd();
            modelBuilder.Entity<CustomerCardEntity>().HasKey(k=> new {k.CustomerId, k.CardId });
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MEMORY");
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
