using ApiImpar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiImpar.Data.Map
{
    public class PhotoMap : IEntityTypeConfiguration<PhotoModel>
    {
        public void Configure(EntityTypeBuilder<PhotoModel> builder)
        { 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Base64).IsRequired();
        }
            
               
    }
}
