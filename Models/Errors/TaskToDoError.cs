namespace ApiToDoList.Models.Errors {
    public class TaskToDoError : Exception {

        public TaskToDoError(string message) : base (message) {

        }
    }
}
