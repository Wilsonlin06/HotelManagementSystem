using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class RoomTypeResponseModel
    {
        public int Id { get; set; }
        public string RTDesc { get; set; }
        public decimal? Rent { get; set; }
    }
}
