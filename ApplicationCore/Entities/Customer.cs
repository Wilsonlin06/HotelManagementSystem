using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public int Roomno { get; set; }
        public string CName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CheckIn { get; set; }
        public int TotlePersons { get; set; }
        public int BookingDays { get; set; }
        public string Advance { get; set; } // money type
    }
}
