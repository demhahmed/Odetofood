using System.Collections.Generic;
using System.Linq;
using odetofood.core;

namespace odetofood.data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetbyName(string name);
        Restaurant GetbyId(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
    }
    
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 0, Location = "4th street", Name = "First", CuisineType = (CuisineType) 2},
                new Restaurant{Id = 1, Location = "4th street", Name = "Second", CuisineType = (CuisineType) 2},
                new Restaurant{Id = 2, Location = "4th street", Name = "Third", CuisineType = (CuisineType) 2}
            };
        }

        public Restaurant GetbyId(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant == null) return restaurant;
            restaurant.Name = updatedRestaurant.Name;
            restaurant.Location = updatedRestaurant.Location;
            restaurant.CuisineType = updatedRestaurant.CuisineType;

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restaurant> GetbyName(string name = null)
        {
            return from r in restaurants where string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name) orderby r.Id select r;
        }
    }
}