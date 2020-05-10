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
        protected readonly UploadService _uploadService;
        public RecipeService(ApplicationDbContext context, UploadService uploadService) : base(context)
        {
            _uploadService = uploadService;
        }
        public List<Recipe> GetRecipes()
        {
            return _context.Recipes.Include(x => x.IngredientRecipeQuantity).ThenInclude(x => x.Ingredient)
                                   .Include(x => x.RecipesTags).ThenInclude(x => x.Tag)
                                   .ToList();
        }

        public Result Save(Recipe recipe, List<RecipeTag> rtToRemove, List<RecipeTag> rtToAdd, List<IngredientRecipeQuantity> irqToRemove, List<IngredientRecipeQuantity> irqToAdd)
        {
            if (recipe is null)
                return new Result("Deposit est null");


            if (!_context.Recipes.Any(x => x.Id == recipe.Id))
                _context.Recipes.Add(recipe);

            //Recipe Tag
            foreach (var rt in rtToRemove)
            {
                if (_context.RecipesTags.Any(x => x.Id == rt.Id))
                    _context.RecipesTags.Remove(rt);
            }
            foreach (var rt in rtToAdd)
            {
                if (!_context.RecipesTags.Any(x => x.Id == rt.Id))
                    _context.ChangeTracker.Entries<RecipeTag>().First(x => x.Entity.Id == rt.Id).State = EntityState.Added;
            }

            //Ingredient recipe quantity
            foreach (var irq in irqToRemove)
            {
                if (_context.IngredientsRecipesQuantities.Any(x => x.Id == irq.Id))
                    _context.IngredientsRecipesQuantities.Remove(irq);
            }
            foreach (var irq in irqToAdd)
            {
                //If ingredient don't exist add it
                if (!_context.Ingredients.Any(x => x.Id == irq.IngredientId))
                    _context.ChangeTracker.Entries<Ingredient>().First(x=>x.Entity.Id == irq.IngredientId).State = EntityState.Added;

                if (!_context.IngredientsRecipesQuantities.Any(x => x.Id == irq.Id))
                    _context.ChangeTracker.Entries<IngredientRecipeQuantity>().First(x => x.Entity.Id == irq.Id).State = EntityState.Added;
            }

            //Sub ingredient Order
            foreach (var isio in _context.ChangeTracker.Entries<IngredientSubIngredientOrder>())
            {
                if (isio.Entity.Parent == null)
                    isio.State = EntityState.Deleted;
                if (!_context.IngredientsSubIngredientsOrders.Any(x => x.Id == isio.Entity.Id)) ;
                    isio.State = EntityState.Added;        
            }

            foreach(var ingredient in _context.ChangeTracker.Entries<Ingredient>())
            {
                var test = ingredient.GetDatabaseValues();
                ingredient.State = EntityState.Added;
            }

            //Create new ingredients
            foreach (var ingredient in _context.ChangeTracker.Entries<Ingredient>().Where(x=>x.State == EntityState.Modified && recipe.IngredientRecipeQuantity.Any(irq=>irq.IngredientId == x.Entity.Id)))
            {
                //If one ingredient value has been modified create a new one to don't brake the unique relation
                foreach (var prop in ingredient.Properties)
                {
                    if(prop.IsModified)
                    {
                        //Create clone and add it to bdd
                        var clone = ingredient.Entity.Clone();
                        _context.Entry(clone).State = EntityState.Added;
                        //Change IRQ ingredient id to clone one
                        recipe.IngredientRecipeQuantity.First(x => x.IngredientId == ingredient.Entity.Id).IngredientId = clone.Id;
                        //Don't change original ingredient to don't breack unicities
                        ingredient.Reload();
                        break;
                    }
                }
            }
            _context.SaveChanges();
            return new Result();
        }

        public Result Delete(Recipe deposit)
        {
            if (deposit is null)
                return new Result("Recipe est null");
            Recipe recipeToDelete = _context.Recipes.FirstOrDefault(x => x.Id == deposit.Id);
            if (recipeToDelete != null)
            {
                recipeToDelete.Pictures.ForEach(x => _uploadService.Remove(x));
                _context.Recipes.Remove(recipeToDelete);
                _context.SaveChanges();
            }
            return new Result();
        }
    }
}
