using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Book : ICRUD<data.Book>
    {
        private readonly IMongoRepository<data.Book> _repo;
        public Book(IMongoRepository<data.Book> repo)
        {
            _repo = repo;
        }

        public void Delete(data.Book t)
        {
            new DAL.Book(_repo).Delete(t);
        }

        public IEnumerable<data.Book> GetAll()
        {
            return new DAL.Book(_repo).GetAll();
        }

        public data.Book GetOneById(string id)
        {
            return new DAL.Book(_repo).GetOneById(id);
        }

        public void Insert(data.Book t)
        {
            new DAL.Book(_repo).Insert(t);
        }

        public void Update(data.Book t)
        {
            new DAL.Book(_repo).Update(t);
        }
    }
}
