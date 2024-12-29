using GarasAPP.Core.Helpers;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models.HotelModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.EntityFrameworkCore.Repositories.Hotel
{
    public class FacilityRepository : BaseRepository<Facility, int>, IFacilityRepository
    {
        protected ApplicationDbContext _context;
        public FacilityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
