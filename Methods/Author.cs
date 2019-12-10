using System;
using System.Collections.Generic;
using System.Linq;

namespace Methods
{
    public class Author
    {
        public string Name { get; }
        public string Surname { get; }
        public DateTime DateOfBirth { get; }

        private List<Book> _books;
        public IReadOnlyCollection<Book> Books => _books;

        private Author(string name, string surname, DateTime dateOfBirth)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "Name cannot be null");
            if (surname == null) throw new ArgumentNullException(nameof(surname), "Surname cannot be null");

            if (dateOfBirth == DateTime.MinValue)
                throw new ArgumentException($"DateOfBirth cannot be equal to {DateTime.MinValue:dd/MM/yyyy}",
                    nameof(dateOfBirth));

            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }

        public Author(string name, string surname, DateTime dateOfBirth, IEnumerable<Book> books) : this(name, surname,
            dateOfBirth)
        {
            if (books == null) throw new ArgumentNullException(nameof(books), "Books cannot be null");
            _books = books.ToList();
        }

        public IReadOnlyCollection<Book> GetBooksByYear(int year) => _books.Where(p => p.Year == year).ToList();

        public IReadOnlyCollection<Book> GetAllBooks() => _books.ToList();

        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book), "Book cannot be null");
            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book), "Book cannot be null");
            if (_books.Contains(book)) _books.Remove(book);
        }
    }
}