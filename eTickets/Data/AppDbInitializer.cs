using System;
using System.Collections.Generic;
using System.Linq;
using eTickets.Data.Enums;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();
                
                // Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnetbow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnetbow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnetbow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnetbow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnetbow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of first cinema"
                        },
                    });
                    context.SaveChanges();
                }
                
                // Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is Bio of the 1st actor",
                            ProfilePictureUrl = "http://dotnetbow.net/images/actors/actors-1.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is Bio of the 2nd actor",
                            ProfilePictureUrl = "http://dotnetbow.net/images/actors/actors-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is Bio of the 3rd actor",
                            ProfilePictureUrl = "http://dotnetbow.net/images/actors/actors-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is Bio of the 4th actor",
                            ProfilePictureUrl = "http://dotnetbow.net/images/actors/actors-4.jpeg"
                        },
                    });
                    context.SaveChanges();
                }
                
                // Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is Bio of the 1st actor",
                            ProfilePictureUrl = "http://dotnetbow.net/images/producers/producer-1.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is Bio of the 2nd actor",
                            ProfilePictureUrl = "http://dotnetbow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is Bio of the 3rd actor",
                            ProfilePictureUrl = "http://dotnetbow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is Bio of the 4th actor",
                            ProfilePictureUrl = "http://dotnetbow.net/images/producers/producer-4.jpeg"
                        },
                    });
                    context.SaveChanges();
                }
                
                // Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            Description = "This is Life Movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is Ghost Movie description",
                            Price = 30.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redumption",
                            Description = "This is The Shawshank Redumption Movie description",
                            Price = 29.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now.AddDays(2),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Documentary
                        },
                    });
                    context.SaveChanges();
                }
                
                // Actors & Movies
                if (!context.ActorMovies.Any())
                {
                    context.ActorMovies.AddRange(new List<ActorMovie>()
                    {
                        new ActorMovie()
                        {
                            ActorId = 2,
                            MovieId = 2
                        },
                        new ActorMovie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                        new ActorMovie()
                        {
                            ActorId = 4,
                            MovieId = 1
                        },new ActorMovie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new ActorMovie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}