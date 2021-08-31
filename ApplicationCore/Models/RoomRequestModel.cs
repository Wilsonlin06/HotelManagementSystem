using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class RoomRequestModel
    {
        public int RoomNo { get; set; }
        public int? RTCode { get; set; }
        public bool? Status { get; set; }
        public RoomType RoomTypes { get; set; }
    }
}
