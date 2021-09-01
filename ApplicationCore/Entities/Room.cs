using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Room
    {
        public int Id { get; set; }
        [Column("RTCODE")]
        public int? RoomTypeId { get; set; }
        [Column("STATUS")]
        public bool? Status { get; set; }
        public RoomType RoomTypes { get; set; }
        public ICollection<ServiceResponseModel> Services { get; set; }
    }
}
