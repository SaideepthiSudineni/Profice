using CRUDEFCoreWithSwagger.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEFCoreWithSwagger.Context
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
