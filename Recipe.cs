using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE3
{
    public class Recipe
    {
        //https://stackoverflow.com/questions/4450582/observablecollection-tutorial
        //stackoverflow
        //24/6/2024
        public string Name { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; } = new ObservableCollection<Ingredient>();
        public ObservableCollection<Step> Steps { get; set; } = new ObservableCollection<Step>();
        public int TotalCalories => Ingredients.Sum(i => i.Calories);
    }
}
