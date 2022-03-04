using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Data
    {
        public Data(String name, int value)
        {
            Name = name;
            Value = value;
        }
        public String Name { get; set; }
        public int Value { get; set; }
    }
    class Model
    {
        public IList<Data> Data
        {
            get
            {
                return new List<Data>
                {
                    new Data("Иванов", 10),
                    new Data("Петров", 30),
                    new Data("Сиборов", 10),
                    new Data("Кузнецов", 20),
                    new Data("Павлов", 40)
                };
            }
        }
    }
}
