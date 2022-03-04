using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PersonRepository
    {
        private List<Person> _allResponses = new List<Person>();

        public int NumberOfPersons => _allResponses.Count();
        public IEnumerable<Person> GetAllResponses => _allResponses;

        public void AddResponse(Person p)
        {
            _allResponses.Add(p);
        }
    }
}