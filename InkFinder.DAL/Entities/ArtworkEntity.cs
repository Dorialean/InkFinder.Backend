using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InkFinder.DAL.Entities;

[Table("Artwork")]
public class ArtworkEntity
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Link { get; set; } = null!;
    public string? CreatorId { get; set; }
    public virtual UserEntity? Creator { get; set; }
}
