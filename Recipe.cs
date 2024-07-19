using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProekt
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TheRecipe { get; set; }
    }

    public class RecipeModel
    {
        private List<Recipe> recipes = new List<Recipe>();

        public List<Recipe> GetRecipes() { return recipes; }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public void RemoveRecipe(int id)
        {
            recipes.RemoveAll(recipe => recipe.Id == id);
        }

        public void EditRecipe(int id)
        {
            recipes.RemoveAll(recipe => recipe.Id == id);
        }
    }
}