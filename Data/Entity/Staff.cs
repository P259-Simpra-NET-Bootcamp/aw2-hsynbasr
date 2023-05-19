using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Staff
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        [NotMapped]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }


        
    }
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.Property(i => i.FirstName).IsRequired(true).HasMaxLength(30);
            builder.Property(i => i.LastName).IsRequired(true).HasMaxLength(30);
            builder.Property(i => i.Phone).IsRequired(true).HasMaxLength(11);
            builder.Property(i => i.Email).IsRequired(true).HasMaxLength(100);
            builder.Property(i => i.AddressLine1).IsRequired(true).HasMaxLength(150);
            builder.Property(i => i.City).IsRequired(true).HasMaxLength(150);
            builder.Property(i => i.Country).IsRequired(true).HasMaxLength(150);
            
            
            builder.HasIndex(i => i.Email).IsUnique(true);
        }
    }
}
