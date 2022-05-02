namespace TikiBar.Models
{
    public class Drink
    {
        private string? list;

        public int Id { get; set; }
        public string Name { get; set; }
        public  List<string> Ingredients { get; set; }
    }
}
