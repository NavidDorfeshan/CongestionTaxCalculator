namespace CongestionTaxCalculator.Infrastructure.Data.Configurations;

public class VehicleTrafficHistoryConfiguration : IEntityTypeConfiguration<VehicleTrafficHistory>
{
    public void Configure(EntityTypeBuilder<VehicleTrafficHistory> builder)
    {
        builder.HasOne(p => p.City)
            .WithMany(p => p.VehicleTrafficHistories)
            .HasForeignKey(d => d.CityId)
            .OnDelete(DeleteBehavior.Restrict).IsRequired();

        builder.HasOne(p => p.VehicleType)
            .WithMany(p => p.VehicleTrafficHistories)
            .HasForeignKey(d => d.VehicleTypeId)
            .OnDelete(DeleteBehavior.Restrict).IsRequired();

        builder.HasData(new VehicleTrafficHistory()
                { Id = 1, CityId = 1, VehicleTypeId = 7, DateTime = Convert.ToDateTime("2013-01-14 21:00:00") }
            , new VehicleTrafficHistory()
                { Id = 2, CityId = 1, VehicleTypeId = 7, DateTime = Convert.ToDateTime("2013-01-14 21:00:00") }
            , new VehicleTrafficHistory()
            {
                Id = 3,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-01-15 21:00:00")
            }

            , new VehicleTrafficHistory()
            {
                Id = 4,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-02-07 06:23:27")
            }

            , new VehicleTrafficHistory()
            {
                Id = 5,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-02-07 15:27:00")
            }

            , new VehicleTrafficHistory()
            {
                Id = 6,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-02-08 06:27:00")
            }

            , new VehicleTrafficHistory()
            {
                Id = 7,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-02-08 06:20:27")
            }

            , new VehicleTrafficHistory()
            {
                Id = 8,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-02-08 14:35:00")
            }

            , new VehicleTrafficHistory()
            {
                Id = 9,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-02-08 15:29:00")
            }

            , new VehicleTrafficHistory()
            {
                Id = 10,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-02-08 15:47:00")
            }

            , new VehicleTrafficHistory()
            {
                Id = 11,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-02-08 16:01:00")
            }

            , new VehicleTrafficHistory()
            {
                Id = 12,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-02-08 16:48:00")
            }

            , new VehicleTrafficHistory()
            {
                Id = 13,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-02-08 17:49:00")
            }

            , new VehicleTrafficHistory()
            {
                Id = 14,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-02-08 18:29:00")
            }

            , new VehicleTrafficHistory()
            {
                Id = 15,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-02-08 18:35:00")
            }

            , new VehicleTrafficHistory()
            {
                Id = 16,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-03-26 14:25:00")
            }

            , new VehicleTrafficHistory()
            {
                Id = 17,
                CityId = 1,
                VehicleTypeId = 7,
                DateTime = Convert.ToDateTime("2013-03-28 14:07:27")
            }
        );



    }
}
