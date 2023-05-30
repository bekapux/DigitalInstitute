using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    
        public class Weapon : IDisposable
        {
            public string Name { get; set; }

            public Weapon(string name)
            {
                Name = name;
            }

            public void Dispose()
            {
                Console.WriteLine($"Weapon {Name} has been disposed.");
            }
        }
    }

