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
            List<Category> categories = _context.Categories.Include(x=>x.Childs).Include(x=>x.Parent).ToList();

            return categories;
        }

        public List<Category> GetCategoryOrderInTree()
        {
            List<Category> orderedCategories = new List<Category>();
            foreach (var category in _context.Categories.Include(x=>x.Childs).Where(x => x.Level == 0).OrderBy(x => x.Order))
            {
                orderedCategories.Add(category);
                orderedCategories.AddRange(GetChildOrdered(category));
            }
            return orderedCategories;
        }

        private List<Category> GetChildOrdered(Category category)
        {
            category = _context.Categories.Include(x => x.Childs).First(x => x.Id == category.Id);
            List<Category> categories = new List<Category>();
            foreach (var child in category.Childs.OrderBy(x => x.Order))
            {
                categories.Add(child);
                categories.AddRange(GetChildOrdered(child));
            }
            return categories;

        }

        public Result Save(Category category)
        {
            if (category is null)
                return new Result("Category est null") ;

            if (_context.Categories.Any(x => x.Id == category.Id))
            {
                //Modifier
                _context.SaveChanges();
                return new Result();
            }
            else
            {
                //Créer
                if (category.ParentId == Guid.Empty)
                    category.ParentId = null;
                //Créer
                _context.Categories.Add(category);
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

        public Result IncreaseOrder(Category category)
        {
            try
            {
                List<Category> categories = _context.Categories.Where(x => x.Level == category.Level).ToList();
                var catToLower = categories.First(x => x.Order == category.Order+1);
                catToLower.Order--;
                _context.Update(catToLower);
                var catToIncrease = categories.First(x => x.Id == category.Id);
                catToIncrease.Order++;
                _context.Update(catToIncrease);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return new Result("Erreur lors du changement de valeur de l'ordre de la catégorie : " + category + "\n\r" + e.Message);
            }
            return new Result();
        }
        public Result ReduceOrder(Category category)
        {
            try
            {
                List<Category> categories = _context.Categories.Where(x => x.Level == category.Level).ToList();
                _context.Update(categories.First(x => x.Order == category.Order - 1).Order++);
                _context.Update(categories.First(x => x.Id == category.Id).Order--);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                return new Result("Erreur lors du changement de valeur de l'ordre de la catégorie : " + category + "\n\r" + e.Message);
            }
            return new Result();
        }
    }
}
