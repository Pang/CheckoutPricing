using CheckoutPricing.Implementation;
using CheckoutPricing.Models;
using CheckoutPricing.Test.Helpers;

namespace CheckoutPricing.Test
{
    public class Tests
    { 

        [Test]
        public void TestSingleNonDiscountedProduct()
        {
            Checkout checkout = new Checkout();
            var testProducts = ProductsListHelper.GetTestProducts();

            Product product = testProducts.First(x => x.SKU == "2");
            checkout.Scan(product);

            decimal totalPrice = checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(product.Price));
        }

        [Test]
        public void TestMultipleNonDiscountedProducts()
        {
            Checkout checkout = new Checkout();
            var testProducts = ProductsListHelper.GetTestProducts();

            foreach (var testProduct in testProducts)
            {
                checkout.Scan(testProduct);
            }

            decimal totalPrice = checkout.GetTotalPrice();
            decimal sumOfTestProducts = testProducts.Sum(x => x.Price);
            Assert.That(totalPrice, Is.EqualTo(sumOfTestProducts));
        }

        [Test]
        public void TestSingleDiscountedProduct()
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