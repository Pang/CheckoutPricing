using CheckoutPricing.Models;

namespace CheckoutPricing.Test.Helpers
{
    static class ProductsListHelper
    {
        /// <summary>
        /// Get a predefined list of Products.
        /// </summary>
        /// <returns>List of test products.</returns>
        public static List<Product> GetTestProducts()
        {
            List<Product> testProducts = new List<Product>();

            testProducts.Add(new Product
            {
                SKU = "1",
                Price = (Decimal)1.00,
            });

            testProducts.Add(new Product
            {
                SKU = "2",
                Price = (Decimal)6.00,
            });

            testProducts.Add(new Product
            {
                SKU = "3",
                Price = (Decimal)3.50,
            });

            testProducts.Add(new Product
            {
                SKU = "4",
                Price = (Decimal)12.99,
            });

            testProducts.Add(new Product
            {
                SKU = "5",
                Price = (Decimal)7.90,
            });

            return testProducts;
        }

        /// <summary>
        /// Get a predefined list of type DiscountRules.
        /// </summary>
        /// <returns>List of discount rules.</returns>
        public static List<DiscountRule> GetDiscountRules()
        {
            List<DiscountRule> discountRules = new List<DiscountRule>();

            discountRules.Add(new DiscountRule() 
            { 
                SKU = "1", 
                Quantity = 3,
                DiscountPrice = 2 
            });

            discountRules.Add(new DiscountRule()
            {
                SKU = "2",
                Quantity = 4,
                DiscountPrice = 18
            });

            discountRules.Add(new DiscountRule()
            {
                SKU = "3",
                Quantity = 2,
                DiscountPrice = 5
            });

            discountRules.Add(new DiscountRule()
            {
                SKU = "4",
                Quantity = 2,
                DiscountPrice = 20
            });

            discountRules.Add(new DiscountRule()
            {
                SKU = "5",
                Quantity = 3,
                DiscountPrice = 17.50m
            });

            return discountRules;
        }
    }
}
