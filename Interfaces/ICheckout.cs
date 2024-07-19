using CheckoutPricing.Models;

namespace CheckoutPricing.Interfaces
{
    public interface ICheckout
    {
        /// <summary>
        /// Adds a discount rule for total price.
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="quantity"></param>
        /// <param name="discountPrice"></param>
        void AddDiscountRule(string sku, int quantity, decimal discountPrice);

        /// <summary>
        /// Scans an item into customer basket.
        /// </summary>
        /// <param name="product"></param>
        void Scan(Product product);

        /// <summary>
        /// Get the total price of all products including discounts.
        /// </summary>
        /// <returns></returns>
        int GetTotalPrice();
    }
}
