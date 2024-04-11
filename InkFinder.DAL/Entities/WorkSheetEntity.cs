using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InkFinder.DAL.Entities;

[Table("WorkSheet")]
public class WorkSheetEntity
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string UserId { get; set; }
    public virtual UserEntity User { get; set; } = null!;
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow; 
}
