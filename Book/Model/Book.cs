using System.ComponentModel.DataAnnotations;

namespace Book.Model
{
    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }   
        
        public int AvailableCopies { get; set; }

        public int  TotalCopies { get; set; }

    }
}
