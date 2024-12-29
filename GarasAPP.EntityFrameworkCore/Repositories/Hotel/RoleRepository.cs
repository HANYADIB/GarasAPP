using GarasAPP.Core.Helpers;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models;
using GarasAPP.Core.Models.HotelModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.EntityFrameworkCore.Repositories.Hotel
{
    public class RoleRepository : BaseRepository<Role, long>, IRoleRepository
    {
        protected ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context, IOptions<JWT> jwt, IHostingEnvironment Environment, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _context = context;
        }

        public bool HasRole(string role, string id)
        {
            long.TryParse(id, out long uId);
            var userRoles = _context.UserRoles.Where(x => x.UserId == uId);
            var userRoleId = _context.Roles.FirstOrDefault(x => x.Name.Equals(role)).Id;
            if(userRoles.Any(x => x.RoleId == userRoleId)) 
            {
                return true;
            }
            return false;
        }
    }
}
