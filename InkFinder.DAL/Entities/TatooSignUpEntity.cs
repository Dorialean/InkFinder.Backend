using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InkFinder.DAL.Entities;

[Table("TatooSignUp")]
public class TatooSignUpEntity
{
    [Required]
    public int Id { get; set; }

    [ForeignKey("Master")]
    public Guid? MasterId { get; set; }
    public virtual UserEntity? Master { get; set; }

    [Required]
    [ForeignKey("Participant")]
    public Guid ParticipantId { get; set; }
    public virtual UserEntity Participant { get; set; } = null!;

    [Required]
    public int ServiceId { get; set; }
    public virtual TatooServiceEntity Service { get; set; } = null!;

    public string? Comment { get; set; }
    [Range(0, 10)]
    public double Score { get; set; }
}
