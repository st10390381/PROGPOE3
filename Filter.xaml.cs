using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POE3
{
    /// <summary>
    /// Interaction logic for Filter.xaml
    /// </summary>
    public partial class Filter : Window
    { //https://www.tutorialspoint.com/xaml/xaml_vs_csharp_code.htm-->
        //tutorialspoint-->
        //26/06/2024-->
        public string FilterRecipeName { get; set; }
        public string FilterIngredient { get; set; }
        public string FilterFoodGroup { get; set; }
        public string FilterMaxCalories { get; set; }
        public Filter()
        {
            InitializeComponent();
        }
        private void ApplyFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            //https://www.tutorialspoint.com/xaml/xaml_vs_csharp_code.htm-->
            //tutorialspoint-->
            //26/06/2024-->
            FilterRecipeName = FilterRecipeNameTextBox.Text;
            FilterIngredient = FilterIngredientTextBox.Text;
            FilterFoodGroup = FilterFoodGroupTextBox.Text;
            FilterMaxCalories = FilterMaxCaloriesTextBox.Text;
            DialogResult = true;
            Close();
        }
    }
}
