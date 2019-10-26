using System.Collections.Generic;
using System.Linq;
using app.Database;
using app.Models;
using GraphQL;
using Microsoft.EntityFrameworkCore;

namespace app.GraphQL {
    public class Query {
        private StoreContext _context;

        public Query (StoreContext context) {
            _context = context;
        }

        [GraphQLMetadata ("books")]
        public IEnumerable<Book> GetBooks () {
            return _context.Books.Include (book => book.Author).ToList ();
        }

        [GraphQLMetadata ("authors")]
        public IEnumerable<Author> GetAuthors () {
            return _context.Authors.Include (author => author.Books).ToList ();
        }

        [GraphQLMetadata ("author")]
        public Author GetAuthor (int id) {
            return _context.Authors.Include(author => author.Books).SingleOrDefault(author => author.Id == id);
        }

        [GraphQLMetadata ("hello")]
        public string GetHello () {
            return "World";

        }
    }
}