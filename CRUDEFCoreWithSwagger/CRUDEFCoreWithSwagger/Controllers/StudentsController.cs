using CRUDEFCoreWithSwagger.BAL;
using CRUDEFCoreWithSwagger.Context;
using CRUDEFCoreWithSwagger.DAL;
using CRUDEFCoreWithSwagger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEFCoreWithSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _StudentService;

        //private readonly IStudentRepository<Student> _Student;

        public StudentsController(StudentService StudentService) //IStudentRepository<Student> Student
        {
            _StudentService = StudentService;
           // _Student = Student;

        }
        //Add Student  
        [HttpPost("AddStudent")]
        [Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]
        public virtual async Task<Object> AddStudent([FromBody] Student Student)
        {
            try
            {
               await _StudentService.AddStudent(Student);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete Student  
        [HttpDelete("DeleteStudentById")]
        [Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]
        public bool DeleteStudent(int Id)
        {
            try
            {
               return  _StudentService.DeleteStudent(Id);
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete Student  
        [HttpPut("UpdateStudent")]
        [Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]
        public bool UpdateStudent(Student student)
        {
            try
            {
                return _StudentService.UpdateStudent(student);
            }
            catch (Exception)
            {
                return false;
            }
        }
        //GET All Student by Name  
        [HttpGet("GetStudentDetailsByName")]
        [Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]
        public Object GetStudentDetailsByName(string Name)
        {
            var data = _StudentService.GetStudentByUserName(Name);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Student  
        [HttpGet("GetAllStudents")]
        [Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]
        public Object GetAllStudents()
        {
            var data = _StudentService.GetAllStudents();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
        //private readonly StudentDBContext _Context;

        //public StudentsController(StudentDBContext CRUDContext)
        //{
        //    _Context = CRUDContext;
        //}

        //// GET: api/<StudentsController>
        //[HttpGet]
        //[Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]

        //public IEnumerable<Student> Get()
        //{
        //    return _Context.Students;
        //}

        //// GET api/<StudentsController>/5
        //[HttpGet("{id}")]
        //[Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]

        //public Student Get(int id)
        //{
        //    return _Context.Students.SingleOrDefault(x => x.StudentId == id);
        //}

        //// POST api/<StudentsController>
        //[HttpPost]
        //[Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]

        //public void Post([FromBody] Student student)
        //{
        //    _Context.Students.Add(student);
        //    _Context.SaveChanges();
        //}

        //// PUT api/<StudentsController>/5
        //[HttpPut("{id}")]
        //[Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]
        //public void Put([FromBody] Student student)
        //{
        //    _Context.Students.Update(student);
        //    _Context.SaveChanges();

        //    //int id = student.StudentId;
        //    //return _Context.Students.SingleOrDefault(s => s.StudentId == id);
        //}

        //// DELETE api/<StudentsController>/5
        //[HttpDelete("{id}")]
        //[Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]
        //public void Delete(int id)
        //{
        //    var item = _Context.Students.FirstOrDefault(x => x.StudentId == id);
        //    if(item != null)
        //    {
        //        _Context.Students.Remove(item);
        //        _Context.SaveChanges();
        //    }
        //}
    }
}
