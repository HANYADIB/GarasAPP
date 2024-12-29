using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Validators
{
    public class IsAfterStartDate : ValidationAttribute
    {
        private readonly DateTime _startDate;
        public IsAfterStartDate(DateTime startDate) 
        {
            _startDate = startDate;
        }

        public override bool IsValid(object? value)
            => value is DateTime startDate && startDate > _startDate;
    }
}
