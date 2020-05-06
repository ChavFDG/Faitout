using Faitout.Data;
using Faitout.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Faitout.Services
{
    public class RecipeService : BaseService
    {
        public RecipeService(ApplicationDbContext context) : base(context)
        {

        }
        public List<Recipe> GetRecipes()
        {
            return _context.Recipes.Include(x => x.IngredientRecipeQuantity).ThenInclude(x => x.Ingredient)
                                   .Include(x => x.RecipesTags).ThenInclude(x => x.Tag)
                                   .ToList();
        }

        public Result Save(Recipe recipe)
        {
            if (recipe is null)
                return new Result("Deposit est null");


            if (_context.Recipes.Any(x => x.Id == recipe.Id))
            {
                //Modifier
                _context.SaveChanges();
                return new Result();
            }
            else
            {
                //Créer
                _context.Recipes.Add(recipe);
                _context.SaveChanges();
                return new Result();
            }
        }

        public Result Delete(Recipe deposit)
        {
            if (deposit is null)
                return new Result("Recipe est null");
            Recipe recipeToDelete = _context.Recipes.FirstOrDefault(x => x.Id == deposit.Id);
            if (recipeToDelete != null)
            {
                _context.Recipes.Remove(recipeToDelete);
                _context.SaveChanges();
            }
            return new Result();
        }
    }
}
