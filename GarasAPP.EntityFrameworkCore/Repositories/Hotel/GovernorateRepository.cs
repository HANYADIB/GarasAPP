using AutoMapper;
using GarasAPP.Core.Interfaces;
using GarasAPP.Core.Models;
using GarasAPP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarasAPP.Core.Interfaces.Hotel;

namespace GarasAPP.EntityFrameworkCore.Repositories.Hotel
{
    public class GovernorateRepository : BaseRepository<Governorate, int>, IGovernorateRepository
    {
        protected ApplicationDbContext _context;
        public GovernorateRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    
    }
}
