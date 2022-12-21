namespace ConsoleRPG
{
    class StateGame : State
    {
        protected Character character;

        public StateGame(Stack<State> states, Character activeCharacter) : base(states)
        {
            this.character = activeCharacter;
        }

        public void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    Console.WriteLine("Name: " + this.character.ToString());
                    break;
                case -1:
                    this.endGame = true;
                    break;
            }
        }

        override public void Update()
        {
            Gui.MenuTitle("Game State");
            Gui.MenuOption(1, "Character Stats");
            Gui.MenuOption(-1, "Exit");

            int input = Gui.GetInputInt("Input: ");

            this.ProcessInput(input);

        }
    }
}