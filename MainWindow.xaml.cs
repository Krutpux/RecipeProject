
using RecipeProekt;
using System.Windows;
using System.Windows.Controls;


namespace RecipeProekt
{
    public class RecipeController
    {
        private RecipeModel model;
        private MainWindow view;

        public RecipeController(RecipeModel model, MainWindow view)
        {
            this.model = model;
            this.view = view;
            LoadRecipes();
        }

        public void AddRecipe(string name, string theRecipe)
        {
            var newrecipe = new Recipe()
            {
                Id = model.GetRecipes().Count + 1,
                Name = name,
                TheRecipe = theRecipe
            };

            model.AddRecipe(newrecipe);
            LoadRecipes();
        }

        public void RemoveRecipe(int id)
        {
            model.RemoveRecipe(id);
            LoadRecipes();
        }

        public void EditRecipe(int id)
        {
            model.EditRecipe(id);
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            view.RecipeListBox.Items.Clear();
            foreach (var contact in model.GetRecipes())
            {
                view.RecipeListBox.Items.Add($"{contact.Name} - {contact.TheRecipe}");

            }
            view.RecipeComboBox.Items.Clear();
            foreach (var contact in model.GetRecipes())
            {
                view.RecipeComboBox.Items.Add($"{contact.Name} - {contact.TheRecipe}");

            }
        }

    }

    public partial class MainWindow : Window
    {
        private RecipeController controller;
        public MainWindow()
        {
            InitializeComponent();
            var model = new RecipeModel();
            controller = new RecipeController(model, this);
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            controller.AddRecipe(RecipeNameTextBox.Text, TheRecipeTextBox.Text);
            RecipeNameTextBox.Clear();
            TheRecipeTextBox.Clear();

        }
        private void RemoveRecipe_Click(object sender, RoutedEventArgs e)
        {
            controller.RemoveRecipe(RecipeListBox.Items.Count);
            RecipeListBox.Items.Remove(RecipeListBox.SelectedItem);
        }

        private void EditRecipe_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}