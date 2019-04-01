using CodBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodBlogFitness.BL.Controller
{
    public class ExerciseController:ControllerBase
    {
        private readonly User user;
        public List<Exercise> Exersises { get; }
        public List<Activity> Activities { get; }
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exersises = GetAllExercises();
            Activities=GetAllAcivities();
        }

        private List<Activity> GetAllAcivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        public void Add(Activity activity,DateTime start,DateTime finish)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(start, finish, activity, user);
                Exersises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(start, finish, act, user);
                Exersises.Add(exercise);
            }
            Save();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }
        private void Save()
        {
            Save(Exersises);
            Save( Activities);
        }
    }
}
