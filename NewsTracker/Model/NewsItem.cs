namespace NewsTracker.Model
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } // لإظهار اسم الفئة
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
