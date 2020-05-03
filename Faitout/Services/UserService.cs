using Faitout.Data;
using Faitout.Data.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Faitout.Services
{
    public interface IUserService
    {

    }
    public class UserService : BaseService,  IUserService
    {

        public UserService(ApplicationDbContext context): base(context)
        {
        }
    }
}
