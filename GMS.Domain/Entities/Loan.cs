using System;

namespace GMS.Domain.Entities
{
    public class Loan : EntityBase
    {
        public int FriendId { get; set; }
        public int GameId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public Friend Friend { get; set; }
        public Game Game { get; set; }
    }
}
