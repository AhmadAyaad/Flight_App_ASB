using System;

namespace Flight.Entities.Entities
{
    public class CreditCard : BaseEntity
    {
        public int CreditCardId { get; set; }
        public string HolderName { get; set; }
        public int CreditCardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public Customer Customer { get; set; }
    }
}
