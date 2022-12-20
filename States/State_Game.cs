namespace ConsoleRPG
{
    class StateGame : State
    {
        public StateGame(Stack<State> states) : base(states)
        {

        }

        override public void Update()
        {
            Console.Write(Gui.MenuTitle("Game State"));
            Console.Write(Gui.MenuOption(0, "Create Character"));
            Console.Write(Gui.MenuOption(-1, "Exit"));
            
            Console.WriteLine("Write a number (Game): ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number < 0)
            {
                this.endGame = true;
            }

        }
    }
}