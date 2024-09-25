using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySqlContext _context;

        public BookRepositoryImplementation(MySqlContext context) 
        { 
            _context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
                
            }
            catch (Exception)
            {

                throw;
            }
            return book;
        }
        public void Delete(long id)
        {
            try
            {
                // Tenta encontrar a pessoa com o ID especificado
                var book = _context.Books.FirstOrDefault(p => p.Id == id);

                if (book != null)
                {
                    // Remove a pessoa encontrada
                    _context.Books.Remove(book);

                    // Salva as mudanças no banco de dados
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Book> FindAll()
        {
            
            return _context.Books.ToList();
        }       

        public Book FindByID(long id)
        {
            var book = _context.Books.FirstOrDefault(p => p.Id.Equals(id));
            if (book == null)
            {
                throw new KeyNotFoundException("Person not found.");
            }
            return book;

        }

        public Book Update(Book book)
        {
            try
            {
                _context.Update(book);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return book;
        }

    }
}
