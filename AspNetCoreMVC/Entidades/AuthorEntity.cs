
using System.Collections.Generic;

namespace AspNetCoreMVC
{
    public class AuthorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<BookEntity> Books { get; set; }
    }
}
