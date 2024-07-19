using CheckoutPricing.Models;

namespace CheckoutPricing.Test.Helpers
{
    static class ProductsListHelper
    {
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
    }
}
