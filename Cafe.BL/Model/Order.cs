using System;
using System.Collections.Generic;
using System.Linq;


namespace Cafe.BL.Model
{[Serializable]
     public class Order
    {   public int UserId { get; set; }
        public int Id { get; set; }
        public Dictionary<Food,double> Foods { get; }
        public double Price { get; set; }
        public DateTime? Moment { get; set; }
        public virtual ICollection<Food> Food { get; set; }
        public virtual User User { get; set; }

        public Order()
        {
        }

        public Order(User user)
        {
            User = user ?? throw new ArgumentNullException("UserName cannot be null or empty.", nameof(user));
            Moment=DateTime.UtcNow;
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
