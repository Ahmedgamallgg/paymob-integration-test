namespace paymob_integration.Models
{
    public class Product 
    {


        public int Id { get; set; }
        public string name { get; set; }

        public string description { get; set; }
        public int quantity { get; set; }
        public decimal amount { get; set; }

    }

}
