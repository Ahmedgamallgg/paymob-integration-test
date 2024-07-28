namespace paymob_integration.Models
{
    public class PaymobDto
    {
        public ICollection<Product> items { get; set; }
        private decimal amount { get; set; } 
        public Customer Customer { get; set; }

        public decimal GetAmount()
        {
            return this.items.Sum(x => x.amount * x.quantity);
        }
    }





}
