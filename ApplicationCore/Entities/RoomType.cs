using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class RoomType
    {
        public int Id { get; set; }
        [Column("RTDESC", TypeName = "varchar(20)")]     // Set type of varchar with length of 20 for database with length of 20
        public string RTDesc { get; set; }
        [Column(TypeName = "money")]    // Set the type as money for database
        public decimal? Rent { get; set; }
    }
}
