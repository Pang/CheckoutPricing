using CheckoutPricing.Models;

namespace CheckoutPricing.Interfaces
{
    public interface ICheckout
    {
        void AddDiscountRule(string sku, int quantity, decimal discountPrice);
        void Scan(Product product);
    }
}
