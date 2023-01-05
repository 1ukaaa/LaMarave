namespace ConsoleRPG
{
    public class MeetMerlinEncounter : IEncounter
    {
        public void Execute(Character character)
        {
            Gui.Announcement("Vous rencontrez Merlin !");
            // Restaure les PV Max du personnage
            character.CurrentHealth = character.MaxHealth;
            Console.WriteLine("Merlin vous a restauré vos PV Max !");
            Console.WriteLine($"Vous avez {character.CurrentHealth} points de vie.");
        }
    }

}