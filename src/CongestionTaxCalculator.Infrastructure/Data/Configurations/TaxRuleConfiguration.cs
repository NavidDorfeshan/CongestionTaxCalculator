namespace CongestionTaxCalculator.Infrastructure.Data.Configurations;

public class TaxRuleConfiguration : IEntityTypeConfiguration<TaxRule>
{
    public void Configure(EntityTypeBuilder<TaxRule> builder)
    {
        builder.HasOne(p => p.City).WithMany(p => p.TaxRules)
            .HasForeignKey(d => d.CityId)
            .OnDelete(DeleteBehavior.Restrict).IsRequired();

        builder.HasData(new TaxRule()
        {Id = 1,CityId = 1, FromTime = new TimeOnly(6, 0), ToTime = new TimeOnly(6, 29), Amount = 8 }
        , new TaxRule()
        { Id = 2, CityId = 1, FromTime = new TimeOnly(6, 30), ToTime = new TimeOnly(6, 59), Amount = 13 }
        , new TaxRule()
        { Id = 3, CityId = 1, FromTime = new TimeOnly(7, 0), ToTime = new TimeOnly(7, 59), Amount = 18 }
        , new TaxRule()
        { Id = 4, CityId = 1, FromTime = new TimeOnly(8, 0), ToTime = new TimeOnly(8, 29), Amount = 13 }
        , new TaxRule()
        { Id = 5, CityId = 1, FromTime = new TimeOnly(8, 30), ToTime = new TimeOnly(14, 59), Amount = 8 }
        , new TaxRule()
        { Id = 6, CityId = 1, FromTime = new TimeOnly(15, 0), ToTime = new TimeOnly(15, 29), Amount = 13 }
        , new TaxRule()
        { Id = 7, CityId = 1, FromTime = new TimeOnly(15, 30), ToTime = new TimeOnly(16, 59), Amount = 18 }
        , new TaxRule()
        { Id = 8, CityId = 1, FromTime = new TimeOnly(17, 0), ToTime = new TimeOnly(17, 59), Amount = 13 }
        , new TaxRule()
        { Id = 9, CityId = 1, FromTime = new TimeOnly(18, 0), ToTime = new TimeOnly(18, 29), Amount = 8 }
        , new TaxRule()
        { Id = 10, CityId = 1, FromTime = new TimeOnly(18, 30), ToTime = new TimeOnly(5, 59), Amount = 0 }


        );
    }
}
