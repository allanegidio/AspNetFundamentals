namespace Books.EF.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Genre Category { get; set; }
    }
}