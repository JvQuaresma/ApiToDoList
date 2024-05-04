using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiToDoList.Models {
    public class TaskToDo {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = default!;

        [Column(TypeName = "text")]
        public string Description { get; set; } = default!;
        public bool Completed { get; set; } = default!;
        public string RequisitionDate {

            get { return DateTime.Now.ToString("dd/MM/yyy HH:mm"); }
                               
        }
    }
}
