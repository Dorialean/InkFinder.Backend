using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InkFinder.DAL.Entities;

[Table("User")]
public class UserEntity : IdentityUser
{
    [Phone]
    public string? Phone { get; set; }
    public string? FirstName { get; set; }
    public string? SurName { get; set; }
    public string? FatherName { get; set; }
    public DateOnly? Birthday { get; set; }

    public virtual ICollection<WorkSheetEntity>? WorkSheets { get; set; }
    public virtual ICollection<ArtworkEntity>? Artworks { get; set; }
}
