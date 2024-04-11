using InkFinder.DAL.Constants.Enums;
using InkFinder.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InkFinder.DAL.Context;

public class InkFinderContext(DbContextOptions<InkFinderContext> options) : IdentityDbContext<UserEntity>(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(user => user.Id);
            entity.Property(user => user.Id).ValueGeneratedOnAdd();
        });
        modelBuilder.Entity<WorkSheetEntity>(entity =>
        {
            entity.HasKey(sheet => sheet.Id);
            entity.Property(sheet => sheet.Id).ValueGeneratedOnAdd();
            entity.Property(sheet => sheet.UserId)
                .ValueGeneratedNever();
            entity.HasOne(sheet => sheet.User)
                .WithMany(user => user.WorkSheets)
                .HasForeignKey(sheet => sheet.UserId);
        });
        modelBuilder.Entity<TatooServiceEntity>(entity =>
        {
            entity.HasKey(service => service.Id);
            entity.Property(service => service.Id).ValueGeneratedOnAdd();
            entity.HasIndex(service => service.Name).IsUnique();
            var tatooServices = new List<TatooServiceEntity>()
            {
                new()
                {
                    Id = 1,
                    Name = "Индивидуальный дизайн татуировки",
                    Description = "создание уникального рисунка с учетом пожеланий клиента и его индивидуальных особенностей"
                },
                new() 
                {
                    Id = 2,
                    Name = "Консультация по выбору мотива и стиля",
                    Description = "помощь в определении подходящего дизайна, который отразит вашу личность и стиль"
                },
                new()
                {
                    Id = 3,
                    Name = "Работа с клиентскими эскизами",
                    Description = "проработка и улучшение вашей идеи татуировки в сотрудничестве с мастером"
                },
                new()
                {
                    Id = 4,
                    Name = "Татуировки на любых частях тела",
                    Description = "возможность создания татуировки на любой выбранной вами области кожи"
                },
                new()
                {
                    Id = 5,
                    Name = "Коррекция и доработка старых тату",
                    Description = "возможность исправления и улучшения существующих татуировок"
                },
                new()
                {
                    Id = 6,
                    Name = "Удаление нежелательных татуировок",
                    Description = "профессиональное удаление татуировок без следов и рубцов"
                },
                new()
                {
                    Id = 7,
                    Name = "Временные татуировки и хной",
                    Description = "выбор временных вариантов татуировок для тех, кто хочет испытать новый образ временно"
                },
                new()
                {
                    Id = 8,
                    Name = "Уход и реабилитация после процедуры",
                    Description = "рекомендации и средства для максимально комфортного заживления кожи после татуировки"
                },
                new() 
                {
                    Id = 9,
                    Name = "Услуги мастерства и обучения",
                    Description = "обучение и повышение квалификации в сфере татуировки по индивидуальной программе"
                },
                new()
                {
                    Id = 10,
                    Name = "Проведение тематических мероприятий и выставок",
                    Description = "участие в мероприятиях и выставках, где вы сможете увидеть работы талантливых мастеров и получить новые впечатления"
                }
            };
            entity.HasData(tatooServices);
        });
        modelBuilder.Entity<TatooSignUpEntity>(entity =>
        {
            entity.HasKey(signUp => signUp.Id);
            entity.Property(signUp => signUp.Id).ValueGeneratedOnAdd();
            entity.Property(signUp => signUp.ParticipantId).ValueGeneratedNever();
            entity.Property(signUp => signUp.ServiceId).ValueGeneratedNever();
            entity.Property(signUp => signUp.MasterId).ValueGeneratedNever();
            entity.HasOne(signUp => signUp.Master)
                .WithMany()
                .HasForeignKey(signUp => signUp.MasterId);
            entity.HasOne(signUp => signUp.Service)
                .WithMany(service => service.SignUps)
                .HasForeignKey(signUp => signUp.ServiceId);
            entity.HasOne(signUp => signUp.Participant)
                .WithMany()
                .HasForeignKey(signUp => signUp.ParticipantId);
        });
        modelBuilder.Entity<ArtworkEntity>(entity =>
        {
            entity.HasKey(artwork => artwork.Id);
            entity.Property(artwork => artwork.Id).ValueGeneratedOnAdd();
            entity.Property(artwork => artwork.CreatorId)
                .ValueGeneratedNever();
            entity.HasIndex(artwork => artwork.Name).IsUnique();
            entity.HasOne(artwork => artwork.Creator)
                .WithMany(master => master.Artworks)
                .HasForeignKey(artwork => artwork.CreatorId);
        });
        base.OnModelCreating(modelBuilder);
    }
}
