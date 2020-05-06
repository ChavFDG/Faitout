using Faitout.Data;
using Faitout.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Faitout.Services
{
    public class VATService : BaseService
    {
        public VATService(ApplicationDbContext context) : base(context)
        {

        }
        public List<VAT> GetVAT()
        {
            return  _context.VATs.ToList();
        }

        public Result Save(VAT vat)
        {
            if (vat is null)
                return new Result("VAT est null") ;

            if (_context.VATs.Any(x => x.Tax == vat.Tax))
            return new Result("La tax " + vat.ToString() + " existe déjà");

            if (_context.VATs.Any(x=>x.Id == vat.Id))
            {
                //Modifier
                _context.SaveChanges();
                return new Result();
            }
            else
            {
                //Créer
                _context.VATs.Add(vat);
                _context.SaveChanges();
                return new Result();
            }
        }

        public Result Delete(VAT vat)
        {
            if (vat is null)
                return new Result("VAT est null");
            VAT vatToDelete = _context.VATs.FirstOrDefault(x => x.Id == vat.Id);
            if (vatToDelete != null)
            {
                _context.VATs.Remove(vatToDelete);
                _context.SaveChanges();
            }
            return new Result();
        }
    }
}
