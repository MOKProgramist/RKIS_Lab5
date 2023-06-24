using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RKIS_Lab5.Models
{
    public partial class ModelEF : DbContext
    {
        public ModelEF()
            : base("name=ModelEF")
        {
        }

        public virtual DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
