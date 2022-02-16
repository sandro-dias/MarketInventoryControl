namespace Application.UseCases.ValidateProduct.Input
{
    public class ValidateProductInput
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
