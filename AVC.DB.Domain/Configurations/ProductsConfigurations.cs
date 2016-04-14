using AVC.DB.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AVC.DB.Domain.Configurations
{
    public class ProductsConfigurations : EntityTypeConfiguration<Products>
    {
        public ProductsConfigurations()
        {
            this.ToTable("Products");
            this.HasKey(s => s.Nidproduct);
            this.Property(s => s.Nidproduct).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //this.HasMany(s => s.Category).WithRequired(t => t.Products).WillCascadeOnDelete(false);
        }
    }
}
