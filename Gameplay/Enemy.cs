namespace ConsoleRPG
{
    class Enemy
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Strength { get; set; }
        public int Armor { get; set; }

        public Enemy(string name)
        {
            Name = name;
            Level = 1;
            MaxHealth = 30;
            CurrentHealth = 30;
            Strength = 5;
            Armor = 0;
        }

        public String NameEnemy()
        {
            return this.Name;
        }

        public override String ToString()
        {
            String str =
                $"Name:\t\t\t{this.Name}\n" +
                $"Level:\t\t\t{this.Level}\n" +
                $"Max Health:\t\t{this.MaxHealth}\n" +
                $"Current Health:\t\t{this.CurrentHealth}\n" +
                $"Strength:\t\t{this.Strength}\n" +
                $"Armor:\t\t\t{this.Armor}\n";

            return str;
        }
    }
}