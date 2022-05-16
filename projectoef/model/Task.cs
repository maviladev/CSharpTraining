using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectoef.models;

public class Task
{
    [Key]
    public Guid TaskId { get; set; }
    [ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    [Required]
    public Priority PriorityTask { get; set; }
    public DateTime CreationDate { get; set; }
    public virtual Category Category { get; set; }
    [NotMapped] // Let us omit this field in the db
    public string Resume { get; set; } 
}

public enum Priority
{
    Slow,
    Middle,
    High
}