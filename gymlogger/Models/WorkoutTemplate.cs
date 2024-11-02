﻿namespace gymlogger.Models
{
    public class WorkoutTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Many-to-Many: WorkoutTemplate can have many Exercises
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
