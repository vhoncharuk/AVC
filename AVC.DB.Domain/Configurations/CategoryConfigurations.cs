using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVC.DB.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace AVC.DB.Domain.Configurations
{
    class CategoryConfigurations : EntityTypeConfiguration<Category>
    {
        public CategoryConfigurations()
        {
            ToTable("Category");
            HasKey(s => s.Nidcategory);
            //this.Property(s => s.nid_category).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasMany(s => s.Products).WithRequired(t => t.Category).WillCascadeOnDelete(false);
        }
    }
}
