using System;

namespace Flight.Core.Dtos
{
    public class OrderForCreateDto
    {
        public string CusotmerName { get; set; }
        public int CountryId { get; set; }
        public DateTime Departure { get; set; }
        public int NumberOfPersons { get; set; }
        public bool IsTransit { get; set; }
        public int CreditCardNumber { get; set; }
        public string CreditCardHolderName { get; set; }
    }
}
