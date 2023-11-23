using BookAPI.Data;
using BookAPI.Services.BookService;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Services.BookService
{
    public class BookService : IBookService
    {
        //private static List<Book> books = new List<Book>
        //{
        //    new Book { Id = 1, Title = "Life of Pi", ISBN = "", Description = "", Author = "Yann Martel", Publisher = "", Genre = "" },
        //    new Book { Id = 2, Title = "Madre", ISBN = "9786022911036", Description = "", Author = "Dee Lestari", Publisher = "Bentang Pustaka", Genre = "Sastra" },
        //    new Book { Id = 3, Title = "Kepingan Supernova", ISBN = "9786022912712", Description = "", Author = "Dee Lestari", Publisher = "Bentang Pustaka", Genre = "Sastra" },
        //    new Book { Id = 4, Title = "Totto-chan: Gadis Cilik di Jendela", ISBN = "", Description = "", Author = "Tetsuko Kuroyanagi", Publisher = "Gramedia", Genre = "Sastra" },
        //    new Book { Id = 5, Title = "Perahu Kertas", ISBN = "9789791227780", Description = "", Author = "Dee Lestari", Publisher = "Bentang Pustaka", Genre = "Sastra" },
        //    new Book { Id = 6, Title = "Mata Yang Enak Dipandang", ISBN = "9786020300597", Description = "", Author = "Ahmad Tohari", Publisher = "Gramedia", Genre = "Sastra" },
        //    new Book { Id = 7, Title = "Kubah", ISBN = "9789792287745", Description = "", Author = "Ahmad Tohari", Publisher = "Gramedia", Genre = "Sastra" },
        //    new Book { Id = 8, Title = "Di Kaki Bukit Cibalak", ISBN = "9786020305134", Description = "", Author = "Ahmad Tohari", Publisher = "Gramedia", Genre = "Sastra" },
        //    new Book { Id = 9, Title = "Senyum Karyamin", ISBN = "9789792297362", Description = "", Author = "Ahmad Tohari", Publisher = "Gramedia", Genre = "Sastra" },
        //    new Book { Id = 10, Title = "Bekisar Merah", ISBN = "9789792266320", Description = "", Author = "Ahmad Tohari", Publisher = "Gramedia", Genre = "Sastra" },
        //    new Book { Id = 11, Title = "Lingkar Tanah Lingkar Air", ISBN = "9786020318608", Description = "", Author = "Ahmad Tohari", Publisher = "Gramedia", Genre = "Sastra" },
        //    new Book { Id = 12, Title = "Orang-Orang Proyek", ISBN = "9786020320595", Description = "", Author = "Ahmad Tohari", Publisher = "Gramedia", Genre = "Sastra" },
        //    new Book { Id = 13, Title = "Menjadi Manusia Rohani", ISBN = "9786025363429", Description = "", Author = "Ulil Abshar Abdalla", Publisher = "Alifbook", Genre = "Agama Islam" },
        //    new Book { Id = 14, Title = "Jika Tuhan Mahakuasa, Kenapa Manusia Menderita?", ISBN = "9786237284376", Description = "", Author = "Ulil Abshar Abdalla", Publisher = "Buku Mojok", Genre = "Agama Islam" },
        //    new Book { Id = 15, Title = "Supernova: Gelombang", ISBN = "9786022911715", Description = "", Author = "Dee Lestari", Publisher = "Penerbit Bentang", Genre = "Sastra" }
        //};

        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> AddBook(Book book)
        {
            //books.Add(book);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            
            return await _context.Books.ToListAsync();
        }

        public async Task<List<Book>?> DeleteBook(int id)
        {
            //var book = books.Find(b => b.Id == id);
            var book = await _context.Books.FindAsync(id);

            if (book is null)
            {
                return null;
            }

            //books.Remove(book);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();

            return books;
        }

        public async Task<Book?> GetBookById(int id)
        {
            //var book = books.Find(x => x.Id == id);
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return null;                
            
            return book;
        }

        public async Task<List<Book>?> UpdateBook(int id, Book request)
        {
            //var book = books.Find(b => b.Id == id);
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return null;
                        
            book.Title = request.Title;
            book.ISBN = request.ISBN;
            book.Description = request.Description;
            book.Author = request.Author;
            book.Publisher = request.Publisher;
            book.Genre = request.Genre;

            await _context.SaveChangesAsync();

            //return books;
            return await _context.Books.ToListAsync();
        }
    }
}
