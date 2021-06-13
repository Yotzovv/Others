using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraBetting.Data.Models;

namespace UltraBetting.Service.Interfaces
{
    public interface IMatchManager
    {
        IEnumerable<Match> GetUpcomingMatches();
    }
}
