using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InkFinder.DAL.Entities;

[Table("UserToRole")]
public class UserToRoleRelation
{
    [Required]
    public Guid UserId { get; set; }
    public virtual UserEntity User { get; set; } = null!;

    [Required]
    public Guid RoleId { get; set; }
    public virtual RoleEntity Role { get; set; } = null!;
}
