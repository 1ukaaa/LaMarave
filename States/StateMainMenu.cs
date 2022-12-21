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
                    this.states.Push(new StateCharacterCreator(this.states, this.characterList));
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
            Gui.MenuTitle("Main Menu");
            Gui.MenuOption(1, "New Game");
            Gui.MenuOption(2, "Character Creator");
            Gui.MenuOption(3, "Select Character");
            Gui.MenuOption(-1, "Exit");

            int input = Gui.GetInputInt("Input: ");

            this.ProcessInput(input);
        }

        public void StartNewGame()
        {
            if (this.activeCharacter != null)
            {
                // this.states.Push(new StateGame(this.states, this.activeCharacter));
            }
            else
            {
               Gui.Announcement("There is no active character selected! Please select a character first. ");
            }
        }

        public void SelectCharacter()
        {
            for (int i = 0; i < this.characterList.Count; i++)
            {
                Console.WriteLine(i + ": " + characterList[i]!.ToString());
            }

            int choice = Gui.GetInputInt("Select Character: ");

            try
            {
                this.activeCharacter = (Character)this.characterList[choice]!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (this.activeCharacter != null)
                Gui.Announcement($"Character {this.activeCharacter!.ToString()} is selected.");
            
        }
    
    }
}