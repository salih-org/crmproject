using Crm.API.Service.Reservation.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.API.Service.Reservation.Service.Interfaces
{
    public interface IReservationService
    {
        Reservations GetFirstReservation();

        Reservations GetReservationById(int Id);

        Reservations GetReservationByResNumber(String ResNumber);

    }
}
