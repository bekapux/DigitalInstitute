using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Enums;

namespace Task.Utils
{
    public static class StatRandomizer
    {
        static Random random = new Random();

        public static string GetRandomName()
        {
            int count = Enum.GetNames(typeof(CharacterNames)).Length;

            return ((CharacterNames)random.Next(count)).ToString();
        }

        public static Races GetRandomRace()
        {
            int count = Enum.GetNames(typeof(Races)).Length;

            return ((Races)random.Next(count));
        }

        public static Enums.Classes GetRandomClass()
        {
            int count = Enum.GetNames(typeof(Classes)).Length;

            return ((Enums.Classes)random.Next(count));
        }
    }
}
