using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourRoadSafety.Models
{
    public class CrashDataContext : DbContext
    {
        public IDbSet<CrashData> Crashes { get; set; }
        public CrashDataContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<CrashDataContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CrashDataMap());
        }
    }
}
