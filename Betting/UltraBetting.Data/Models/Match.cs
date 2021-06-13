using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UltraBetting.Data.Enums;

namespace UltraBetting.Data.Models
{
    [Serializable]
    public class Match
    {
        /// <summary>
        /// Id of the match.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of match.
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Indicates weather the match is Live or Prematch.
        /// </summary>
        [XmlAttribute("MatchType")]
        public string MatchType { get; set; }

        /// <summary>
        /// The date on which the match begins.
        /// </summary>
        [XmlAttribute("StartDate")]
        public DateTime StartDate { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        /// <summary>
        /// All participating members in the match.
        /// </summary>
        public List<Participant> Participants { get; set; }

        [XmlElement("Bet")]
        public List<Bet> Bets { get; set; }
    }
}
