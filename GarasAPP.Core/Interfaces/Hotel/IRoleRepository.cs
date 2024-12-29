﻿using GarasAPP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Interfaces.Hotel
{
    public interface IRoleRepository : IBaseRepository<Role, long>
    {
        bool HasRole(string role, string id);
    }
}
