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
            return  _context.Taxes.ToList();
        }

        public Result Save(VAT vat)
        {
            if (vat is null)
                return new Result("VAT est null") ;

            if(vat.Id == Guid.Empty)
            {
                //Créer
                _context.Taxes.Add(vat);
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

        public Result Delete(VAT vat)
        {
            if (vat is null)
                return new Result("VAT est null");
            VAT vatToDelete = _context.Taxes.FirstOrDefault(x => x.Id == vat.Id);
            if (vatToDelete != null)
            {
                _context.Taxes.Remove(vatToDelete);
                _context.SaveChanges();
            }
            return new Result();
        }
    }
}
