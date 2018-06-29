using mvcReg.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace mvcReg
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, MyObjectContextMigration>());
        }

        public partial class MyObjectContextMigration : DbMigrationsConfiguration<DatabaseContext>
        {
            #region Ctors
            public MyObjectContextMigration()
                : base()
            {
                this.AutomaticMigrationsEnabled = true;
                this.AutomaticMigrationDataLossAllowed = true;
            }
            #endregion

            #region Overrides

            protected override void Seed(DatabaseContext context)
            {
            }

            #endregion
        }
    }
}
