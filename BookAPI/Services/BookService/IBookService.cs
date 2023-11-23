namespace BookAPI.Services.BookService
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();

        Task<Book?> GetBookById(int id);

        Task<List<Book>> AddBook(Book book);

        Task<List<Book>?> UpdateBook(int id, Book request);

        Task<List<Book>?> DeleteBook(int id);
    }
}
