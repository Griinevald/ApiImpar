using ApiImpar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiImpar.Data.Map
{
    public class CarMap : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
           builder.HasKey(x => x.Id);
           builder.Property(x => x.Name).HasMaxLength(255);
           builder.Property(x => x.PhotoId);
           builder.Property(x => x.Status).HasMaxLength(1000);

           builder.HasOne(x => x.Photo);
        }
    }
}
