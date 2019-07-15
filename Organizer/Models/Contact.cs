using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "Введите фамилию."), MaxLength(30)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Введите Имя."), MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string SecondName { get; set; }
        [UIHint("Date")]
        public DateTime? BirthDate { get; set; }
        [MaxLength(100)]
        public string Company { get; set; }
        [MaxLength(50)]
        public string Job { get; set; }

        public List<ContactInfo> Infos { get; set; }

    }
}
