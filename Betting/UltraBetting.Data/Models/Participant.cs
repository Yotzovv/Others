using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UltraBetting.Data.Models
{
    public class Participant
    {
        [XmlElement(ElementName = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the participant.
        /// </summary>
        [XmlElement(ElementName = "ParticipantName")]
        public string ParticipantName { get; set; }
    }
}
