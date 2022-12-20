namespace ConsoleRPG
{
    class StateGame : State
    {

        public StateGame(Stack<State> states) : base(states)
        {
        }

        public void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    this.states.Push(new StateGame(this.states));
                    break;
                case 2:
                    this.states.Push(new StateCharacterCreator(this.states));
                    break;
                case -1:
                    this.endGame = true;
                    break;
            }
        }

        override public void Update()
        {
            Console.Write(Gui.MenuTitle("Game State"));
            Console.Write(Gui.MenuOption(1, "Create Character"));
            Console.Write(Gui.MenuOption(-1, "Exit"));
            
            Console.WriteLine(Gui.GetInput("Input"));
            int input = Convert.ToInt32(Console.ReadLine());

            this.ProcessInput(input);

        }
    }
}