using System.ComponentModel.DataAnnotations;

namespace InkFinder.DAL.Entities;

public class RoleEntity
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public required string Name { get; set; }

    public virtual ICollection<UserToRoleRelation>? UserToRoleRelations { get; set; }
}
