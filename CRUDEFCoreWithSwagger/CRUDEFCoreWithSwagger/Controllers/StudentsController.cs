using CRUDEFCoreWithSwagger.Context;
using CRUDEFCoreWithSwagger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDEFCoreWithSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly StudentDBContext _Context;

        public StudentsController(StudentDBContext CRUDContext)
        {
            _Context = CRUDContext;
        }


        // GET: api/<StudentsController>
        [HttpGet]
        [Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]

        public IEnumerable<Student> Get()
        {
            return _Context.Students;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]

        public Student Get(int id)
        {
            return _Context.Students.SingleOrDefault(x => x.StudentId == id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        [Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]

        public void Post([FromBody] Student student)
        {
            _Context.Students.Add(student);
            _Context.SaveChanges();
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]

        public void Put([FromBody] Student student)
        {
            _Context.Students.Update(student);
            _Context.SaveChanges();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = RoleModel.Admin + ", " + RoleModel.User)]

        public void Delete(int id)
        {
            var item = _Context.Students.FirstOrDefault(x => x.StudentId == id);
            if(item != null)
            {
                _Context.Students.Remove(item);
                _Context.SaveChanges();
            }
        }
    }
}
