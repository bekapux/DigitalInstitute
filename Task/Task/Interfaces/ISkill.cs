using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Interfaces
{
    public interface ISkill
    {
        public void UseBasicSkill(Character character);
        public void UseEmpoweredSkill(Character character);
        public void UseUltimateSkill(List<Character> characters);
    }
}
