using System.Collections.Generic;

namespace Flight.Entities.Entities
{
    public class Customer : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<CreditCard> CreditCards { get; set; } = new HashSet<CreditCard>();
    }
}
