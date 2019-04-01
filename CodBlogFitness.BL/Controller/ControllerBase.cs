using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodBlogFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        private readonly  IDateSaver manager = new DatabaseDataSaver();
        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }
        protected List<T> Load<T>()where T:class
        {
            return manager.Load<T >();
        }
    }
}
