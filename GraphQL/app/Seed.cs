using app.Database;
using app.Models;

namespace app {
    public static class Seed {
        public static void SeedDatabase () {
            using (var db = new StoreContext ()) {
                var authorDbEntry = db.Authors.Add (
                    new Author {
                        Id = 1,
                        Name = "Stephen King",
                    }
                );

                db.SaveChanges ();

                db.Books.AddRange (
                    new Book {
                        Id = "1",
                        Name = "IT",
                            Published = true,
                            AuthorId = authorDbEntry.Entity.Id,
                            Genre = "Mystery"
                    },
                    new Book {
                        Id = "2",
                        Name = "The Langoleers",
                            Published = true,
                            AuthorId = authorDbEntry.Entity.Id,
                            Genre = "Mystery"
                    }
                );

                db.SaveChanges ();
            }
        }
    }
}