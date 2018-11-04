using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookService.Models
{
    /// <summary>
    /// Author
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Id of Author
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of Author
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}