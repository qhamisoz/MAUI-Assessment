using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.UI.Models
{
    public class Category
    {
        public int idCategory { get; set; }
        public string strCategory { get; set; }
    }

    // TODO - This needs to be a generic in [Tools/Helper class]
    public class CategoryRoot
    {
        public List<Category> Categories { get; set; }
    }
}
