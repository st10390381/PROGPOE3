using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POE3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //https://stackoverflow.com/questions/4450582/observablecollection-tutorial
        //stackoverflow
        //25/6/2024
        private ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        private Recipe currentRecipe;
        public MainWindow()
        {
            InitializeComponent();
            RecipeListView.ItemsSource = recipes;
            currentRecipe = new Recipe();
        }
        //W3school-->
        //https://www.w3schools.com/xml/-->
        //25/6/2024-->
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(IngredientNameTextBox.Text) &&
                int.TryParse(CaloriesTextBox.Text, out int calories) &&
                FoodGroupComboBox.SelectedItem != null &&
                int.TryParse(MeasurementValueTextBox.Text, out int measurementValue) &&
                MeasurementUnitComboBox.SelectedItem != null)
            {
                var foodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem).Content.ToString();
                var measurementUnit = (MeasurementUnitComboBox.SelectedItem as ComboBoxItem).Content.ToString();
                var measurement = $"{measurementValue} {measurementUnit}";
                var ingredient = new Ingredient
                {
                    Name = IngredientNameTextBox.Text,
                    Calories = calories,
                    FoodGroup = foodGroup,
                    Measurement = measurement
                };
                currentRecipe.Ingredients.Add(ingredient);
                IngredientsListView.ItemsSource = null;
                IngredientsListView.ItemsSource = currentRecipe.Ingredients;
                CheckCalories();
            }
            else
            {
                MessageBox.Show("Please enter valid ingredient details.");
            }
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(StepTextBox.Text))
            //{
            //    currentRecipe.Steps.Add(new Step { Description = StepTextBox.Text });
            //    StepsListView.ItemsSource = null;
            //    StepsListView.ItemsSource = currentRecipe.Steps;
            //}
            //else
            //{
            //    MessageBox.Show("Please enter a valid step.");
            //}
            //W3school-->
            //https://www.w3schools.com/xml/-->
            //25/6/2024-->
            if (!string.IsNullOrWhiteSpace(StepTextBox.Text))
            {
                currentRecipe.Steps.Add(new Step { Description = StepTextBox.Text });
                StepsListView.ItemsSource = null;
                StepsListView.ItemsSource = currentRecipe.Steps;
            }
            else
            {
                MessageBox.Show("Please enter a valid step.");
            }

        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                currentRecipe.Name = RecipeNameTextBox.Text;

                var existingRecipe = recipes.FirstOrDefault(r => r.Name == currentRecipe.Name);
                if (existingRecipe != null)
                {
                    // Update the existing recipe
                    existingRecipe.Ingredients = currentRecipe.Ingredients;
                    existingRecipe.Steps = currentRecipe.Steps;
                }
                else
                {
                    // Add new recipe
                    recipes.Add(currentRecipe);
                }

                RecipeListView.ItemsSource = null;
                RecipeListView.ItemsSource = recipes.OrderBy(r => r.Name).ToList();
                currentRecipe = new Recipe();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please enter a recipe name.");
            }//W3school-->
             //https://www.w3schools.com/xml/-->
             //25/6/2024-->

            //if (!string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            //{
            //    currentRecipe.Name = RecipeNameTextBox.Text;
            //    recipes.Add(currentRecipe);
            //    RecipeListView.ItemsSource = null;
            //    RecipeListView.ItemsSource = recipes.OrderBy(r => r.Name).ToList();
            //    currentRecipe = new Recipe();
            //    ClearFields();
            //}
            //else
            //{
            //    MessageBox.Show("Please enter a recipe name.");
            //}
        }

        private void RecipeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentRecipe = (Recipe)RecipeListView.SelectedItem;
            if (currentRecipe != null)
            {
                RecipeNameTextBox.Text = currentRecipe.Name;
                IngredientsListView.ItemsSource = currentRecipe.Ingredients;
                StepsListView.ItemsSource = currentRecipe.Steps;
            }
        }

        private void ClearFields()
        {
            RecipeNameTextBox.Clear();
            IngredientNameTextBox.Clear();
            CaloriesTextBox.Clear();
            FoodGroupComboBox.SelectedIndex = -1;
            MeasurementValueTextBox.Clear();
            MeasurementUnitComboBox.SelectedIndex = -1;
            StepTextBox.Clear();
            IngredientsListView.ItemsSource = null;
            StepsListView.ItemsSource = null;
        }

        private void CheckCalories()
        {
            if (currentRecipe.TotalCalories > 300)
            {
                MessageBox.Show("Warning: Total calories exceed 300!");
            }
        }

        private void OpenFilterWindowButton_Click(object sender, RoutedEventArgs e)
        {//W3school-->
         //https://www.w3schools.com/xml/-->
         //25/6/2024-->
            var filterWindow = new Filter();
            if (filterWindow.ShowDialog() == true)
            {
                ApplyFilters(filterWindow.FilterRecipeName, filterWindow.FilterIngredient, filterWindow.FilterFoodGroup, filterWindow.FilterMaxCalories);
            }
        }

        private void ApplyFilters(string filterRecipeName, string filterIngredient, string filterFoodGroup, string filterMaxCalories)
        {//https://www.tutorialspoint.com/xaml/xaml_vs_csharp_code.htm-->
         //tutorialspoint-->
         //25/6/2024-->
            var filteredRecipes = recipes.Where(r =>
                (string.IsNullOrEmpty(filterRecipeName) || r.Name.Contains(filterRecipeName, StringComparison.InvariantCultureIgnoreCase)) &&
                (string.IsNullOrEmpty(filterIngredient) || r.Ingredients.Any(i => i.Name.Contains(filterIngredient, StringComparison.InvariantCultureIgnoreCase))) &&
                (string.IsNullOrEmpty(filterFoodGroup) || r.Ingredients.Any(i => i.FoodGroup.Contains(filterFoodGroup, StringComparison.InvariantCultureIgnoreCase))) &&
                (string.IsNullOrEmpty(filterMaxCalories) || r.TotalCalories <= int.Parse(filterMaxCalories))
            ).ToList();
            RecipeListView.ItemsSource = filteredRecipes.OrderBy(r => r.Name);
        }
    }
}