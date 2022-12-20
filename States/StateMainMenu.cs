namespace ConsoleRPG
{
    class StateMainMenu : State
    {

        public StateMainMenu(Stack<State> states) : base(states)
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
            Console.Write(Gui.MenuTitle("Main Menu"));
            Console.Write(Gui.MenuOption(1, "New Game"));
            Console.Write(Gui.MenuOption(2, "Character Creator"));
            Console.Write(Gui.MenuOption(-1, "Exit"));


            Console.WriteLine("Write a number (Main Menu): ");
            int input = Convert.ToInt32(Console.ReadLine());

            this.ProcessInput(input);
        }
    
    }
}