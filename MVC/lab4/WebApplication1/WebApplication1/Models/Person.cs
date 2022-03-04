using System.ComponentModel;

namespace WebApplication1.Models
{
    public class Person
    {
        [DisplayName("Имя")]
        public string? FirstName { get; set; }
        [DisplayName("Фамилия")]
        public string? LastName { get; set; }
        public override string ToString()
        {
            string s = FirstName + " " + LastName;
            return s;
        }

    }
}
