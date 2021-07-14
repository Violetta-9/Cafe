using System;
using System.Collections.Generic;
using System.Linq;


namespace Cafe.BL.Model
{[Serializable]
     public class Order
    {
        public Dictionary<Food,double> Foods { get; }
        public double Price { get; set; }
        public DateTime Moment { get; }
        public User User { get; }

        public Order(User user)
        {
            User = user ?? throw new ArgumentNullException("UserName cannot be null or empty.", nameof(user));
            Moment=DateTime.Now;
            Foods = new Dictionary<Food, double>();

        }

        public void Add(Food foodName, double quantity)
        {
            var product=Foods.Keys.FirstOrDefault(f => f.Equals(foodName));
            if (product == null)
            {
                Foods.Add(foodName, quantity);
            }
            else
            {
                Foods[product] += quantity;
            }
        }
    }
}
