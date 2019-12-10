namespace Methods
{
    public class Book
    {
        public string Title { get; }
        public string Description { get; }
        public int Year { get; }

        public Book(string title, string description, int year)
        {
            Title = title;
            Description = description;
            Year = year;
        }
    }
}