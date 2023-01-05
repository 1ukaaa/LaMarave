namespace ConsoleRPG
{
    public class MeetMasterEncounter : IEncounter
    {
        public void Execute(Character character)
        {
            Gui.Announcement("Vous rencontrez le maître d'armes !");
            // Augmente le niveau du personnage de 1
            character.Level++;
            // Restaure 10% des PV du personnage (arrondi à l'entier le plus proche)
            character.CurrentHealth += (int)(character.MaxHealth * 0.1f);
            // S'assure que les PV actuels ne dépassent pas les PV Max
            character.CurrentHealth = Math.Min(character.CurrentHealth, character.MaxHealth);
            Console.WriteLine("Le maître d'armes vous a fait monter d'un niveau et vous a restauré 10% de vos PV !");
            Console.WriteLine("Vous pouvez répartir 3 points de vie entre les caractéristiques suivantes :");
            Console.WriteLine("1. PV Max");
            Console.WriteLine("2. Force");
            Console.WriteLine("3. Armure");

            int points = 3;
            while (points > 0)
            {
                Console.WriteLine($"Il vous reste {points} points à répartir.");
                int choice = Gui.GetInputInt("Choix : ");
                switch (choice)
                {
                    case 1:
                        character.MaxHealth++;
                        Console.WriteLine("Vous avez gagné 1 point de vie !");
                        points--;
                        break;
                    case 2:
                        character.Strength++;
                        Console.WriteLine("Vous avez gagné 1 point de force !");
                        points--;
                        break;
                    case 3:
                        character.Armor++;
                        Console.WriteLine("Vous avez gagné 1 point d'armure !");
                        points--;
                        break;
                    default:
                        Console.WriteLine("Entrée non valide, veuillez réessayer.");
                        break;
                }
            }
        }
    }


}