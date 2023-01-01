namespace ARTICLE.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string DecriptionofBook { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
