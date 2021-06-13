using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UltraBetting.Data.Models
{
    [Serializable]
    public class Bet
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [XmlAttribute("ID")]
        public int BetId { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("IsLive")]
        public bool IsLive { get; set; }

        public int MatchId { get; set; }

        public Match Match { get; set; }

        [XmlElement("Odd")]
        public List<Odd> Odds { get; set; }
    }
}
