using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.ViewModels
{
    public class BaseResponse
    {
        public bool Result { get; set; }
        public List<Error> Errors { get; set; }
    }

    public class Error
    {
        public string code { get; set; }
        public string message { get; set; }
    }
}
