using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [Column("ROOMNO")]
        public int? RoomId { get; set; }
        [Column("CNAME", TypeName = "varchar(20)")]     // Set type of varchar with length of 20 for database with length of 20
        public string CName { get; set; }
        [Column("ADDRESS", TypeName = "varchar(100)")]     // Set type of varchar with length of 20 for database with length of 100
        public string Address { get; set; }
        [Column("PHONE", TypeName = "varchar(20)")]     // Set type of varchar with length of 20 for database with length of 20
        public string Phone { get; set; }
        [Column("EMAIL", TypeName = "varchar(40)")]     // Set type of varchar with length of 20 for database with length of 40
        public string Email { get; set; }
        [Column("CHECKIN", TypeName = "datetime")]
        public DateTime? CheckIn { get; set; }
        public int? TotlePERSONS { get; set; }
        public int? BookingDays { get; set; }
        [Column("ADVANCE", TypeName = "money")]    // Set the type as money for database
        public decimal? Advance { get; set; }
        public Room Rooms { get; set; }
    }
}
