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
    public class IngredientService : BaseService
    {
        public IngredientService(ApplicationDbContext context) : base(context)
        {

        }
        public List<Ingredient> GetIngredients()
        {
            return _context.Ingredients.Include(x=>x.ChildsIngredients).ToList();
        }

        public Result Save(Ingredient ingredient)
        {
            if (ingredient is null)
                return new Result("Ingredient est null") ;

            if (_context.Ingredients.Any(x => x.Id == ingredient.Id))
            {
                //Modifier
                _context.SaveChanges();
                return new Result();
            }
            else
            {
                //Créer
                _context.Ingredients.Add(ingredient);
                _context.SaveChanges();
                return new Result();
            }
        }

        public Result Delete(Ingredient ingredient)
        {
            if (ingredient is null)
                return new Result("Ingredient est null");
            Ingredient ingredientToDelete = _context.Ingredients.FirstOrDefault(x => x.Id == ingredient.Id);
            if (ingredientToDelete != null)
            {
                _context.Ingredients.Remove(ingredientToDelete);
                _context.SaveChanges();
            }
            return new Result();
        }
    }
}
