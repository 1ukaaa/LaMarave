using System.Collections;

namespace ConsoleRPG
{
    class StateGame : State
    {
        ArrayList characterList;

        public StateGame(Stack<State> states, ArrayList character_List) : base(states)
        {
            this.characterList = character_List;
        }

        public void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    this.states.Push(new StateGame(this.states,this.characterList));
                    break;
                case 2:
                    this.states.Push(new StateCharacterCreator(this.states,this.characterList));
                    break;
                case -1:
                    this.endGame = true;
                    break;
            }
        }

        override public void Update()
        {
            Gui.MenuTitle("Game State");
            Gui.MenuOption(1, "Create Character");
            Gui.MenuOption(-1, "Exit");

            int input = Gui.GetInputInt("Input: ");

            this.ProcessInput(input);

        }
    }
}