using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HospitalApp.Models;

namespace HospitalApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HospitalApp.Models.Doctor> Doctor { get; set; } = default!;
        public DbSet<HospitalApp.Models.Patient> Patient { get; set; } = default!;
        public DbSet<HospitalApp.Models.PatientInfo> PatientInfo { get; set; } = default!;
    }
}
