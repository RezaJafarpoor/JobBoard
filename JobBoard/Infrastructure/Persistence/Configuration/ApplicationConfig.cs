
using JobBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobBoard.Infrastructure.Persistence.Configuration;

public class ApplicationConfig : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Description).HasMaxLength(200);
    }
}
