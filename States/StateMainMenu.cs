using System.Collections;

namespace ConsoleRPG
{
    class StateMainMenu : State
    {
        protected ArrayList characterList;

        public StateMainMenu(Stack<State> states, ArrayList character_List) : base(states)
        {
            this.characterList = character_List;
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
            this.states.Push(new StateGame(this.states, this.characterList));
        }

        public void SelectCharacter()
        {
            foreach (Character character in this.characterList)
            {
                Console.WriteLine(character.ToString());
            }
        }
    
    }
}