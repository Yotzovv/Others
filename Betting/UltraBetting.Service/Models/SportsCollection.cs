using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UltraBetting.Data.Models;

namespace UltraBetting.Service.Models
{
    [XmlRoot("XmlSports")]
    public class SportsCollection
    {
        [XmlElement("Sport")]
        public List<Sport> Sports { get; set; }

        [XmlAttribute("CreateDate")]
        public DateTime CreateDate { get; set; }
    }
}
