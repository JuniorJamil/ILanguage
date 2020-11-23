using ILanguage.API.Domain.Models;
using ILanguage.API.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionDetails> SessionsDetails { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<AvailableSchedule> AvailableSchedules { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Entidad Role

            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(p => p.Id);
            builder.Entity<Role>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Role>()
                .HasMany(p => p.Users)
                .WithOne(p => p.Role)
                .HasForeignKey(p => p.RoleId);

            // Agregar data a Role
            builder.Entity<Role>().HasData
                (
                    new Role { Id = 1, Name = "Nutricionista" },
                    new Role { Id = 2, Name = "Cliente" },
                    new Role { Id = 3, Name = "Administrador" },
                    new Role { Id = 4, Name = "Invitado" }


                );

            // Entidad User

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id);
            builder.Entity<User>().Property(p => p.Username)
                .IsRequired().HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Password)
               .IsRequired().HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Name)
               .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Lastname)
               .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Birthday)
               .IsRequired().HasMaxLength(10);
            builder.Entity<User>().Property(p => p.Email)
               .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Phone)
               .IsRequired().HasMaxLength(10);
            builder.Entity<User>().Property(p => p.Address)
               .IsRequired().HasMaxLength(100);
            builder.Entity<User>().Property(p => p.Active)
              .IsRequired();
            builder.Entity<User>().Property(p => p.Linkedin);

            builder.Entity<User>()
           .HasOne(pt => pt.Role)
             .WithMany(p => p.Users)
             .HasForeignKey(pt => pt.RoleId);

            builder.Entity<User>()
             .HasMany(pt => pt.Subscriptions)
             .WithOne(p => p.User)
             .HasForeignKey(pt => pt.UserId);

            builder.Entity<User>()
            .HasMany(pt => pt.AvailableSchedules)
            .WithOne(p => p.User)
            .HasForeignKey(pt => pt.UserId);


            builder.Entity<User>().HasData
                (
                    new User { Id = 1, Username = "AlfredoGomez", Password = "Gomez", Name = "Alfredo", Lastname = "Gomez", Birthday = "10/10/1980", Email = "alfredito@gmail.com", Phone = "97531546", Address = "Las Malvinas 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 1 },
                     new User { Id = 2, Username = "AlfredoGomez", Password = "Gomez", Name = "Alfredo", Lastname = "Gomez", Birthday = "10/10/1980", Email = "alfredito@gmail.com", Phone = "97531546", Address = "Las Malvinas 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 1 }


                );


            // Session

            builder.Entity<Session>().ToTable("Session");
            builder.Entity<Session>().HasKey(p => p.Id);
            builder.Entity<Session>().Property(p => p.Id)
                  .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Session>().Property(p => p.StartAt)
                .IsRequired();
            builder.Entity<Session>().Property(p => p.EndAt)
                  .IsRequired();
            builder.Entity<Session>().Property(p => p.Link)
                  .IsRequired().HasMaxLength(100);

            builder.Entity<Session>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.Sessions)
             .HasForeignKey(pt => pt.UserId);


            // Agregar data a Session
            builder.Entity<Session>().HasData
                (
                    new Session { Id = 1, StartAt = "Monday, March 24,2019 17:00:00 PM", EndAt = "Monday, March 24 ,2019 18:00:00 PM", Link = "https", UserId = 1 },
                    new Session { Id = 2, StartAt = "Thursday, March 26,2019 20:00:00 PM", EndAt = "Thurday, March 26 ,2019 21:00:00 PM", Link = "https", UserId = 2 }

                );

            //Entidad SessionDetails

            builder.Entity<SessionDetails>().ToTable("SessionDetail");
            builder.Entity<SessionDetails>().HasKey(p => p.Id);
            builder.Entity<SessionDetails>().Property(p => p.Id)
                 .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SessionDetails>().Property(p => p.State)
               .IsRequired().HasMaxLength(100);


            builder.Entity<SessionDetails>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.SessionsDetails)
             .HasForeignKey(pt => pt.UserId);

            builder.Entity<SessionDetails>()
            .HasOne(pt => pt.Session)
            .WithMany(p => p.SessionsDetails)
            .HasForeignKey(pt => pt.SessionId);

            // Agregar data a Sessions Details

            builder.Entity<SessionDetails>().HasData
                (
                    new SessionDetails { Id = 1, State = "Disponible", UserId = 1, SessionId = 1 },
                    new SessionDetails { Id = 2, State = "Disponible", UserId = 2, SessionId = 2 }

                );


            //Entidad Complaint
            builder.Entity<Complaint>().ToTable("Complaint");
            builder.Entity<Complaint>().HasKey(p => p.Id);
            builder.Entity<Complaint>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Complaint>().Property(p => p.Description)
                .IsRequired().HasMaxLength(50);

            builder.Entity<Complaint>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.Complaints)
             .HasForeignKey(pt => pt.UserId);

            // Agregar data a Complaint
            builder.Entity<Complaint>().HasData
              (
                  new Complaint { Id = 1, Description = "Descripcion de prueba complaint", UserId = 1 }
              );



            // Entidad AvailableSchedule

            builder.Entity<AvailableSchedule>().ToTable("AvailableSchedules");
            builder.Entity<AvailableSchedule>().HasKey(p => p.Id);
            builder.Entity<AvailableSchedule>().Property(p => p.Id);
            builder.Entity<AvailableSchedule>().Property(p => p.startAt)
                .IsRequired();
            builder.Entity<AvailableSchedule>().Property(p => p.endAt)
                  .IsRequired();
            builder.Entity<AvailableSchedule>().Property(p => p.state)
                .IsRequired();

            builder.Entity<AvailableSchedule>()
              .HasOne(pt => pt.User)
              .WithMany(p => p.AvailableSchedules)
           .HasForeignKey(pt => pt.UserId);

               builder.Entity<AvailableSchedule>().HasData
              (
                  new AvailableSchedule { Id = 1, startAt = "Friday, February 22, 2019 2:00:55 PM", endAt = "Friday, February 22, 2019 2:40:55 PM", state = true, UserId = 1 },
                  new AvailableSchedule { Id = 2, startAt = "Friday, February 22, 2019 5:00:55 PM", endAt = "Friday, February 22, 2019 6:40:55 PM", state = true, UserId = 2 }

              );
    

            // Entidad Subscription

            builder.Entity<Subscription>().ToTable("Subscriptions");
            builder.Entity<Subscription>().HasKey(p => p.Id);
            builder.Entity<Subscription>().Property(p => p.Id);
            builder.Entity<Subscription>().Property(p => p.MaxSessions)
                .IsRequired();
            builder.Entity<Subscription>().Property(p => p.Price)
                  .IsRequired();
            builder.Entity<Subscription>().Property(p => p.Active)
                .IsRequired();


            builder.Entity<Subscription>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.Subscriptions)
             .HasForeignKey(pt => pt.UserId);

            // Agregar data a Subscription
            builder.Entity<Subscription>().HasData
                (
                    new Subscription { Id = 1, MaxSessions = 4, Price = 10, Active = true, UserId = 1 },
                    new Subscription { Id = 2, MaxSessions = 1, Price = 13, Active = true, UserId = 2 }

                );

            // Apply Naming Conventions Policy

            builder.ApplySnakeCaseNamingConvention();

        }









    }
}
