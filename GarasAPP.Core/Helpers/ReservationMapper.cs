using GarasAPP.Core.DTOs;
using GarasAPP.Core.Models;
using GarasAPP.Core.Models.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Helpers
{
    public static class ReservationMapper
    {
        public static ReservationGridDto ToReservationGridDto(this Reservation commentModel)
        {
            return new ReservationGridDto
            {
                Id = commentModel.Id,
                reservationDate = commentModel.reservationDate,
                ToDate = commentModel.ToDate,
                FromDate = commentModel.FromDate,
                ClientId = commentModel.ClientId,
                Provider = commentModel.Provider,
                Confirmation = commentModel.Confirmation,
                ClientName = commentModel.Clients.Name

            };
        }
    }
}
