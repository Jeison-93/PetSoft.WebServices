using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PetSoft.WebServices.Data.Models;

public partial class PetsoftdbContext : DbContext
{
    public PetsoftdbContext(DbContextOptions<PetsoftdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Client { get; set; }

    public virtual DbSet<Clientservice> Clientservice { get; set; }

    public virtual DbSet<Documenttype> Documenttype { get; set; }

    public virtual DbSet<Pet> Pet { get; set; }

    public virtual DbSet<Servicestate> Servicestate { get; set; }

    public virtual DbSet<Servicetype> Servicetype { get; set; }

    public virtual DbSet<Species> Species { get; set; }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<Usertype> Usertype { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("client");

            entity.HasIndex(e => e.DocumentType, "DocumentType");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.DocumentNumber).HasMaxLength(50);
            entity.Property(e => e.DocumentType).HasMaxLength(10);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.DocumentTypeNavigation).WithMany(p => p.Client)
                .HasForeignKey(d => d.DocumentType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_ibfk_1");
        });

        modelBuilder.Entity<Clientservice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clientservice");

            entity.HasIndex(e => e.Pet, "Pet");

            entity.HasIndex(e => e.ServiceState, "ServiceState");

            entity.HasIndex(e => e.ServiceType, "ServiceType");

            entity.HasIndex(e => e.UserSave, "UserSave");

            entity.HasIndex(e => e.UserUpdate, "UserUpdate");

            entity.Property(e => e.DateService).HasMaxLength(20);
            entity.Property(e => e.HourService).HasMaxLength(20);
            entity.Property(e => e.SaveDate).HasColumnType("timestamp");
            entity.Property(e => e.ServiceState).HasMaxLength(10);
            entity.Property(e => e.ServiceType).HasMaxLength(10);
            entity.Property(e => e.UpdateDate).HasColumnType("timestamp");

            entity.HasOne(d => d.PetNavigation).WithMany(p => p.Clientservice)
                .HasForeignKey(d => d.Pet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientservice_ibfk_1");

            entity.HasOne(d => d.ServiceStateNavigation).WithMany(p => p.Clientservice)
                .HasForeignKey(d => d.ServiceState)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientservice_ibfk_3");

            entity.HasOne(d => d.ServiceTypeNavigation).WithMany(p => p.Clientservice)
                .HasForeignKey(d => d.ServiceType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientservice_ibfk_2");

            entity.HasOne(d => d.UserSaveNavigation).WithMany(p => p.ClientserviceUserSaveNavigation)
                .HasForeignKey(d => d.UserSave)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientservice_ibfk_4");

            entity.HasOne(d => d.UserUpdateNavigation).WithMany(p => p.ClientserviceUserUpdateNavigation)
                .HasForeignKey(d => d.UserUpdate)
                .HasConstraintName("clientservice_ibfk_5");
        });

        modelBuilder.Entity<Documenttype>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");

            entity.ToTable("documenttype");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pet");

            entity.HasIndex(e => e.Client, "Client");

            entity.HasIndex(e => e.Species, "Species");

            entity.Property(e => e.Breed).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Species).HasMaxLength(10);
            entity.Property(e => e.Weight).HasPrecision(5);

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Pet)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pet_ibfk_2");

            entity.HasOne(d => d.SpeciesNavigation).WithMany(p => p.Pet)
                .HasForeignKey(d => d.Species)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pet_ibfk_1");
        });

        modelBuilder.Entity<Servicestate>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");

            entity.ToTable("servicestate");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<Servicetype>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");

            entity.ToTable("servicetype");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<Species>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");

            entity.ToTable("species");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.DocumentType, "DocumentType");

            entity.HasIndex(e => e.UserType, "UserType");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.DocumentNumber).HasMaxLength(50);
            entity.Property(e => e.DocumentType).HasMaxLength(10);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.UserType).HasMaxLength(10);

            entity.HasOne(d => d.DocumentTypeNavigation).WithMany(p => p.User)
                .HasForeignKey(d => d.DocumentType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_ibfk_1");

            entity.HasOne(d => d.UserTypeNavigation).WithMany(p => p.User)
                .HasForeignKey(d => d.UserType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_ibfk_2");
        });

        modelBuilder.Entity<Usertype>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");

            entity.ToTable("usertype");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
