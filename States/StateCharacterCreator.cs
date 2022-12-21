using System.Collections;

namespace ConsoleRPG
{
    class StateCharacterCreator : State
    {
        ArrayList characterList;

        // Private 

        private void CreateCharacter()
        {
            String? name = "";
            Gui.GetInput("Character Name: ");
            name = Console.ReadLine();
            this.characterList.Add(new Character("UnderTaker"));
            this.characterList.Add(new Character("John Cena"));
            this.characterList.Add(new Character("The Rock"));
            this.characterList.Add(new Character(name!));
            Gui.Announcement("Character Created");
        }
        public StateCharacterCreator(Stack<State> states, ArrayList character_List) : base(states)
        {
            this.characterList = character_List;
        }

        public void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    this.CreateCharacter();
                    break;
                case -1:
                    this.endGame = true;
                    break;
            }
        }

        
        override public void Update()
        {
            Gui.MenuTitle("Character Creator");
            Gui.MenuOption(1, "New Character");
            Gui.MenuOption(2, "Edit Character");
            Gui.MenuOption(3, "Delete Character");
            Gui.MenuOption(-1, "Exit");

            int input = Gui.GetInputInt("Input: ");

            this.ProcessInput(input);

        }

    }
}