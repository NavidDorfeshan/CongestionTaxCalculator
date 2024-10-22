namespace CongestionTaxCalculator.Infrastructure.Data.Configurations;

public class CalenderConfiguration : IEntityTypeConfiguration<Calender>
{
    public void Configure(EntityTypeBuilder<Calender> builder)
    {
        builder.Property(t => t.MonthName)
            .HasMaxLength(10)
            .IsRequired();
        builder.Property(t => t.IsHoliday)
            .IsRequired();  
        builder.Property(t => t.IsWeekend)
            .IsRequired();
        builder.Property(t => t.IsTaxFree)
            .IsRequired();

        var date = new DateOnly(2013, 1, 1);

        for (int i = 0; i < 365; i++)
        {
            date = date.AddDays(i==0?0:1);
            builder.HasData(new Calender()
            {
                Id = i+1,
                CityId = 1,
                Year = 2013,
                Date = date,
                MonthCode = (short)date.Month,
                MonthName = date.ToString("MMMM"),
                IsWeekend = date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday,
                IsTaxFree = date.ToString("MMMM") == "July" || date.DayOfWeek == DayOfWeek.Sunday ||
                            date.DayOfWeek == DayOfWeek.Saturday,
                IsHoliday = false,//PrePublicHoliday, PublicHoliday
            });
        }
    }
}
