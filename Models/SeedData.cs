using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "Other Side of Heaven",
                         ReleaseDate = DateTime.Parse("1989-1-11"),
                         Genre = "Inspirational",
                         Rating = "PG",
                         Price = 7.99M
                     },

                     new Movie
                     {
                         Title = "Meet the Mormons",
                         ReleaseDate = DateTime.Parse("1984-3-13"),
                         Genre = "Documentary",
                         Rating = "G",
                         Price = 8.99M
                     },

                     new Movie
                     {
                         Title = "Baptists at our BBQ",
                         ReleaseDate = DateTime.Parse("1986-2-23"),
                         Genre = "Comedy",
                         Rating = "G",
                         Price = 9.99M
                     }
                );
                context.SaveChanges();
            }
        }
    }
}