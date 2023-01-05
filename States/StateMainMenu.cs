using System.Collections;

namespace ConsoleRPG
{
    class StateMainMenu : State
    {
        protected ArrayList characterList;
        protected Character? activeCharacter;

        public StateMainMenu(Stack<State> states, ArrayList character_List) : base(states)
        {
            this.characterList = character_List;
            this.activeCharacter = null;
        }

        public void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    this.StartNewGame();
                    break;
                case 2:
                    this.CreateCharacter();
                    break;
                case 3:
                    this.SelectCharacter();
                    break;
                case -1:
                    this.endGame = true;
                    break;
            }            
        }

        override public void Update()
        {
            if(this.activeCharacter != null)
                Gui.Announcement($"Personnage actif: {this.activeCharacter!.NameCharacter()}"+ "\n");
            Gui.MenuTitle("Menu Principal");
            Gui.MenuOption(1, "Commencer une nouvelle partie");
            Gui.MenuOption(2, "Nouveau Joueur");
            Gui.MenuOption(3, "Selectionne un joueur");
            Gui.MenuOption(-1, "Quitter");

            int input = Gui.GetInputInt("Entrée : ");

            this.ProcessInput(input);
        }

        public void StartNewGame()
        {
            if (this.activeCharacter != null)
            {
                this.states.Push(new StateGame(this.states, this.activeCharacter));
            }
            else
            {
                Gui.Announcement("Il n'y a pas de joueur actif selectionné! Veuillez selectionner un joueur d'abord. ");
            }
        }

        public void CreateCharacter()
        {
            String? name = "";

            Console.Write("Nom du joueur: ");
            name = Console.ReadLine();

            // Création du joueur
            Character character = new Character(name!);

            // Demande au joueur de répartir ses points supplémentaires
            int remainingPoints = 12;
            while (remainingPoints > 0)
            {
                Console.WriteLine($"Points restants : {remainingPoints}");
                Console.WriteLine("Choisissez la caractéristique à augmenter :");
                Console.WriteLine("1 - PV Max");
                Console.WriteLine("2 - Armure");
                Console.WriteLine("3 - Force");
                Console.Write("Input: ");
                int input = int.Parse(Console.ReadLine()!);

                int pointsToAdd;
                switch (input)
                {
                    case 1:
                        Console.Write("Combien de points souhaitez-vous ajouter à PV Max : ");
                        pointsToAdd = int.Parse(Console.ReadLine()!);
                        if (pointsToAdd > remainingPoints)
                        {
                            Console.WriteLine("Vous n'avez pas assez de points restants.");
                            continue;
                        } else if (pointsToAdd < 0)
                        {
                            Console.WriteLine("Vous ne pouvez pas ajouter de points négatifs.");
                            continue;
                        } 

                        character.MaxHealth += pointsToAdd;
                        remainingPoints -= pointsToAdd;
                        break;
                    case 2:
                        Console.Write("Combien de points souhaitez-vous ajouter à l'Armure : ");
                        pointsToAdd = int.Parse(Console.ReadLine()!);
                        if (pointsToAdd > remainingPoints)
                        {
                            Console.WriteLine("Vous n'avez pas assez de points restants.");
                            continue;
                        } else if (pointsToAdd < 0)
                        {
                            Console.WriteLine("Vous ne pouvez pas ajouter de points négatifs.");
                            continue;
                        }
                        character.Armor += pointsToAdd;
                        remainingPoints -= pointsToAdd;
                        break;
                    case 3:
                        Console.Write("Combien de points souhaitez-vous ajouter à la Force : ");
                        pointsToAdd = int.Parse(Console.ReadLine()!);
                        if (pointsToAdd > remainingPoints)
                        {
                            Console.WriteLine("Vous n'avez pas assez de points restants.");
                            continue;
                        } else if (pointsToAdd < 0)
                        {
                            Console.WriteLine("Vous ne pouvez pas ajouter de points négatifs.");
                            continue;
                        }
                        character.Strength += pointsToAdd;
                        remainingPoints -= pointsToAdd;
                        break;
                }
            }

            this.characterList.Add(character);
            Gui.Announcement("Joueur créé");
        }


        public void SelectCharacter()
        {
            for (int i = 0; i < this.characterList.Count; i++)
            {
                Gui.Announcement($"Numéro: {i} ");
                Console.WriteLine(characterList[i]!.ToString());
            }

            int choice = Gui.GetInputInt("Sélectionne un joueur (numéro): ");

            try
            {
                this.activeCharacter = (Character)this.characterList[choice]!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (this.activeCharacter != null)
                 Gui.Announcement($"Joueur {this.activeCharacter!.ToString()} est selectionné.");
            
        }
    
    }
}