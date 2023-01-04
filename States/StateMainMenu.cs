using System.Collections;

namespace ConsoleRPG
{
    class StateMainMenu : State
    {
        protected ArrayList characterList;
        protected Character? activeCharacter;

        public StateMainMenu(Stack<State> states, ArrayList character_List) : base(states)
        {
            this.characterList = character_List;
            this.activeCharacter = null;
        }

        public void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    this.StartNewGame();
                    break;
                case 2:
                    this.CreateCharacter();
                    break;
                case 3:
                    this.SelectCharacter();
                    break;
                case -1:
                    this.endGame = true;
                    break;
            }            
        }

        override public void Update()
        {
            if(this.activeCharacter != null)
                Gui.Announcement($"Active Character: {this.activeCharacter!.NameCharacter()}"+ "\n");
            Gui.MenuTitle("Main Menu");
            Gui.MenuOption(1, "Commencer une nouvelle partie");
            Gui.MenuOption(2, "Nouveau Personnage");
            Gui.MenuOption(3, "Selectionne un personnage");
            Gui.MenuOption(-1, "Quitter");

            int input = Gui.GetInputInt("Input: ");

            this.ProcessInput(input);
        }

        public void StartNewGame()
        {
            if (this.activeCharacter != null)
            {
                this.states.Push(new StateGame(this.states, this.activeCharacter));
            }
            else
            {
                Gui.Announcement("Il n'y a pas de personnage actif selectionné! Veuillez selectionner un personnage d'abord. ");
            }
        }

        public void CreateCharacter()
        {
            String? name = "";

            Gui.GetInput("Nom du personnage: ");
            name = Console.ReadLine();
            this.characterList.Add(new Character(name!));
            Gui.Announcement("Personnage créé");
        }

        public void SelectCharacter()
        {
            for (int i = 0; i < this.characterList.Count; i++)
            {
                Gui.Announcement($"Numéro: {i} ");
                Console.WriteLine(characterList[i]!.ToString());
            }

            int choice = Gui.GetInputInt("Sélectionne un personnage (numéro): ");

            try
            {
                this.activeCharacter = (Character)this.characterList[choice]!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (this.activeCharacter != null)
                 Gui.Announcement($"Personnage {this.activeCharacter!.ToString()} est selectionné.");
            
        }
    
    }
}