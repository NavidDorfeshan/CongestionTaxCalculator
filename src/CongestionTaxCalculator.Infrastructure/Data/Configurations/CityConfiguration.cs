namespace CongestionTaxCalculator.Infrastructure.Data.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasData(new City()
        {
            Id = 1,
            Name = "Gothenburg",
        });

    }
}
