using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using UltraBetting.Api.JobsServices;
using UltraBetting.Data;
using UltraBetting.Service.Managers;
using UltraBetting.Service.Models;

namespace UltraBetting.Tests
{
    [TestFixture]
    public class FeedManagerTests
    {
        [Test]
        public void GetsXmlSuccessfully()
        {
            string xml = FeedManager.GetXml().Result;

            Assert.IsTrue(!string.IsNullOrEmpty(xml));
        }

        [Test]
        public void DeserializesXml()
        {
            string xml = FeedManager.GetXml().Result;

            var sportsCollection = FeedManager.Deserialize<SportsCollection>(xml);

            Assert.IsTrue(sportsCollection.Sports != null);

            foreach (var sport in sportsCollection.Sports)
            {
                Assert.IsNotNull(sport.Events);

                foreach (var ev in sport.Events)
                {
                    Assert.IsNotNull(ev.Matches);

                    foreach (var match in ev.Matches)
                    {
                        Assert.IsNotNull(match.Bets);

                        foreach (var bet in match.Bets)
                        {
                            Assert.IsNotNull(bet.Odds);
                        }
                    }
                }
            }
        }
    }
}
