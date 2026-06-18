using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_a.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Price { get; set; }

        public string Planet { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string RecommendedEnvironment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}