using System.ComponentModel.DataAnnotations;


namespace BookService.Models
{
    /// <summary>
    /// Book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Id of Book
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Title of Book
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Year of Book
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Price of Book
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Genre of Book
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Foreign Key (AuthorId) of Book
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Navigation propery of Author
        /// </summary>
        public Author Author { get; set; }    // Standard
        //public virtual Author Author { get; set; }  // Lazy Loading => enable virtual

    }
}