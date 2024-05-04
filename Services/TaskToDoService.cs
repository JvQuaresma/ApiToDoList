using ApiToDoList.Context;
using ApiToDoList.Dto;
using ApiToDoList.Models;
using ApiToDoList.Models.Errors;

namespace ApiToDoList.Services {
    public class TaskToDoService : ITaskToDoService{

        private TaskToDoContext _context;

        public TaskToDoService(TaskToDoContext context) {

            _context = context;

        }

        public List<TaskToDo> TaskList(int page) {

            if (page < 1) page = 1;
            int limit = 10;
            int offset = (page - 1) * limit;
            return _context.TasksToDo.Skip(offset).Take(limit).ToList();

        }

        public TaskToDo Include(TaskToDoDto taskDto) {
            if (string.IsNullOrEmpty(taskDto.Title)) {

                throw new TaskToDoError("O título da tarefa não pode ser vazio.");

            }

            var task = new TaskToDo {

                Title = taskDto.Title,
                Description = taskDto.Description,
                Completed = taskDto.Completed,               

            };

            _context.TasksToDo.Add(task);
            _context.SaveChanges();
            return task;

        }

        public TaskToDo SearchById(int id) {
            var tarefa = _context.TasksToDo.Find(id);
            if (tarefa == null) {

                throw new TaskToDoError("Tarefa não encontrada");

            }

            return tarefa;

        }

        public TaskToDo Update(int id, TaskToDoDto taskDto) {
            if (string.IsNullOrEmpty(taskDto.Title)) {

                throw new TaskToDoError("O título da tarefa não pode ser vazio.");

            }

            var taskDb = _context.TasksToDo.Find(id);
            if (taskDb == null) {

                throw new TaskToDoError("Tarefa não encontrada");

            }

            taskDb.Title = taskDto.Title;
            taskDb.Description = taskDto.Description;
            taskDb.Completed = taskDto.Completed;
            
            _context.TasksToDo.Update(taskDb);
            _context.SaveChanges();
            return taskDb;

        }

        public void Remove(int id) {
            var task = _context.TasksToDo.Find(id);
            if (task == null) {

                throw new TaskToDoError("Tarefa não encontrada");

            }

            _context.TasksToDo.Remove(task);
            _context.SaveChanges();

        }
    }
}
