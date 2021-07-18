using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Movies
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader productsInfoReader = new StreamReader("../../../Products.txt"))
            using (StreamReader userIdAndMovieIdReader = new StreamReader("../../../CurrentUserSession.txt"))
            using (StreamReader usersInfoReader = new StreamReader("../../../Users.txt"))
            {
                string[] userInfo = usersInfoReader.ReadLine().Split(new string[] { ",", " "}, StringSplitOptions.RemoveEmptyEntries);
                string[] userIdAndMovieIdInfo = userIdAndMovieIdReader.ReadLine().Split(new string[] { ", "}, StringSplitOptions.RemoveEmptyEntries);
                string[] productsInfo = productsInfoReader.ReadLine().Split(new string[] { ", ",","}, StringSplitOptions.RemoveEmptyEntries);
                
                List<Users> usersList = new List<Users>();
                
                while (userInfo != null)
                {
                    string userid = userInfo[0];
                    string name = userInfo[1];
                    int[] viewedMovies = userInfo[2].Split(";", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    int[] purchaseddMovies = userInfo[3].Split(";", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    Users user = new Users(userid, name, viewedMovies,purchaseddMovies);


                    usersList.Add(user);
                    if (!usersInfoReader.EndOfStream)
                    {
                        userInfo = usersInfoReader.ReadLine().Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);

                    }
                    else
                    {
                        break;
                    }
                }

                List<Movies> moviesList = new List<Movies>();

                while (productsInfo != null)
                {
                    string movieId = productsInfo[0];
                    string movieName = productsInfo[1];
                    string movieYear = productsInfo[2];
                    int counter = productsInfo.Length -2 ;
                    List<string> movieGenre = new List<string>();
                    for (int i = 3; i < counter; i++)
                    {
                        movieGenre.Add(productsInfo[i]);
                    }
                    double movieRating = double.Parse(productsInfo[productsInfo.Length - 2]);
                    double moviePrice = double.Parse(productsInfo[productsInfo.Length - 1]);
                    
                    Movies movie = new Movies(movieId,movieName,movieYear,movieGenre,movieRating,moviePrice);
                    moviesList.Add(movie);
                    if (!productsInfoReader.EndOfStream)
                    {
                        productsInfo = productsInfoReader.ReadLine().Split(new string[] { ", ", "," }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else
                    {
                        break;
                    }
                    
                }
                Console.WriteLine("Top 3");
                foreach (var movie in moviesList.OrderByDescending(m => m.Rating).Take(3))
                {
                    Console.WriteLine(movie.Name + "...Rating..." + movie.Rating);
                    
                }

                while (userIdAndMovieIdInfo != null)
                {
                    string userId = userIdAndMovieIdInfo[0];
                    string currentMovieId = userIdAndMovieIdInfo[1];


                    var movie = moviesList.Find(m =>int.Parse(m.ProductId) == int.Parse(currentMovieId));
                    var currentMovieGenre = movie.Genre.First();

                    var recomendedMovie = moviesList.Find(m => m.Genre.Contains(currentMovieGenre));
                    Console.WriteLine("We recomend you: " + recomendedMovie.Name);

                    if (!userIdAndMovieIdReader.EndOfStream)
                    {
                        userIdAndMovieIdInfo = userIdAndMovieIdReader.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else
                    {
                        break;
                    }
                    
                }
                

            }   
            
        }
    }
}
