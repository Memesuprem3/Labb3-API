using System.ComponentModel.DataAnnotations;

namespace Labb3_API.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<PersonInterest> PersonInterests { get; set; } = new List<PersonInterest>();
    }
}