using System;
using System.Collections.Generic;
using System.Text;

namespace Movies
{
    public class Users
    {
        public Users(string userId, string name, int[] viewedMovies, int[] purchasedMovies)
        {
             UserId = userId;
             Name = name;
             ViewedMovies = viewedMovies;
             PurchasedMovies = purchasedMovies;
        }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int[] ViewedMovies { get; set; }
        public int[] PurchasedMovies { get; set; }
    }
}
