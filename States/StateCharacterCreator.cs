using System.Collections;

namespace ConsoleRPG
{
    class StateCharacterCreator : State
    {
        ArrayList characterList;
        public StateCharacterCreator(Stack<State> states, ArrayList character_List) : base(states)
        {
            this.characterList = character_List;
        }

        public void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    Console.Write(Gui.Announcement("Character Created"));
                    this.characterList.Add(new Character("UnderTaker"));
                    this.characterList.Add(new Character("John Cena"));
                    this.characterList.Add(new Character("The Rock"));
                    this.characterList.Add(new Character("Triple H"));
                    break;
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