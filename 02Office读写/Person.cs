using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Office读写
{
    public class Person
    {
        private string _name;
        private int _age;
        private string _email;
        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }
        public string Email { get => _email; set => _email = value; }
    }
}
