﻿namespace AmazonPizza.Web.Models
{
    public class ProductsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
 
        public double Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }
    }
}
