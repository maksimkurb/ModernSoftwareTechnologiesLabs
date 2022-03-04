using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication1.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [DisplayName("Имя")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Описание")]
        [MinLength(10)]
        public string Description { get; set; }

        [DisplayName("Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        [DisplayName("Цвет")]
        public string Color { get; set; }

        [BindNever]
        public string OwnerForeignKey { get; set; }
        
        [DisplayName("Владелец")]
        [HiddenInput(DisplayValue = true)]
        public User Owner { get; set; }
    }
}
