using System;
using System.Collections.Generic;

namespace Crm.API.Service.Reservation.Data.Models
{
    public partial class Reservations
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ResNumber { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int? ContactId { get; set; }
    }
}
