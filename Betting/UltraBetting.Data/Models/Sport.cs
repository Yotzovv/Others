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
    public class Sport
    {
        /// <summary>
        /// Id of the Sport.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [XmlAttribute("ID")]
        public int SportId { get; set; }

        /// <summary>
        /// Name of the sport.
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        ///  Groups all Events currently taking place within the Sport
        /// </summary>
        [XmlElement("Event")]
        public List<Event> Events { get; set; }

        /// <summary>
        /// The creation date of the sport entity.
        /// </summary>
        [XmlAttribute("CreateDate")]
        public DateTime CreatedDate { get; set; }
    }
}
