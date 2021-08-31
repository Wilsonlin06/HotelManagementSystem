using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class _Service
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("ROOMNO")]
        public int? RoomId { get; set; }
        [Column("SDESC", TypeName = "varchar(50)")]     // Set type of varchar with length of 20 for database with length of 50
        public string SDesc { get; set; }
        [Column("AMOUNT", TypeName = "money")]    // Set the type as money for database
        public decimal? Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ServiceDate { get; set; }
        public Room Rooms { get; set; }
    }
}
