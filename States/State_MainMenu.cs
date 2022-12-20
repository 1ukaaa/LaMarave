namespace ConsoleRPG
{
    class StateMainMenu : State
    {
        Character character;

        public StateMainMenu(Stack<State> states) : base(states)
        {
            this.character = new Character("Test");
        }

        override public void Update()
        {
            Console.Write(Gui.MenuTitle("Main Menu"));
            Console.Write(Gui.MenuOption(0, "Create Character"));
            Console.Write(Gui.MenuOption(-1, "Exit"));

            Console.WriteLine(character.ToString());

            Console.WriteLine("Write a number (Main Menu): ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number < 0)
            {
                this.endGame = true;
            }
            
        }
    
    }
}