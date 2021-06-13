using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraBetting.Data;
using UltraBetting.Data.Models;
using UltraBetting.Service.Interfaces;

namespace UltraBetting.Service.Managers
{
    public class MatchManager : IMatchManager
    {
        private readonly UltraBettingContext dbContext;

        public MatchManager(UltraBettingContext context)
        {
            this.dbContext = context;
        }

        /// <summary>
        /// Returns the matches starting in the next 24 hours.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Match> GetUpcomingMatches()
        {
            var currentDate = DateTime.UtcNow;
            var nextDate = DateTime.UtcNow.AddHours(24);
            
            var matches = dbContext.Matches
                                   .Where(x => x.StartDate >= currentDate && x.StartDate <= nextDate)
                                   .Include( b => b.Bets )
                                   .ThenInclude( o => o.Odds)
                                   .ToList();

            return matches;
        }
    }
}
