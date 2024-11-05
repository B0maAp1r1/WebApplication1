namespace WebApplication1.Models
{
    public class DealsFromDBs
    {
        public int Id { get; set; }
        public string? PizzaDescription { get; set; }
        public int PizzaSize { get; set; }
        public string? PizzaBase { get; set; }
        public string? PizzaCrust { get; set; }
        public decimal Price { get; set; }
    }
}
