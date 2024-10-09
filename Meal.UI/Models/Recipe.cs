using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.UI.Models
{
    public class Recipe
    {
        public int idMeal { get; set; }
        public string strMeal { get; set; }
        public string strMealThumb { get; set; }

    }

    // TODO - This needs to be a generic in [Tools/Helper class]
    public class Root
    {
        public List<Recipe> Meals { get; set; }
    }
}
