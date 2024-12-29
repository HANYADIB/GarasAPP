using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models;
using GarasAPP.Core.Models.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.EntityFrameworkCore.Repositories.Hotel
{
    public class NationalityRepository : BaseRepository<Nationality, int>, INationalityRepository
    {
        protected ApplicationDbContext _context;
        public NationalityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
