using System.Collections.Generic;

namespace GMS.Domain.Entities
{
    public class Friend : EntityBase
    {
        public string Fullname { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public int? Number { get; set; }
        public string Neighborhood { get; set; }
        public string AddressComplement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string SocialNetwork { get; set; }
        public List<Game> Loans { get; set; } 
    }
}
