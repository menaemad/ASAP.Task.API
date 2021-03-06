using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASAPSystem.Assignment.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedOn { get; set; }

        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }
    }
}
