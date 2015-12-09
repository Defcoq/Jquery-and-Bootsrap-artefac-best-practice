using System.IO;
using Northwind.Data.Models;

namespace Northwind.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //base.Seed(context);
        }

        #region Helpers

        private static readonly Random rnd = new Random();

        public static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;
            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));
            return from + randTimeSpan;
        }

        #endregion

    }
}
