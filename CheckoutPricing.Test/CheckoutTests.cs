using CheckoutPricing.Implementation;
using CheckoutPricing.Models;
using CheckoutPricing.Test.Helpers;

namespace CheckoutPricing.Test
{
    public class Tests
    {
        [Test]
        public void TestSingleProduct()
        {
            Checkout checkout = new Checkout();

            // Add some products
            var testProducts = ProductsListHelper.GetTestProducts();
            decimal discountPrice = 2;

            // Add some discount rules
            checkout.AddDiscountRule("1", 3, discountPrice);
            
            // Scan some products
            Product productOne = testProducts.First(x => x.SKU == "1");

            checkout.Scan(productOne);
            checkout.Scan(productOne);
            checkout.Scan(productOne);

            // Check total costs
            decimal totalPrice = checkout.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(discountPrice));
        }
    }
}