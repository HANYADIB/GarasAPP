using GarasAPP.Core.Interfaces;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.EntityFrameworkCore.Repositories.Hotel
{
    public class RoomTypeRepository : BaseRepository<RoomType, int>, IRoomTypeRepository
    {
        protected ApplicationDbContext _context;
        public RoomTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
