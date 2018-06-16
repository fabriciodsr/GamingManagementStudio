using GMS.Domain.Enums;

namespace GMS.Domain.Entities
{
    public class Game : EntityBase
    {
        public string Name { get; set; }
        public Genre? Genre { get; set; }
        public Platform? Platform {get; set;}
        public string Image { get; set; }
        public string Developer { get; set; }
        public bool Unavailable { get; set; }
        public int? FriendId { get; set; }
        public Friend Friend { get; set; }
    }
}
