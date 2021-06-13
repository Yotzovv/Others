using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraBetting.Data;
using UltraBetting.Service.Managers;

namespace UltraBetting.Tests
{
    [TestFixture]
    public class MatchManagerTests
    {
        [Test]
        public void GetsUpcomingMatchesSuccessfully()
        {
            var optionsBuilder = new DbContextOptionsBuilder<UltraBettingContext>();
            optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=UltraBetting;Trusted_Connection=True;Integrated Security=True;");

            var db = new UltraBettingContext(optionsBuilder.Options);

            var matchManager = new MatchManager(db);

            var upcomingMatches = matchManager.GetUpcomingMatches();

            var currentDate = DateTime.UtcNow;
            var nextDate = DateTime.UtcNow.AddHours(24);

            Assert.IsTrue(upcomingMatches.All(m => m.StartDate >= currentDate && m.StartDate <= nextDate));
        }
    }
}
