
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    
</head>
<body>
<h1>Recipe Application</h1>

<h2>Table of Contents</h2>

<ul></ul>

Introduction
Features
Installation
Usage
Compilation Instructions
Running the Application
GitHub Repository
Changes Based on Feedback
Introduction
The Recipe Application allows users to create, save, and manage recipes effortlessly. Users can add ingredients with specific measurements, categorize them by food groups, and include detailed steps for each recipe.

Features
<ul>
    <li>Add and save recipes</li>
    <li>Specify ingredients with measurements and food groups</li>
    <li>Add detailed preparation steps</li>
    <li>Filter recipes based on various criteria</li>
    <li>Warning for high-calorie recipes</li>
</ul>
Installation
<ol>
    <li>Clone the repository:
    <pre><code>git clone https://github.com/yourusername/recipe-application.git</code></pre>
    </li>
    <li>Navigate to the project directory:
    <pre><code>cd recipe-application</code></pre>
    </li>
    <li>Open the solution file in Visual Studio:
    <pre><code>RecipeApplication.sln</code></pre>
    </li>
</ol>
Usage
<ol>
    <li>Launch the application.</li>
    <li>Enter recipe details, ingredients, and steps.</li>
    <li>Save and manage your recipes using the provided interface.</li>
</ol>
Compilation Instructions
<ol>
    <li>Open the solution file in Visual Studio.</li>
    <li>Ensure that all NuGet packages are restored by right-clicking on the solution and selecting "Restore NuGet Packages."</li>
    <li>Build the solution by selecting <code>Build -> Build Solution</code> or pressing <code>Ctrl+Shift+B</code>.</li>
</ol>
Example Code Snippet
<pre><code>
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
</code></pre>
Running the Application
<ol>
    <li>After building the solution, press <code>F5</code> or click on the <code>Start</code> button in Visual Studio to run the application.</li>
    <li>The main window of the application will open, allowing you to start adding recipes.</li>
</ol>
GitHub Repository
<a href="https://github.com/yourusername/recipe-application">GitHub Repository Link</a>

Changes Based on Feedback
<p>Based on feedback from my lecturer, I have made the following changes:</p>
<ul>
    <li>Added a reference for the code.</li>
    <li>Updated the README to reflect the features added in part three of the project.</li>
    <li>Implemented the functionality to input measurement values and select measurement units for ingredients.</li>
</ul>
<p>These enhancements make the application more user-friendly and functional, providing a better overall user experience.</p>
