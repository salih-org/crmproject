using Crm.API.Service.Reservation.Data.Context;
using Crm.API.Service.Reservation.Data.Models;
using Crm.API.Service.Reservation.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crm.API.Service.Reservation.Service.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ReservationDbContext context;

        public ReservationService(ReservationDbContext Context)
        {
            context = Context;
        }

        public Reservations GetFirstReservation()
        {
            return context.Reservations.FirstOrDefault();
        }

        public Reservations GetReservationById(int Id)
        {
            return context.Reservations.FirstOrDefault(i => i.Id == Id);
        }

        public Reservations GetReservationByResNumber(string ResNumber)
        {
            return context.Reservations.FirstOrDefault(i => i.ResNumber == ResNumber);
        }
    }
}
