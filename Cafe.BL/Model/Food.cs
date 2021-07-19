 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BL.Model
{[Serializable]
     public class Food
     {
         public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Белок.
        /// </summary>
        public double Proteins{get; set; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Калории за 100г продукта
        /// </summary>
        public double Calories { get; set; }

        public double Price { get; set; }
        public virtual Order Order{ get; set; }

        public Food() { }
        public Food(string foodName):this (foodName,0,0,0,0,0){}
        

        public Food(string name, double proteins, double fats, double carbohydrates, double calories,double price)
        {//todo:проверка 
            Name = name;
            Proteins = proteins/100.0;
            Fats = fats/100.0;
            Carbohydrates = carbohydrates/100.0;
            Calories = calories/100.0;
            Price = price;
        }

        public override string ToString()
        {
            return Name; 
        }
    }
}
