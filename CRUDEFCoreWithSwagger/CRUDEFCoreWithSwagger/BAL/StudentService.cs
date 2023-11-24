using CRUDEFCoreWithSwagger.Models;
using CRUDEFCoreWithSwagger.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEFCoreWithSwagger.BAL
{
    public class StudentService
    {
        private readonly IStudentRepository<Student> _Student;
        public StudentService()
        {
           
        }
        public StudentService(IStudentRepository<Student> student)
        {
            _Student = student;
        }
        //Get Student Details By Student Id  
        public virtual IEnumerable<Student> GetStudentById(int Id)
        {
            return _Student.GetAll().Where(x => x.StudentId == Id).ToList();
        }

        //GET All Student Details   
        public virtual IEnumerable<Student> GetAllStudents()
        {
            try
            {
                return _Student.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Get Student by Student Name  
        public virtual Student GetStudentByUserName(string UserName)
        {
            return _Student.GetAll().Where(x => x.Name == UserName).FirstOrDefault();
        }
        //Add Student  
        public virtual async Task<Student> AddStudent(Student Student)
        {
            return await _Student.Create(Student);
        }
        //Delete Student   
        public virtual bool DeleteStudent(int Id)
        {

            try
            {
                var DataList = _Student.GetAll().Where(x => x.StudentId == Id).ToList();
                foreach (var item in DataList)
                {
                    _Student.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //Update Student Details  
        public virtual bool UpdateStudent(Student student)
        {
            try
            {
                 _Student.Update(student);               
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
