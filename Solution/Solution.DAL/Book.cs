using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Book : ICRUD<data.Book>
    {
        private IMongoRepository<data.Book> _repo;

        public Book(IMongoRepository<data.Book> repo)
        {
            _repo = repo;
        }

        public void Delete(data.Book t)
        {
            Expression<Func<data.Book,bool>> filterExpression = book => book.Id == t.Id;
            _repo.DeleteOne(filterExpression);
        }

        public IEnumerable<data.Book> GetAll()
        {
            Expression<Func<data.Book, bool>> filterExpression = book => true;
            return _repo.FilterBy(filterExpression);
        }

        public data.Book GetOneById(string id)
        {
            return _repo.FindById(id);
        }

        public void Insert(data.Book t)
        {
            _repo.InsertOne(t);
        }

        public void Update(data.Book t)
        {
            _repo.ReplaceOne(t);
        }
    }
}
