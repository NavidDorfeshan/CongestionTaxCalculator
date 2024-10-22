namespace CongestionTaxCalculator.Infrastructure.Data.Configurations;

public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
{
    public void Configure(EntityTypeBuilder<VehicleType> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasData(new VehicleType() { Id = 1, Name = "Emergency vehicles", IsTaxFree = true },
            new VehicleType() { Id = 2, Name = "Busses", IsTaxFree = true }
            , new VehicleType() { Id = 3, Name = "Diplomat vehicles", IsTaxFree = true }
            , new VehicleType() { Id = 4, Name = "Motorcycles", IsTaxFree = true }
            , new VehicleType() { Id = 5, Name = "Military vehicles", IsTaxFree = true }
            , new VehicleType() { Id = 6, Name = "Foreign vehicles", IsTaxFree = true }
            , new VehicleType() { Id = 7, Name = "Car", IsTaxFree = false });

    }

    
    
        
        
    
    
}
