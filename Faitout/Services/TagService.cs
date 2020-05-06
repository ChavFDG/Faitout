using Faitout.Data;
using Faitout.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Faitout.Services
{
    public class TagService : BaseService
    {
        public TagService(ApplicationDbContext context) : base(context)
        {

        }
        public List<Tag> GetTags()
        {
            return _context.Tags.ToList();
        }

        public Result Save(Tag tag)
        {
            if (tag is null)
                return new Result("Deposit est null");


            if (_context.Tags.Any(x => x.Id == tag.Id))
            {
                //Modifier
                _context.SaveChanges();
                return new Result();
            }
            else
            {
                //Créer
                _context.Tags.Add(tag);
                _context.SaveChanges();
                return new Result();
            }
        }

        public Result Delete(Tag tag)
        {
            if (tag is null)
                return new Result("tag est null");
            if (tag.RecipesTags.Any() || tag.ProductTags.Any())
                return new Result("Impossible de supprimer" + tag.ToString());
            Tag tagToDelete = _context.Tags.FirstOrDefault(x => x.Id == tag.Id);
            if (tagToDelete != null)
            {
                _context.Tags.Remove(tagToDelete);
                _context.SaveChanges();
            }
            return new Result();
        }
    }
}
