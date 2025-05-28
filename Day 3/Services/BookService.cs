using Book_Management.Models;

namespace Book_Management.Services
{
    public class BookService
    {
        private List<Book> books;

        public BookService()
        {
            books = new List<Book>();
            books.Add(new Book()
            {
                Id = 1,
                Title = "Test1",
                Author = "James Bond",
                Genre = "Fiction"
            });
            books.Add(new Book()
            {
                Id = 2,
                Title = "Test2",
                Author = "Ruskin Bond",
                Genre = "Non fiction"
            });
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            Book book = books.FirstOrDefault(book => book.Id == id);
            if(book == null)
            {
                return null;
            }
            return book;
        }

        public void AddBook(Book book)
        {
            book.Id = books.Count + 1;
            books.Add(book);
        }

        public int UpdateBook(Book book)
        {
            Book bookToBeUpdated = GetBookById(book.Id);
            if(bookToBeUpdated == null)
            {
                return -1;
            }
            else
            {
                bookToBeUpdated.Title = book.Title;
                bookToBeUpdated.Author = book.Author;
                bookToBeUpdated.Genre = book.Genre;
                return 1;
            }
        }

        public int DeleteBook(int id)
        {
            Book bookToBeRemoved = GetBookById(id);
            if( bookToBeRemoved == null)
            {
                return -1;
            }
            else
            {
                books.Remove(bookToBeRemoved);
                return 1;
            }
        }
    }
}
