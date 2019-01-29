
using System.Collections.Generic;

namespace automapper
{
    public class AuthorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<BookEntity> Books { get; set; }
    }
}
