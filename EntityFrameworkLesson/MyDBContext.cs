using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLesson
{
    public class MyDBContext:DbContext
    {
        public MyDBContext():base("DBConnectionString")
        {

        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
