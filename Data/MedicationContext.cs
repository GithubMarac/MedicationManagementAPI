using Microsoft.EntityFrameworkCore;
using MedicationManagementApi.Models;

namespace MedicationManagementApi.Data
{
    public class MedicationContext : DbContext
    {
        public MedicationContext(DbContextOptions<MedicationContext> options)
            : base(options)
        {
        }

        public DbSet<Medication> Medications { get; set; }
    }
}
