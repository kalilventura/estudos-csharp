using app.Database;
using app.Models;
using GraphQL;

namespace app.GraphQL {
    [GraphQLMetadata ("Mutation")]
    public class Mutation {
        private StoreContext _context;

        public Mutation (StoreContext context) {
            _context = context;
        }

        [GraphQLMetadata ("addAuthor")]
        public Author Add (string name) {
            var author = new Author { Name = name };
            _context.Authors.Add (author);
            _context.SaveChanges ();
            return author;
        }
    }
}