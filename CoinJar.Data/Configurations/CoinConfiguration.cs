using CoinJar.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoinJar.Data.Configurations
{
    public class CoinConfiguration : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.ToTable("Coin");

            builder.HasKey(x => new { x.Id });
            builder.Property(x => x.Amount).HasColumnType("decimal(18,4)").IsRequired();
            builder.Property(x => x.Volume).HasColumnType("decimal(18,4)").IsRequired();
        }
    }
}
