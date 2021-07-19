using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Cafe.BL.Model;

namespace Cafe.BL.Controller
{
   public class OrderController:ControllerBase
   {
        private readonly User user;
       public List<Food> Foods { get; }
       public Order Orders { get; }

       public OrderController(User user)
       {
           this.user = user ?? throw new ArgumentNullException("Username cannot be null or empty.", nameof(user));
           Foods = GetAllFoods();
           Orders = GetOrder();
       }

       public bool Add(Food foodName,double quantity)
       {
           var food=Foods.SingleOrDefault(f => f.Name == foodName.Name);
           if (food != null)
           {
                Orders.Add(food, quantity);
                Save();
                return true;
           }
           else
           {
               ////Foods.Add(foodName);
               ////Order.Add(foodName, quantity);
               ////Save();
                Console.WriteLine("Such  is no product on the menu.");
                return false;
            }

       }

       private List<Food> GetAllFoods()
       {
           return Load<Food>() ?? new List<Food>();
       }
       private Order GetOrder()
       {
           return Load<Order>().FirstOrDefault() ?? new Order(user);
       }

        private void Save()
       {
           Save(Foods);
           Save(new List<Order>() { Orders });
        }

   }
}
