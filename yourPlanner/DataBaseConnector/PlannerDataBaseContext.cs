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
            public PlannerDataBaseContext() : base("DefaultConnection")
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
            public DbSet<DailyPlans> DailyPlans { get; set; }
            public DbSet<User> Users { get; set; }

    }
}
