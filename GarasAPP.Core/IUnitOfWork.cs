using GarasAPP.Core.Interfaces;
using GarasAPP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<User, long> Users { get; }

        int Complete();
    }
}
