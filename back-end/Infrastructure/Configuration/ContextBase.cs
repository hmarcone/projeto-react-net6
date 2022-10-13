﻿using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration;

public class ContextBase : IdentityDbContext<ApplicationUser>
{
    public ContextBase(DbContextOptions<ContextBase> options) : base(options)
    {
    }

    public DbSet<Message> Message { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ObterStringConexao());
            base.OnConfiguring(optionsBuilder);
        }
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

        base.OnModelCreating(builder);
    }


    public string ObterStringConexao()
    {
        //ToDo: verificar depois o banco
        return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Api_DDD_2022_Net6;Integrated Security=True";
        //return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=API_DDD_2022;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
    }
}
