using CodBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodBlogFitness.BL.Controller
{
    public class DatabaseDataSaver:IDateSaver
    {
        public List<T> Load<T>() where T:class
        {
            using (var db = new FitnessContext())
            {
                return db.Set<T>().Where(l => true).ToList();
            }
        }


        public void Save<T>(List<T> item) where T:class
        {
            using(var db=new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
