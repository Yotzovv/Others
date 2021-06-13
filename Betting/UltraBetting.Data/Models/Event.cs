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
    public class Event
    {
        /// <summary>
        /// Id of the Event.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [XmlAttribute("ID")]
        public int EventId { get; set; }

        /// <summary>
        /// Name of the event.
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Determines if event is live.
        /// </summary>
        [XmlAttribute("IsLive")]
        public bool IsLive { get; set; }

        /// <summary>
        /// Id of category.
        /// </summary>
        [XmlAttribute("CategoryID")]
        public int CategoryId { get; set; }

        public int SportId { get; set; }

        public Sport Sport { get; set; }

        /// <summary>
        /// Groups all Matches currently taking place within the Event (i.e Tournament)
        /// </summary>
        [XmlElement("Match")]
        public List<Match> Matches { get; set; }
    }
}
