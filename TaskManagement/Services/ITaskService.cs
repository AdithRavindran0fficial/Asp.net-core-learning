using TaskManagement.Models;

namespace TaskManagement.Services
{
    public interface ITaskService
    {
        List<Todo> GetAllTasks();
        Todo? GetTaskById(int taskId);
        Todo Create_Task(Todo task);
        Todo Update_Task(int id,Todo task);
        void  Delete_Task(int taskId);
    }
}
