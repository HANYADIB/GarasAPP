using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.DTOs
{
    public class GuestProfileDto
    {
        public long? Id { get; set; }
        public long? ClientId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Email { get; set; }
        public int? NationalityId { get; set; }
        public long CreatedBy { get; set; } = 1;
        public DateTime CreationDate { get; set; }= DateTime.Now;
        public long SalesPersonId { get; set; } = 1;
        public DateTime? FirstContractDate { get; set; }=DateTime.Now;
        public int FollowUpPeriod { get; set; } = 4;
        public List<int> languageeId { get; set; }
        public List<AddressDto>? addressDtos { get; set; }

    }
}
