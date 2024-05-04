namespace ApiToDoList.Dto {
    public record TaskToDoDto {

        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool Completed { get; set; } = default!;
        public string RequisitionDate {

            get { return DateTime.Now.ToString("dd/MM/yyy HH:mm"); }

        }
    }
}
