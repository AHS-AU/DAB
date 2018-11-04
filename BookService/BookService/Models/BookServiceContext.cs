using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookService.Models
{
    public class BookServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        /// <summary>
        /// BookServiceContext
        /// </summary>
        public BookServiceContext() : base("name=BookServiceContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        /// <summary>
        /// Authors
        /// </summary>
        public System.Data.Entity.DbSet<BookService.Models.Author> Authors { get; set; }

        /// <summary>
        /// Books
        /// </summary>
        public System.Data.Entity.DbSet<BookService.Models.Book> Books { get; set; }
    }
}
