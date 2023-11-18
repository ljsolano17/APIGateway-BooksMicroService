using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System.Linq.Expressions;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Person : ICRUD<data.Person>
    {
        private IMongoRepository<data.Person> _repo;
        
        public Person(IMongoRepository<data.Person> repo)
        {
            _repo = repo;
        }
        public void Delete(data.Person t)
        {
            Expression<Func<data.Person, bool>> filterExpression = person => person.Id == t.Id;
            _repo.DeleteOne(filterExpression);
        }

        public IEnumerable<data.Person> GetAll()
        {
            Expression<Func<data.Person, bool>> filterExpression = person => true;
            return _repo.FilterBy(filterExpression);
        }

        public data.Person GetOneById(string id)
        {
            return _repo.FindById(id);
        }

        public void Insert(data.Person t)
        {
            _repo.InsertOne(t);
        }

        public void Update(data.Person t)
        {
            _repo.ReplaceOne(t);
        }
    }
}
