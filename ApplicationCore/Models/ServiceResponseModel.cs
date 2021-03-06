using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class ServiceResponseModel
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public string SDesc { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? ServiceDate { get; set; }
        public Room Rooms { get; set; }
    }
}
