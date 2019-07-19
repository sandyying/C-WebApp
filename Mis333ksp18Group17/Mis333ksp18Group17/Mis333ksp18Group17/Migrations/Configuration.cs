namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mis333ksp18Group17.DAL.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Mis333ksp18Group17.DAL.AppDbContext context)
        {
            //GenreData AddGenres = new GenreData();
            //AddGenres.SeedGenres(context);

            //MovieData AddMovies = new MovieData();
            //AddMovies.SeedMovies(context);

            //SeedIdentity si = new SeedIdentity();
            //si.AddAdmin(context);



            //AddEmployees ad = new AddEmployees();
            //ad.SeedEmployees(context);
        }
    }
}
