using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yourPlanner.Model;

namespace yourPlanner.DataBaseConnector
{
    class PlannerDataBaseContext : DbContext
    {
            private static PlannerDataBaseContext autoPartsStoreContext;
            private static object syncRoot = new Object();
            private PlannerDataBaseContext() : base("DefaultConnection")
            {

            }
            public static PlannerDataBaseContext GetPlannerBaseContext()
            {
                if (autoPartsStoreContext == null)
                {
                    lock (syncRoot)
                    {
                        if (autoPartsStoreContext == null)
                            autoPartsStoreContext = new PlannerDataBaseContext();
                    }
                }
                return autoPartsStoreContext;
            }
            public DbSet<User> Users { get; set; }
            public DbSet<DailyPlans> DailyPlans { get; set; }

            public DbSet<DayInfo> DayInfo { get; set; }
            public DbSet<WeekPriority> WeekPriorities { get; set; }
            public DbSet<LoginPassword> LoginPasswords { get; set; }
            public DbSet<YearPlans> YearPlans { get; set; }

    }
}
