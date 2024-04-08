using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InkFinder.DAL.Entities;

[Table("TatooService")]
public class TatooServiceEntity
{
    [Required]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<TatooSignUpEntity>? SignUps { get; set; }
}
