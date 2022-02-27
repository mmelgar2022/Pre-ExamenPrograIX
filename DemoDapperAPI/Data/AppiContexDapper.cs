using Microsoft.EntityFrameworkCore;
using DemoDapperAPI.Models;

namespace DemoDapperAPI.Data
{
    public class AppiContexDapper : DbContext
    {
        public AppiContexDapper (DbContextOptions<AppiContexDapper> options) : base(options)
        { }
        public DbSet<DemoDapperAPI.Models.Clte> Cliente { get; set; }
    }
}
