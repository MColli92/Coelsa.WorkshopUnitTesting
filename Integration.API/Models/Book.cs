using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration.API.Models
{
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AuthorId { get; set; }
        
        [Required, StringLength(25)]
        public string Title { get; set; }
        [Required, StringLength(100)]
        public string Description { get; set; }
        [Required]
        public int Year { get; set; }

        public Author Author { get; set; }
    }
}