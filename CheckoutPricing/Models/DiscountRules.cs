namespace CheckoutPricing.Models
{
    public class DiscountRule
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountPrice { get; set; }
    }
}
