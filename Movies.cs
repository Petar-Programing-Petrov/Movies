using System;
using System.Collections.Generic;
using System.Text;

namespace Movies
{
    class Movies
    {
        public Movies(string productId, string name, string year,List<string> genre, double rating, double price)
        {
            ProductId = productId;
            Name = name;
            Year = year;
            Genre = genre;
            Rating = rating;
            Price = price;
        }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }                
        public List<string> Genre { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        
    }
}
