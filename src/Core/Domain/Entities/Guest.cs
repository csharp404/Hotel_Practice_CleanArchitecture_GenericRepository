using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Guest
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string PhoneNumber {set; get;}
        public string Email {set; get; }
        public string PassportNumber {set; get; }
        public bool IsPimp {set; get; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
