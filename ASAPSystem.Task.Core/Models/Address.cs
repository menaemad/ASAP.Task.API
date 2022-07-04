using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASAPSystem.Assignment.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Description { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime CreatedOn { get; set; }

        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }
    }
}
