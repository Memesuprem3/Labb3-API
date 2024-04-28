using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_API.Models
{
    public class PersonInterest
    {
        [Key]
        public int PersonInterestId { get; set; }
        public int PersonId { get; set; }
        public int InterestId { get; set; }
        public Person Person { get; set; }
        public Interest Interest { get; set; }
        public List<Link> Links { get; set; } = new List<Link>();
    }
}