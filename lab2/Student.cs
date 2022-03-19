using System.Collections.Generic;

namespace lab2
{
    class Student: Person
    {
        private string group;
        protected List<Task> tasks = new List<Task>();

        protected string Group { get => group; set => group = value; }

        public Student(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }
        public Student(string name, int age, string group, List<Task> tasks)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.tasks = tasks;
        }

        public void AddTask(string taskName, TaskStatus taskStatus)
        {
            Task task = new Task(taskName, taskStatus);
            tasks.Add(task);
        }

        public void RemoveTask(int index)
        {
            tasks.Remove(tasks[index]);
        }

        public void UpdateTask(int index, TaskStatus taskStatus)
        {
            tasks[index].Status = taskStatus;
        }

        public override string ToString()
        {
            string student = "Student: " + Name + ", Age: " + Age;
            string tasksHolder = "";
            foreach (Task task in tasks)
            {
                tasksHolder += task + "\n";
            }

            return student + "\n" + tasksHolder;
        }



        private bool SequenceEquals(List<Task> a, List<Task> b)
        {
            foreach (Task taskA in a)
            {
                foreach (Task taskB in b)
                {
                    if (taskA.Equals(taskB))
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;

            // return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   base.Equals(obj) &&
                   Name == student.Name &&
                   Age == student.Age &&
                   Group == student.Group &&
                   student.SequenceEquals(student.tasks, tasks);
        }
    }
}