using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.EntityFrameworkCore.Repositories.Hotel
{
    public class AddressRepository : BaseRepository<ClientAddress,long>, IAddressRepository
    {
        protected ApplicationDbContext _context;
        public AddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
