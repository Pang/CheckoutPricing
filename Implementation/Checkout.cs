using CheckoutPricing.Interfaces;
using CheckoutPricing.Models;

namespace CheckoutPricing.Implementation
{
    public class Checkout : ICheckout
    {
        private readonly List<Product> _products = new List<Product>();
        private readonly List<DiscountRule> _discountRules = new List<DiscountRule>();

        /// <inheritdoc />
        public void AddDiscountRule(string sku, int quantity, decimal discountPrice)
        {
            DiscountRule newRule = new DiscountRule { SKU = sku, Quantity = quantity, DiscountPrice = discountPrice };
            _discountRules.Add(newRule);
        }

        /// <inheritdoc />
        public void Scan(Product product)
        {
            _products.Add(product);
        }

        /// <inheritdoc />
        public int GetTotalPrice()
        {
            return 0;
        }
    }
}
