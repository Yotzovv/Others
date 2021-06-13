using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraBetting.Data.Enums
{
    public enum MatchTypes
    {
        /// <summary>
        ///  Contains prematch/pregame markets which are open for 
        ///  betting before the start date of a match
        /// </summary>
        Prematch = 1,

        /// <summary>
        /// Contains live markets, which are open for betting 
        /// after the start date of a match
        /// </summary>
        Live = 2,

        /// <summary>
        /// Note: These matches are currently being ignored in the scope of the task.
        /// </summary>
        OutRight = 3
    }
}
