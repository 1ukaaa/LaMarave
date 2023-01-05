namespace ConsoleRPG
{
    public class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Strength { get; set; }
        public int Armor { get; set; }

        public Character(string name)
        {
            Name = name;
            Level = 1;
            MaxHealth = 30;
            CurrentHealth = 30;
            Strength = 15;
            Armor = 15;
        }

        public String NameCharacter()
        {
            return this.Name;
        }

        public override String ToString()
        {
            String str =
                $"Nom:\t\t\t{this.Name}\n" +
                $"Level:\t\t\t{this.Level}\n" +
                $"Vie Max:\t\t{this.MaxHealth}\n" +
                $"Vie Actuelle:\t\t{this.CurrentHealth}\n" +
                $"Force:\t\t\t{this.Strength}\n" +
                $"Armure:\t\t\t{this.Armor}\n";

            return str;
        }
    }
}