using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Validators
{
    public class FeatureDate : ValidationAttribute
    {
        public override bool IsValid(object? value)
            => value is DateTime startDate && startDate >= DateTime.Today;
    }
}
