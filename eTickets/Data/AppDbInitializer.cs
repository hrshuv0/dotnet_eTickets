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
                            Name = "Netflix",
                            Logo = "img/Cinemas/Netflix.jpg",
                            Description = "Netflix, Inc. is an American subscription streaming service and production company." +
                                          " Launched on August 29, 1997, it offers a library of films and television series " +
                                          "through distribution deals as well as its own productions, known as Netflix Originals"
                        },
                        new Cinema()
                        {
                            Name = "The Walt Disney Company",
                            Logo = "img/Cinemas/Disney.jpg",
                            Description = "The Walt Disney Company, commonly just Disney, is an American multinational " +
                                          "entertainment and media conglomerate headquartered at the Walt Disney Studios complex in Burbank, California"
                        },
                        new Cinema()
                        {
                            Name = "DC",
                            Logo = "img/Cinemas/DC.jpg",
                            Description = "Detective Comics, Inc. (which would help inspire the abbreviation DC) was formed, " +
                                          "with Wheeler-Nicholson and Jack S. Liebowitz, Donenfeld's accountant, listed as owners"
                        },
                        new Cinema()
                        {
                            Name = "Paramount Pictures",
                            Logo = "img/Cinemas/Paramount Pictures.jpg",
                            Description = "Paramount Pictures Corporation is an American film and television production " +
                                          "and distribution company and a subsidiary of ViacomCBS."
                        },
                        new Cinema()
                        {
                            Name = "Marvel",
                            Logo = "img/Cinemas/Marvel.jpg",
                            Description = "Marvel Entertainment, LLC is an American entertainment company founded in June 1998 " +
                                          "and based in New York City, New York formed by the merger of Marvel Entertainment Group and ToyBiz."
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
                            FullName = "Will Smith",
                            Bio = "Willard Carroll Smith II, also known by his stage name The Fresh Prince, " +
                                  "is an American actor, rapper, and film producer.",
                            ProfilePictureUrl = "img/Actors/Will Smith.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Tom Cruise",
                            Bio = "Thomas Cruise Mapother IV is an American actor and producer. " +
                                  "One of the world's highest-paid actors, he has received various accolades throughout his career, " +
                                  "including three Golden Globe Awards, in addition to nominations " +
                                  "for a British Academy Film Award and three Academy Awards.",
                            ProfilePictureUrl = "img/Actors/Tom Cruise.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Chris Hemsworth",
                            Bio = "Christopher \"Chris\" Hemsworth AM is an Australian actor. He rose to prominence playing Kim Hyde in the Australian television series Home and Away before beginning a film career in Hollywood.",
                            ProfilePictureUrl = "img/Actors/Chris Hemsworth.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Leonardo Dicaprio",
                            Bio = "Leonardo Wilhelm DiCaprio is an American actor and film producer." +
                                  "Known for his work in biopics and period films, " +
                                  "DiCaprio is the recipient of numerous accolades, including an Academy Award, " +
                                  "a British Academy Film Award, and three Golden Globe",
                            ProfilePictureUrl = "img/Actors/Leonardo Dicaprio.jpg"
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
                            FullName = "Jerry Bruckheimer",
                            Bio = "Jerome Leon Bruckheimer is an American film and television producer. " +
                                  "He has been active in the genres of action, drama, fantasy, and science fiction.",
                            ProfilePictureUrl = "img/Producers/Jerry Bruckheimer.jpg"
                        },
                        new Producer()
                        {
                            FullName = "James Cameron",
                            Bio = "James Francis Cameron CC is a Canadian filmmaker. Best known for making science fiction and epic films," +
                                  " he first gained recognition for directing The Terminator. " +
                                  "He found further success with Aliens, The Abyss, Terminator 2: Judgment Day, and the action comedy True Lies.",
                            ProfilePictureUrl = "img/Producers/James Cameron.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Christopher Nolan",
                            Bio = "Christopher Edward Nolan CBE is a British-American film director, " +
                                  "producer, and screenwriter. His films have grossed more than US$5 billion worldwide, " +
                                  "and have garnered 11 Academy Awards from 36 nominations. Born and raised in London, " +
                                  "Nolan developed an interest in filmmaking from a young age",
                            ProfilePictureUrl = "img/Producers/Christopher Nolan.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Kathleen Kennedy",
                            Bio = "Kathleen Kennedy is an American film producer and current president of Lucasfilm. " +
                                  "In 1981, she co-founded the production company Amblin Entertainment with Steven Spielberg and Frank Marshall. " +
                                  "Her first film as a producer was E.T. the Extra-Terrestrial.",
                            ProfilePictureUrl = "img/Producers/Kathleen Kennedy.jpg"
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
                            Name = "Titanic",
                            Description = "This is Titanic Movie description",
                            Price = 39.50,
                            ImageUrl = "img/Movies/Titanic.jpg",
                            StartDate = DateTime.Now.AddDays(-100),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 4,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Romance
                        },
                        new Movie()
                        {
                            Name = "Avater 2",
                            Description = "This is Avater 2 Movie description",
                            Price = 39.50,
                            ImageUrl = "img/Movies/Avater 2.jpg",
                            StartDate = DateTime.Now.AddDays(6),
                            EndDate = DateTime.Now.AddDays(25),
                            CinemaId = 4,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Romance
                        },
                        new Movie()
                        {
                            Name = "Ice Age",
                            Description = "Buck, Crash, and Eddy try to keep the Lost World from being overtaken by dinosaurs, " +
                                          "as they set out to find a place of their own",
                            Price = 30.50,
                            ImageUrl = "img/Movies/Ice Age.jpg",
                            StartDate = DateTime.Now.AddDays(-513),
                            EndDate = DateTime.Now.AddDays(-412),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Spider-Man: No Way Home",
                            Description = "With Spider-Man's identity now revealed, our friendly neighborhood web-slinger is unmasked " +
                                          "and no longer able to separate his normal life as Peter Parker from the high stakes of being a superhero",
                            Price = 117.50,
                            ImageUrl = "img/Movies/Spider-Man: No Way Home.jpg",
                            StartDate = DateTime.Now.AddDays(-56),
                            EndDate = DateTime.Now.AddDays(25),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
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