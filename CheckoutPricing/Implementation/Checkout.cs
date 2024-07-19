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
        public decimal GetTotalPrice()
        {
            List<Product> products = _products.Distinct().ToList();
            decimal totalPrice = 0;

            foreach (Product product in products)
            {
                if (_discountRules.Exists(x => x.SKU == product.SKU))
                {
                    var discountRule = _discountRules.First(x => x.SKU == product.SKU);
                    int noOfProduct = _products.Count(x => x.SKU.Equals(product.SKU));

                    var noOfDiscounts = noOfProduct / discountRule.Quantity;
                    var remainder = noOfProduct % discountRule.Quantity;

                    totalPrice = discountRule.DiscountPrice * noOfDiscounts;
                    totalPrice += remainder;
                }
                else
                {
                    totalPrice = product.Price * _products.Count(x => x.SKU.Equals(product.SKU));
                }
            }

            return totalPrice;
        }
    }
}
