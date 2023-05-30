namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Character> characters = new List<Character>();
            List<ISkill> skillUsers = new List<ISkill>();

            Warrior warrior = new Warrior("Warrior", 100, 20, 2, 60);
            Mage mage = new Mage("Mage", 80, 15, 1, 80);

            characters.Add(warrior);
            characters.Add(mage);

            skillUsers.Add(warrior);
            skillUsers.Add(mage);

            // Characters attacking each other
            foreach (var character in characters)
            {
                character.Attack(warrior); // Each character attacks the warrior
            }

            // Characters using their skills
            foreach (var skillUser in skillUsers)
            {
                skillUser.UseSkill();
            }

            // Dispose of the characters and their equipped weapons
            foreach (var character in characters)
            {
                using (character.EquippedWeapon = new Weapon("Sword"))
                {
                    // Character actions
                }
            }

            warrior.GetHp();
            mage.GetHp();

        }
    }

}
            



