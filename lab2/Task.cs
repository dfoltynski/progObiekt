using System;

namespace lab2
{
	public class Task
	{
		private string name;
		private TaskStatus status;

        public string Name { get => name; set => name = value; }
		public TaskStatus Status { get => status; set => status = value; }

		public Task() { }

		public Task(string name, TaskStatus status)
        {
			this.Name = name;
			this.Status = status;
        }

        public override bool Equals(object obj)
        {
            return obj is Task task &&
                   name == task.name &&
                   status == task.status;
        }

		public override string ToString()
		{
			return "Task: " + Name + " " + Status;
		}
	}
}
