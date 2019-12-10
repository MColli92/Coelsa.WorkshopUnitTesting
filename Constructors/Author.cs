using System;
using System.Collections.Generic;
using System.Linq;

namespace Constructors
{
    public class Author
    {
        public string Name { get; }
        public string Surname { get; }
        public DateTime DateOfBirth { get; }
        private List<Book> _books;
        public IReadOnlyCollection<Book> Books => _books;

        public Author(string name, string surname, DateTime dateOfBirth)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "Name cannot be null");
            if (surname == null) throw new ArgumentNullException(nameof(surname), "Surname cannot be null");

            if (dateOfBirth == DateTime.MinValue) throw new ArgumentException($"DateOfBirth cannot be equal to {DateTime.MinValue:dd/MM/yyyy}", nameof(dateOfBirth));

            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }

        public Author(string name, string surname, DateTime dateOfBirth, IEnumerable<Book> books) : this(name, surname, dateOfBirth)
        {
            if (books == null) throw new ArgumentNullException(nameof(books), "Books cannot be null");
            if (!books.Any()) throw new ArgumentException("Books collection cannot be empty", nameof(books));

            _books = books.ToList();
        }
    }
}