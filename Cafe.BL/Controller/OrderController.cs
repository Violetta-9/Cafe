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
       private const string FOODS_FILE_NAME = "Foods.dat";
       private const string ORDERS_FILE_NAME = "Orders.dat";
        private readonly User user;
       public List<Food> Foods { get; }
       public Order Order { get; }

       public OrderController(User user)
       {
           this.user = user ?? throw new ArgumentNullException("Username cannot be null or empty.", nameof(user));
           Foods = GetAllFoods();
           Order = GetOrder();
       }

       public bool Add(Food foodName,double quantity)
       {
           var food=Foods.SingleOrDefault(f => f.Name == foodName.Name);
           if (food != null)
           {
                Order.Add(food, quantity);
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
           return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
       }
       private Order GetOrder()
       {
           return Load<Order>(ORDERS_FILE_NAME) ?? new Order(user);
       }

        private void Save()
       {
           Save(FOODS_FILE_NAME,Foods);
           Save(ORDERS_FILE_NAME,Order);
       }

   }
}
