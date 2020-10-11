using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.API.Service.Reservation.Data.Models;
using Crm.API.Service.Reservation.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crm.API.Service.Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService ReservationService)
        {
            reservationService = ReservationService;
        }


        [HttpGet()]
        public Reservations Get()
        {
            return reservationService.GetFirstReservation();
        }

        [HttpGet("{id}")]
        public Reservations Get(int id)
        {
            return reservationService.GetReservationById(id);
        }

        [HttpGet()]
        public Reservations GetByResNumber(String ResNumber)
        {
            return reservationService.GetReservationByResNumber(ResNumber);
        }
    }
}
