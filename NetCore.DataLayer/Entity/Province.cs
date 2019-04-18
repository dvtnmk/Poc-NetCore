using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.DataLayer.Entity
{
    public class Province
    {

        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public int GeoId { get; set; }
        public bool IsActive { get; set; }
        public int Sort { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string ProvinceTitle { get; set; }
        public bool IsAddress { get; set; }
        public bool IsCarRegis { get; set; }

        public virtual ICollection<Aumphur> AumphurList {get;set;}
    }

    public class ProvinceConfig : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.Property(t => t.ProvinceCode).HasColumnName("PROVINCE_CODE");
            builder.Property(t => t.ProvinceName).HasColumnName("PROVINCE_NAME");
            builder.Property(t => t.GeoId).HasColumnName("GEO_ID");
            builder.Property(t => t.IsActive).HasColumnName("isActive");
            builder.Property(t => t.Sort).HasColumnName("sort");
            builder.Property(t => t.CreateDate).HasColumnName("create_date");
            builder.Property(t => t.UpdateDate).HasColumnName("update_date");
            builder.Property(t => t.CreateBy).HasColumnName("create_by");
            builder.Property(t => t.UpdateBy).HasColumnName("update_by");
            builder.Property(t => t.ProvinceTitle).HasColumnName("province_title");
            builder.Property(t => t.IsAddress).HasColumnName("is_address");
            builder.Property(t => t.IsCarRegis).HasColumnName("is_car_regis");

            builder.HasKey(t => t.ProvinceCode);
            builder.HasMany(t => t.AumphurList).WithOne();

            builder.ToTable("Province");

        }

    }
}
