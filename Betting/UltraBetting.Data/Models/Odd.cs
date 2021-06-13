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
    public class Odd
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [XmlAttribute("ID")]
        public int OddId { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Value")]
        public float Value { get; set; }

        [XmlAttribute("SpecialBetValue")]
        public string SpecialBetValue { get; set; }

        public int BetId { get; set; }

        public Bet Bet { get; set; }
    }
}
