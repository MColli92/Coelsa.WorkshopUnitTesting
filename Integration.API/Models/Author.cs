using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration.API.Models
{
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;  }
        
        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required, StringLength(25)]
        public string Surname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}