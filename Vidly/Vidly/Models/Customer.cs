using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        // ovo je navigation property jel nam dozvoljava da idemo od jednog type-a do drugog
        // navigation property su korisni kada zelimo loadati objekt i njegov povezani objekt iz baze
        public MembershipType MembershipType { get; set; }

        // EF zna da je ovo FOREIGN KEY
        public byte MembershipTypeId { get; set; }

        // sta ce nam se pokazivat u viewu za ovaj atribut
        // koristiti ovo i helper metode
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

    }
}