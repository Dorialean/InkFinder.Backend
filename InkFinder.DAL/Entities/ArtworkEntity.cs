using System.ComponentModel.DataAnnotations;

namespace InkFinder.DAL.Entities;

public class ArtworkEntity
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public required string Link { get; set; }
    public Guid? CreatorId { get; set; }
    public virtual UserEntity? Creator { get; set; }
}
