using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer.Models
{
    public class ContactInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "Укажите тип контактной информации.")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Укажите значение контактной информации.")]
        public string Value { get; set; }
        [ForeignKey("Contact")]
        public int ContactID { get; set; }
        public Contact Contact { get; set; }
    }
}
