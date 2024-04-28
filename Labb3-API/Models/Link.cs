using System.ComponentModel.DataAnnotations;

namespace Labb3_API.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public string Url { get; set; }
        public int PersonInterestId { get; set; }
        public PersonInterest PersonInterest { get; set; }
    }
}
