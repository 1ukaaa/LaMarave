namespace ConsoleRPG
{
    class StateMainMenu : State
    {
        public StateMainMenu(Stack<State> states) : base(states)
        {
            this.states.Push(new StateGame(this.states));
        }

        override public void Update()
        {
            Console.Write(Gui.MenuTitle("Main Menu"));
            Console.Write(Gui.MenuOption(0, "Create Character"));
            Console.Write(Gui.MenuOption(-1, "Exit"));

            Console.WriteLine("Write a number (Main Menu): ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number < 0)
            {
                this.endGame = true;
            }
            
        }
    
    }
}