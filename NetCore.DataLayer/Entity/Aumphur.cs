using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.DataLayer.Entity
{

    public class Aumphur
    {
        public string AumphurCode { get; set; }
        public string AumphurName { get; set; }
        public int? PostCode { get; set; }
        public string ProvinceCode { get; set; }
        public bool IsActive { get; set; }
        public int Sort { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
    }

    public class AumphurConfig : IEntityTypeConfiguration<Aumphur>
    {
        public void Configure(EntityTypeBuilder<Aumphur> builder)
        {
            builder.Property(t => t.AumphurCode).HasColumnName("AMPHUR_CODE");
            builder.Property(t => t.AumphurName).HasColumnName("AMPHUR_NAME");
            builder.Property(t => t.PostCode).HasColumnName("POSTCODE");
            builder.Property(t => t.ProvinceCode).HasColumnName("PROVINCE_CODE");
            builder.Property(t => t.IsActive).HasColumnName("isActive");
            builder.Property(t => t.Sort).HasColumnName("sort");
            builder.Property(t => t.CreateDate).HasColumnName("create_date");
            builder.Property(t => t.UpdateDate).HasColumnName("update_date");
            builder.Property(t => t.CreateBy).HasColumnName("create_by");
            builder.Property(t => t.UpdateBy).HasColumnName("update_by");
            // Primary Key
            builder.HasKey(t => t.AumphurCode);
            builder.ToTable("Amphur");
        }
    }
}