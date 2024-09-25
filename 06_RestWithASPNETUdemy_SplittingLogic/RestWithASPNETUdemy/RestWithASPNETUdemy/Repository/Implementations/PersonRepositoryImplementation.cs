using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySqlContext _context;

        public PersonRepositoryImplementation(MySqlContext context) 
        { 
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
                
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        public void Delete(long id)
        {
            try
            {
                // Tenta encontrar a pessoa com o ID especificado
                var person = _context.Persons.FirstOrDefault(p => p.Id == id);

                if (person != null)
                {
                    // Remove a pessoa encontrada
                    _context.Persons.Remove(person);

                    // Salva as mudanças no banco de dados
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Person> FindAll()
        {
            
            return _context.Persons.ToList();
        }       

        public Person FindByID(long id)
        {
            var person = _context.Persons.FirstOrDefault(p => p.Id.Equals(id));
            if (person == null)
            {
                throw new KeyNotFoundException("Person not found.");
            }
            return person;

        }

        public Person Update(Person person)
        {
            try
            {
                _context.Update(person);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }       

    }
}
