namespace ConsoleRPG
{
    class StateCharacterCreator : State
    {
        public StateCharacterCreator(Stack<State> states) : base(states)
        {
        }

        public void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    
                case -1:
                    this.endGame = true;
                    break;
            }
        }

        override public void Update()
        {
            Console.Write(Gui.MenuTitle("Character Creator"));
            Console.Write(Gui.MenuOption(1, "New Character"));
            Console.Write(Gui.MenuOption(2, "Edit Character"));
            Console.Write(Gui.MenuOption(3, "Delete Character"));
            Console.Write(Gui.MenuOption(-1, "Exit"));


            Console.WriteLine("Write a number (Main Menu): ");
            int input = Convert.ToInt32(Console.ReadLine());

            this.ProcessInput(input);

        }

    }
}