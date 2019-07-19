using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mis333ksp18Group17.Models;
using Mis333ksp18Group17.DAL;
using System.Data.Entity.Migrations;

namespace Mis333ksp18Group17.Migrations
{
    public class GenreData
    {
        public void SeedGenres(AppDbContext db)
        {
            Genre g1 = new Genre();
            g1.Name = "Action";
            db.Genres.AddOrUpdate(l => l.Name, g1);
            db.SaveChanges();

            Genre g2 = new Genre();
            g2.Name = "Adventure";
            db.Genres.AddOrUpdate(l => l.Name, g2);
            db.SaveChanges();

            Genre g3 = new Genre();
            g3.Name = "Animation";
            db.Genres.AddOrUpdate(l => l.Name, g3);
            db.SaveChanges();

            Genre g4 = new Genre();
            g4.Name = "Comedy";
            db.Genres.AddOrUpdate(l => l.Name, g4);
            db.SaveChanges();

            Genre g5 = new Genre();
            g5.Name = "Crime";
            db.Genres.AddOrUpdate(l => l.Name, g5);
            db.SaveChanges();

            Genre g6 = new Genre();
            g6.Name = "Drama";
            db.Genres.AddOrUpdate(l => l.Name, g6);
            db.SaveChanges();

            Genre g7 = new Genre();
            g7.Name = "Family";
            db.Genres.AddOrUpdate(l => l.Name, g7);
            db.SaveChanges();

            Genre g8 = new Genre();
            g8.Name = "Fantasy";
            db.Genres.AddOrUpdate(l => l.Name, g8);
            db.SaveChanges();

            Genre g9 = new Genre();
            g9.Name = "History";
            db.Genres.AddOrUpdate(l => l.Name, g9);
            db.SaveChanges();

            Genre g10 = new Genre();
            g10.Name = "Horror";
            db.Genres.AddOrUpdate(l => l.Name, g10);
            db.SaveChanges();

            Genre g11 = new Genre();
            g11.Name = "Musical";
            db.Genres.AddOrUpdate(l => l.Name, g11);
            db.SaveChanges();

            Genre g12 = new Genre();
            g12.Name = "Romance";
            db.Genres.AddOrUpdate(l => l.Name, g12);
            db.SaveChanges();

            Genre g13 = new Genre();
            g13.Name = "Science Fiction";
            db.Genres.AddOrUpdate(l => l.Name, g13);
            db.SaveChanges();

            Genre g14 = new Genre();
            g14.Name = "Thriller";
            db.Genres.AddOrUpdate(l => l.Name, g14);
            db.SaveChanges();

            Genre g15 = new Genre();
            g15.Name = "War";
            db.Genres.AddOrUpdate(l => l.Name, g15);
            db.SaveChanges();

            Genre g16 = new Genre();
            g16.Name = "Western";
            db.Genres.AddOrUpdate(l => l.Name, g16);
            db.SaveChanges();



        }
    }
}