using CRUDEFCoreWithSwagger.Context;
using CRUDEFCoreWithSwagger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEFCoreWithSwagger.DAL
{
    public class StudentRepository : IStudentRepository<Student>
    {
        StudentDBContext _dbContext;
        public StudentRepository(StudentDBContext CRUDContext)
        {
            _dbContext = CRUDContext;
        }
        public virtual async Task<Student> Create(Student student)
        {
            var obj = await _dbContext.Students.AddAsync(student);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public virtual int Delete(Student student)
        {
            try
            {
                _dbContext.Remove(student);
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public IEnumerable<Student> GetAll()
        {
            try
            {
                return _dbContext.Students;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual Student GetById(int Id)
        {
            return _dbContext.Students.Where(x => x.StudentId == Id).FirstOrDefault();
        }

        public virtual Student GetByName(string Name)
        {
            return _dbContext.Students.Where(x => x.Name == Name).FirstOrDefault();
        }

        public virtual void Update(Student student)
        {
            _dbContext.Students.Update(student);
            _dbContext.SaveChanges();
        }
    }
}
