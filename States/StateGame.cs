namespace ConsoleRPG
{
    class StateGame : State
    {
        protected Character character;
        protected int turn;

        public StateGame(Stack<State> states, Character activeCharacter) : base(states)
        {
            this.character = activeCharacter;
            this.turn = 1;
        }

        public void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    this.Fight();
                    break;
                case 2:
                    Console.WriteLine(this.character.ToString());
                    break;
                case 3:
                    Console.Clear();
                    break;
                case -1:
                    this.endGame = true;
                    break;
            }
        }

        override public void Update()
        {
            Gui.MenuTitle($"Partie en cours - Tour {turn}");
            Gui.MenuOption(1, "Combattre");
            Gui.MenuOption(2, "Statistiques du personnage");
            Gui.MenuOption(3, "Clear console");
            Gui.MenuOption(-1, "Quitter le jeu");

            int input = Gui.GetInputInt("Input: ");

            this.ProcessInput(input);

        }

        public void Fight()
        {
            Random random = new Random();

            Dictionary<IEncounter, int> encounters = new Dictionary<IEncounter, int>
            {
                { new FightEncounter(), 50 },
                { new MeetMerlinEncounter(), 25 },
                { new MeetMasterEncounter(), 25 }
            };

            // Génère un entier aléatoire entre 0 et 99
            int encounterIndex = random.Next(100);
            Gui.Announcement($"Nombre aléatoire: {encounterIndex}");


            foreach (KeyValuePair<IEncounter, int> entry in encounters)
            {
                if (encounterIndex < entry.Value)
                {
                    entry.Key.Execute(this.character);
                    break;
                }
                else
                {
                    encounterIndex -= entry.Value;
                }
            }

            // Si le personnage est vaincu, la partie se termine
            if (this.character.CurrentHealth <= 0)
            {
                Console.WriteLine("Désolé, vous avez été vaincu et la partie est terminée.");
                this.endGame = true;
                return;
            }

            // Vérifier le nombre de tours et terminer la partie si 20 tours sont atteints

            if (turn == 20)
            {
                Console.WriteLine("La partie est terminée, vous avez atteint le nombre maximum de tours.");
                this.endGame = true;
                return;
            }

            // Incrémenter le nombre de tours

            this.turn++;
        }
    }
}