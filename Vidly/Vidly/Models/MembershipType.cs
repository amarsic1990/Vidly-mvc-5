using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    // svaki kupac moze imati samo 1 MEMBERSHIP TYPE
    // radit male migracije
    // svaki entitet mora imati kljuc
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}