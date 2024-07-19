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

            var testProducts = ProductsListHelper.GetTestProducts();
            decimal discountPrice = 2;
            int quantity = 3;

            checkout.AddDiscountRule("1", quantity, discountPrice);
            
            Product productOne = testProducts.First(x => x.SKU == "1");

            for (int i = 0; i < quantity; i++)
            {
                checkout.Scan(productOne);
            }

            decimal totalPrice = checkout.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(discountPrice));
        }

        [Test]
        public void TestMultipleDiscountedProductsIsNotFullPrice()
        {
            Checkout checkout = new Checkout();

            var testProducts = ProductsListHelper.GetTestProducts();
            int quantityOfEach = 5;

            foreach(DiscountRule rule in ProductsListHelper.GetDiscountRules())
            {
                checkout.AddDiscountRule(rule.SKU, rule.Quantity, rule.DiscountPrice);
            }

            foreach(var testProduct in testProducts)
            {
                for(int i = 0; i < quantityOfEach; i++)
                {
                    checkout.Scan(testProduct);
                }
            }

            decimal sumOfTestProducts = testProducts.Sum(x => x.Price);
            decimal totalPrice = checkout.GetTotalPrice();

            Assert.That(totalPrice, Is.Not.EqualTo(sumOfTestProducts));
        }
    }
}