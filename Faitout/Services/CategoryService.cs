using Faitout.Data;
using Faitout.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Faitout.Services
{
    public class CategoryService : BaseService
    {
        public CategoryService(ApplicationDbContext context) : base(context)
        {

        }
        public List<Category> GetCategory()
        {
            return _context.Categories.Include(x => x.EatInVat).Include(x => x.TakeAwayVat).ToList();
        }

        public Result Save(Category category)
        {
            if (category is null)
                return new Result("Category est null") ;

            if(category.Id == Guid.Empty)
            {
                //Créer
                _context.Categories.Add(category);
                _context.SaveChanges();
                return new Result();
            }
            else
            {
                //Modifier
                //
                _context.SaveChanges();
                return new Result();
            }
        }

        public Result Delete(Category category)
        {
            if (category is null)
                return new Result("Category est null");
            if (_context.Products.Any(x => x.CategoryId == category.Id))
                return new Result("Impossible de supprimer " + category.ToString() + " des produits y sont associé");
            Category categoryToDelete = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (categoryToDelete != null)
            {
                _context.Categories.Remove(categoryToDelete);
                _context.SaveChanges();
            }
            return new Result();
        }
    }
}
