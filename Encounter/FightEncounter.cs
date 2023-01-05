namespace ConsoleRPG
{
    public class FightEncounter : IEncounter
    {
        public void Execute(Character character)
        {
            Gui.Announcement("Vous rencontrez un mob hostile !");
            Character enemy = new Character("Ennemi");
            enemy.Strength = 20;
            // Boucle tant que le joueur et l'ennemi sont tous les deux en vie
            while (character.CurrentHealth > 0 && enemy.CurrentHealth > 0)
            {
                // Calcul des dégâts infligés par le joueur à l'ennemi
                int damage = character.Strength - enemy.Armor;
                if (damage < 0) damage = 0;
                enemy.CurrentHealth -= damage;
                Console.WriteLine($"Vous infligez {damage} points de dégâts au {enemy.Name}.");
                Console.WriteLine($"Il lui reste {enemy.CurrentHealth} points de vie.");

                // Si l'ennemi est toujours en vie, il attaque le joueur
                if (enemy.CurrentHealth > 0)
                {
                    // Calcul des dégâts infligés par l'ennemi au joueur
                    damage = enemy.Strength - character.Armor;
                    if (damage < 0) damage = 0;
                    character.CurrentHealth -= damage;
                    Console.WriteLine($"{enemy.Name} vous inflige {damage} points de dégâts.");
                    Console.WriteLine($"Vous avez {character.CurrentHealth} points de vie.");
                }
            }

            // Si le joueur est toujours en vie, il a gagné
            if (character.CurrentHealth > 0)
            {
                Gui.MessageWin("Félicitations, vous avez gagné la partie!");
            }
        }
    }
}