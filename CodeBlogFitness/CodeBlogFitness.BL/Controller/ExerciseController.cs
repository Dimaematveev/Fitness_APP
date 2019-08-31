﻿using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    public class ExerciseController :ControllerBase
    {
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        private readonly User user;
        public List<Exercise> Exercises;
        public List<Activity> Activities;
        public ExerciseController(User user)
        {
            this.user = user?? throw new ArgumentNullException("Пользователь не должен быть пустым!",nameof(user));
            Exercises = GetAllExercise();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, end, activity, user);

                Exercises.Add(exercise);
                
            }
            else
            {
                var exercise = new Exercise(begin, end, activity, user);

                Exercises.Add(exercise);
            }
            Save();
        }

        private List<Exercise> GetAllExercise()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }
        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }
        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}
