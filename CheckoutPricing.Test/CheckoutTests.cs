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
            List<Product> testProducts = ProductsListHelper.GetTestProducts();

            Product product = testProducts.First(x => x.SKU == "2");
            checkout.Scan(product);

            decimal totalPrice = checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(product.Price));
        }

        [Test]
        public void TestMultipleNonDiscountedProducts()
        {
            Checkout checkout = new Checkout();
            List<Product> testProducts = ProductsListHelper.GetTestProducts();

            foreach (Product testProduct in testProducts)
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

            List<Product> testProducts = ProductsListHelper.GetTestProducts();
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
        public void TestMultipleDiscountedProducts()
        {
            Checkout checkout = new Checkout();

            List<Product> testProducts = ProductsListHelper.GetTestProducts();

            List<DiscountRule> rules = ProductsListHelper.GetDiscountRules();
            foreach (DiscountRule rule in rules)
            {
                checkout.AddDiscountRule(rule.SKU, rule.Quantity, rule.DiscountPrice);
            }

            Product productOne = testProducts.First(p => p.SKU == "1");
            DiscountRule ruleOne = rules.First(x => x.SKU == productOne.SKU);

            for (int i = 0; i < ruleOne.Quantity; i++)
            {
                checkout.Scan(productOne);
            }

            Product productTwo = testProducts.First(p => p.SKU == "2");
            DiscountRule ruleTwo = rules.First(x => x.SKU == productTwo.SKU);

            for (int i = 0; i < ruleTwo.Quantity; i++)
            {
                checkout.Scan(productTwo);
            }

            decimal sumOfDiscountedProducts = ruleOne.DiscountPrice + ruleTwo.DiscountPrice;
            decimal totalPrice = checkout.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(sumOfDiscountedProducts));
        }

        [Test]
        public void TestMultipleDiscountedProductsIsNotFullPrice()
        {
            Checkout checkout = new Checkout();

            List<Product> testProducts = ProductsListHelper.GetTestProducts();
            int quantityOfEach = 5;

            foreach(DiscountRule rule in ProductsListHelper.GetDiscountRules())
            {
                checkout.AddDiscountRule(rule.SKU, rule.Quantity, rule.DiscountPrice);
            }

            foreach(Product testProduct in testProducts)
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

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void TestProductsOverDiscountLimit(string sku)
        {
            Checkout checkout = new Checkout();

            List<Product> testProducts = ProductsListHelper.GetTestProducts();

            List<DiscountRule> rules = ProductsListHelper.GetDiscountRules();
            foreach (DiscountRule rule in rules)
            {
                checkout.AddDiscountRule(rule.SKU, rule.Quantity, rule.DiscountPrice);
            }

            Product product = testProducts.First(p => p.SKU == sku);
            DiscountRule discountRule = rules.First(x => x.SKU == sku);

            for (int i = 0; i < discountRule.Quantity + 1; i++)
            {
                checkout.Scan(product);
            }

            decimal sumOfAllProducts = discountRule.DiscountPrice + product.Price;
            decimal totalPrice = checkout.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(sumOfAllProducts));
        }
    }
}