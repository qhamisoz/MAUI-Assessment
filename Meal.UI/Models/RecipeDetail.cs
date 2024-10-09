using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.UI.Models
{
    public class RecipeDetail : Recipe
    {
        public string strInstructions { get; set; }
    }

    // TODO - This needs to be a generic in [Tools/Helper class]
    class RecipeDetailRoot
    {
        public List<RecipeDetail> Meals { get; set; }
    }
}
