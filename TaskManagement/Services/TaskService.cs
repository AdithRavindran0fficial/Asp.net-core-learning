using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class TaskService : ITaskService
    {
        public static List<Todo> Task_Collection = new List<Todo>
        {
            new Todo{Name="First task",Description="learn c# programming language",Titile="Learn c#",Status="completed",Id=1}
        };

        public List<Todo> GetAllTasks()
        {
            return Task_Collection;
        }
        public Todo? GetTaskById(int taskId)
        {
            var existing = Task_Collection.FirstOrDefault(t => t.Id == taskId);
           if(existing == null)
            {
                throw new KeyNotFoundException($"Task with {taskId}not found");
            }
            return existing;
        }
        public Todo Create_Task(Todo task)
        {
            if(task == null)
            {
                throw new ArgumentNullException("Task cannot be empty");
            }
            Task_Collection.Add(task);
            return task;
        }
        public Todo Update_Task(int id,Todo task)
        {   
            var updating = Task_Collection.FirstOrDefault(t => t.Id == id);
            if (updating == null)
            {
                throw new KeyNotFoundException("Task not found");
            }
            updating.Status = task.Status;
            updating.Name = task.Name;
            updating.Titile = task.Titile;
            updating.Description = task.Description;
            return updating;

        }
        public void Delete_Task(int taskId)
        {
            var delete = Task_Collection.FirstOrDefault(d => d.Id == taskId);
            if(delete == null)
            {
                throw new KeyNotFoundException($"task with {taskId}not found");
            }
            Task_Collection.Remove(delete);

        }
    }
}
