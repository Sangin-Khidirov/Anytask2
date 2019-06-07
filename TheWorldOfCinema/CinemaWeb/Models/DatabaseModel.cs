using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace CinemaWeb.Models
{
    namespace DataAccessPostgreSqlProvider
    {
        public class CinemaDbContext : DbContext
        {
            public CinemaDbContext()
            {

                Database.EnsureCreated();
            }

            public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
            {
            }

            public DbSet<DbCinema> Cinemas { get; set; }
            public static string ConnectionString { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql(CinemaDbContext.ConnectionString);

                base.OnConfiguring(optionsBuilder);
            }
        }

        public class DbCinema
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            /// <summary>
            /// Название
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Адрес
            /// </summary>
            public string Adress { get; set; }
            /// <summary>
            /// Фильмы
            /// </summary>
            public virtual Collection<DbFilm> Films { get; set; }
        }

        public class DbFilm
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int CinemaId { get; set; }
            [ForeignKey("CinemaId")]

            public virtual DbCinema Cinema { get; set; }
            /// <summary>
            /// Название
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Мест
            /// </summary>
            public string Seats { get; set; }
            /// <summary>
            /// Время
            /// </summary>
            public string Time { get; set; }

            public override string ToString()
            {
                return $"Название: {Name}, Мест: {Seats}, Время: {Time}";
            }
        }

       
    }
}
