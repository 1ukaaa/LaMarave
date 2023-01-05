namespace ConsoleRPG
{
    public class FightEncounter : IEncounter
    {
        public void Execute(Character character)
        {
            Console.WriteLine("Vous rencontrez un mob hostile !");
            Enemy enemy = new Enemy("Ennemi");
            // Boucle tant que le personnage et le enemy sont tous les deux en vie
            while (character.CurrentHealth > 0 && enemy.CurrentHealth > 0)
            {
                // Calcul des dégâts infligés par le personnage aux ennemis
                int damage = character.Strength - enemy.Armor;
                if (damage < 0) damage = 0;
                enemy.CurrentHealth -= damage;
                Console.WriteLine($"Vous infligez {damage} points de dégâts au {enemy.Name}.");
                Console.WriteLine($"Il lui reste {enemy.CurrentHealth} points de vie.");

                // Si le enemy est toujours en vie, il attaque le personnage
                if (enemy.CurrentHealth > 0)
                {
                    // Calcul des dégâts infligés par le enemy au personnage
                    damage = enemy.Strength - character.Armor;
                    if (damage < 0) damage = 0;
                    character.CurrentHealth -= damage;
                    Console.WriteLine($"{enemy.Name} vous inflige {damage} points de dégâts.");
                    Console.WriteLine($"Vous avez {character.CurrentHealth} points de vie.");
                }
            }

            // Si le personnage est toujours en vie, il a gagné
            if (character.CurrentHealth > 0)
            {
                Console.WriteLine("Félicitations, vous avez gagné la partie!");
            }
        }
    }
}