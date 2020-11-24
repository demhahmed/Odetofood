using System;
using System.Runtime.CompilerServices;

namespace odetofood.core
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Location { get; set; }
        [Required]
        public string Name { get; set; }
        public CuisineType CuisineType { get; set; }       
    }
}