using CRUDEFCoreWithSwagger.BAL;
using CRUDEFCoreWithSwagger.Context;
using CRUDEFCoreWithSwagger.Controllers;
using CRUDEFCoreWithSwagger.DAL;
using CRUDEFCoreWithSwagger.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace TestProject
{
    public class StudentControllerUnitTest 
    {
        private readonly Mock<StudentRepository> postRepositoryMock = new Mock<StudentRepository>();
        private readonly Mock<StudentService> service = new Mock<StudentService>();
        

        [Test]
        public void TestGetStudentDetailsByName()
        {                 
            Student student = new Student()
            {
                StudentId = 1,
                Name = "dee",
                RollNum = "123"
            };

            service.Setup(x => x.GetStudentByUserName(student.Name)).Returns(student);
            postRepositoryMock.Setup(it => it.GetByName(student.Name)).Returns(student);

            StudentsController controller = new StudentsController(service.Object);
            var result = controller.GetStudentDetailsByName("dee");            

            Assert.True(student.StudentId.ToString().Equals(JObject.Parse(result.ToString())["StudentId"].ToString()));
            Assert.True(student.RollNum.ToString().Equals(JObject.Parse(result.ToString())["RollNum"].ToString()));
            Assert.True(student.Name.ToString().Equals(JObject.Parse(result.ToString())["Name"].ToString()));
        }


        [Test]
        public void TestDeleteStudentDetailsById()
        {
            Student student = new Student()
            {
                StudentId = 1,
                Name = "dee",
                RollNum = "123"
            };

            service.Setup(x => x.DeleteStudent(student.StudentId)).Returns(true);
            postRepositoryMock.Setup(it => it.Delete(student)).Returns(0);

            StudentsController controller = new StudentsController(service.Object);
            var result = controller.DeleteStudent(student.StudentId);
            Assert.IsTrue(result);
        }

        [Test]
        public void TestUpdateStudentDetailsById()
        {
            Student student = new Student()
            {
                StudentId = 1,
                Name = "deepthi",
                RollNum = "123"
            };
            postRepositoryMock.Setup(it => it.Update(student));

            service.Setup(x => x.UpdateStudent(student)).Returns(true);

            StudentsController controller = new StudentsController(service.Object);
            var result = controller.UpdateStudent(student);
            Assert.IsTrue(result);

        }

        [Test]
        public void TestInsertStudentDetails()
        {
            Student student = new Student()
            {
                StudentId = 7,
                Name = "dee",
                RollNum = "123"
            };

            service.Setup(x => x.AddStudent(student)).ReturnsAsync(student);
            postRepositoryMock.Setup(it => it.Create(student)).ReturnsAsync(student);

            StudentsController controller = new StudentsController(service.Object);
            var result = controller.AddStudent(student);
        }


    }
}