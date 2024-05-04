using ApiToDoList.Dto;
using ApiToDoList.Models;


namespace ApiToDoList.Services {
    public interface ITaskToDoService {

        List<TaskToDo> TaskList(int page);

        TaskToDo Include(TaskToDoDto taskDto);

        TaskToDo SearchById(int id);

        TaskToDo Update(int id, TaskToDoDto taskDto);

        void Remove(int id);
    }
}
