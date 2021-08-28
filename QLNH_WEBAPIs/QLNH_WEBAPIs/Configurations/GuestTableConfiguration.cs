using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLNH_WEBAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_WEBAPIs.Configurations
{
    public class GuestTableConfiguration : IEntityTypeConfiguration<GuestTable>
    {
        public void Configure(EntityTypeBuilder<GuestTable> builder)
        {
            builder.Property(guestTable => guestTable.Description)
            .HasColumnType("varchar(20)")
            .HasDefaultValue("Chưa có mô tả");

            builder.Property(guestTable => guestTable.Created)
            .IsRequired();

        }
    }
}
