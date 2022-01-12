// See https://aka.ms/new-console-template for more information

using MovieLava.API;
using MovieLava.Database;
using MovieLava.Models;
using System.Xml;

namespace MovieLava
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello, the OLD World!");
        }

        /// <summary>
        /// Demonsterates Pyrmid Doom of If Conditions
        /// </summary>
        /// <returns></returns>
        public static void GuessCharacter(MovieCharacter character)
        {
            if (character != null)
            {
                if (character is HumanCharacter)
                {
                    var humanCharacter = (HumanCharacter)character;

                    if (humanCharacter.Prefix == "CAPTAIN")
                    {
                        if (humanCharacter.Movie != null)
                        {
                            if (humanCharacter.Movie.Title.Contains("Pirates of the Caribbean"))
                            {
                                if (humanCharacter.Actor != null)
                                {
                                    if (humanCharacter.Actor.Age != null)
                                    {
                                        var age = humanCharacter.Actor.Age.Value;

                                        if (age == 58)
                                        {
                                            if (humanCharacter.Actor is FamousActor)
                                            {
                                                var famousActor = (FamousActor)humanCharacter.Actor;

                                                if (famousActor.Oscras.Any())
                                                {
                                                    if (!famousActor.Oscras.Any(o => o.Status == AwardStatus.Won))
                                                    {
                                                        if (famousActor.IsInMehranHeart)
                                                        {
                                                            if (famousActor.Movies != null)
                                                            {
                                                                if (famousActor.Movies.Any(m => m.Title == "Charlie and the Chocolate Factory"))
                                                                {
                                                                    Console.WriteLine("Here is the only CAPTAIN Jack Sparrow!");
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Demonsterates Pyrmid Doom of Usings
        /// </summary>
        /// <returns></returns>
        public static async Task LoadMoviesAsync()
        {
            using (var clientMySite = new HttpClient())
            {
                using (var clientImdb = new HttpClient())
                {
                    using (var rottenClient = new HttpClient())
                    {
                        using (var metacriticClient = new HttpClient())
                        {
                            using (var charactersClient = new HttpClient())
                            {
                                using (var db = new LavaDb())
                                {
                                    using (var xml = XmlReader.Create("mymovies.xml"))
                                    {
                                        var movies = await clientMySite.GetList<Movie>("https://mehrandvd.me/api/GetMovies");

                                        foreach (var movie in movies)
                                        {
                                            movie.Characters = await charactersClient.GetList<MovieCharacter>("");
                                            movie.RatingImdb = await charactersClient.GetOne<Rating>("");
                                            movie.RatingRottenTomatoes = await charactersClient.GetOne<Rating>("");
                                            movie.RatingMetacritic = await charactersClient.GetOne<Rating>("");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}