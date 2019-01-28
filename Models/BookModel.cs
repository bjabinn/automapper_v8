using System;
namespace automapper
{
    public class BookModel
    {
        public int Id { get; set; }
        public string FullTitle { get; set; }
        public int Pages { get; set; }
        public int Edition { get; set; }
        public string AuthorName { get; set; }
        public DateTime TimeSent { get; set; }
    }
}
