using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEFCoreWithSwagger.DAL
{
    public interface IStudentRepository<T>
    {
        public Task<T> Create(T _object);

        public void Update(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int Id);
        public T GetByName(string Name);

        public int Delete(T _object);
    }
}
