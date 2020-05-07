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
    public class DepositService : BaseService
    {
        protected readonly UploadService _uploadService;
        public DepositService(ApplicationDbContext context, UploadService uploadService) : base(context)
        {
            _uploadService = uploadService;
        }
        public List<Deposit> GetDeposits()
        {
            return _context.Deposits.Where(x => !x.IsArchive).ToList();
        }

        public Result Save(Deposit deposit)
        {
            
            if (deposit is null)
                return new Result("Deposit est null") ;

            if (_context.Deposits.Any(x => x.Id == deposit.Id))
            {
                //Modifier
                _context.SaveChanges();
                return new Result();
            }
            else
            {
                //Créer
                _context.Deposits.Add(deposit);
                _context.SaveChanges();
                return new Result();
            }
        }

        public Result Delete(Deposit deposit)
        {
            if (deposit is null)
                return new Result("Deposit est null");
            Deposit depositTodelete = _context.Deposits.FirstOrDefault(x => x.Id == deposit.Id);
            if (depositTodelete != null)
            {
                depositTodelete.Pictures.ForEach(x => _uploadService.Remove(x));
                _context.Deposits.Remove(depositTodelete);
                _context.SaveChanges();
            }
            return new Result();
        }
    }
}
