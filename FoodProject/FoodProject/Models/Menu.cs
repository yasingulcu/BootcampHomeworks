using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }

        public virtual int RestaurantId { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
