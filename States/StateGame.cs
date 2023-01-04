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
                    this.Fight();
                    break;
                case 2:
                    Console.WriteLine(this.character.ToString());
                    break;
                case -1:
                    this.endGame = true;
                    break;
            }
        }

        override public void Update()
        {
            Console.Clear();
            Gui.MenuTitle("Game State");
            Gui.MenuOption(1, "Combattre");
            Gui.MenuOption(2, "Statistiques du personnage");
            Gui.MenuOption(-1, "Quitter le jeu");

            this.StartGame();

            int input = Gui.GetInputInt("Input: ");

            this.ProcessInput(input);

        }

        private void StartGame()
        {
            Random random = new Random();

            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine("Tour {0}", i);

                // Génère un entier aléatoire entre 0 et 3
                int encounter = random.Next(4); 
                Gui.Announcement($"Nombre aléatoire: {encounter}");

                // 50% de chance de rencontrer un mob
                if (encounter == 0 || encounter == 1)
                {
                    Console.WriteLine("Vous rencontrez un mob hostile !");
                    // Lance le combat contre le mob
                    this.Fight();
                }
                // 25% de chance de rencontrer Merlin
                else if (encounter == 2)
                {
                    Console.WriteLine("Vous rencontrez Merlin !");
                    this.MeetMerlin();
                }
                // 25% de chance de rencontrer le maître d'armes
                else
                {
                    Console.WriteLine("Vous rencontrez le maître d'armes !");
                    this.MeetMaster();
                }
                // Si le personnage est vaincu, la partie se termine
                if (this.character.CurrentHealth <= 0)
                {
                    Console.WriteLine("Désolé, vous avez été vaincu !");
                    break;
                }
            }
            // Si la boucle s'est terminée normalement, le personnage a gagné la partie
            if (this.character.CurrentHealth > 0)
            {
                Console.WriteLine("Félicitations, vous avez gagné la partie !");
            }

            }
        private void Fight()
        {
            Enemy enemy = new Enemy("Ennemi");
            // Boucle tant que le personnage et le enemy sont tous les deux en vie
            while (this.character.CurrentHealth > 0 && enemy.CurrentHealth > 0)
            {
                // Calcul des dégâts infligés par le personnage au enemy
                int damage = this.character.Strength - enemy.Armor;
                if (damage < 0) damage = 0;
                enemy.CurrentHealth -= damage;
                Console.WriteLine($"Vous infligez {damage} points de dégâts au {enemy.Name}.");
                Console.WriteLine($"Il lui reste {enemy.CurrentHealth} points de vie.");

                // Si le enemy est toujours en vie, il attaque le personnage
                if (enemy.CurrentHealth > 0)
                {
                    // Calcul des dégâts infligés par le enemy au personnage
                    damage = enemy.Strength - this.character.Armor;
                    if (damage < 0) damage = 0;
                    this.character.CurrentHealth -= damage;
                    Console.WriteLine($"{enemy.Name} vous inflige {damage} points de dégâts.");
                    Console.WriteLine($"Il vous reste {this.character.Armor} points d'armure.");
                    Console.WriteLine($"Vous avez {this.character.CurrentHealth} points de vie.");
                }
            }

            // Si le personnage est toujours en vie, il a gagné
            if (this.character.CurrentHealth > 0)
            {
                Console.WriteLine("Félicitations, vous avez gagné la partie!");
            }
            else
            {
                Console.WriteLine("Désolé, vous avez été vaincu et la partie est terminée.");
            }
        }
        private void MeetMerlin()
        {
            // Restaure les PV Max du personnage
            this.character.CurrentHealth = this.character.MaxHealth;
            Console.WriteLine("Merlin vous a restauré vos PV Max !");
            Console.WriteLine($"Vous avez {this.character.CurrentHealth} points de vie.");
        }
        private void MeetMaster()
        {
            // Augmente le niveau du personnage de 1
            this.character.Level++;
            // Restaure 10% des PV du personnage (arrondi à l'entier le plus proche)
            this.character.CurrentHealth += (int)(this.character.MaxHealth * 0.1f);
            // S'assure que les PV actuels ne dépassent pas les PV Max
            this.character.CurrentHealth = Math.Min(this.character.CurrentHealth, this.character.MaxHealth);
            Console.WriteLine("Le maître d'armes vous a fait monter d'un niveau et vous a restauré 10% de vos PV !");
            Console.WriteLine("Vous pouvez répartir 3 points de vie entre les caractéristiques suivantes :");
            Console.WriteLine("1. PV Max");
            Console.WriteLine("2. Force");
            Console.WriteLine("3. Armure");

            int points = 3;
            while (points > 0)
            {
                Console.WriteLine($"Il vous reste {points} points à répartir.");
                int choice = Gui.GetInputInt("Choix : ");
                switch (choice)
                {
                    case 1:
                        this.character.MaxHealth++;
                        Console.WriteLine("Vous avez gagné 1 point de vie !");
                        points--;
                        break;
                    case 2:
                        this.character.Strength++;
                        Console.WriteLine("Vous avez gagné 1 point de force !");
                        points--;
                        break;
                    case 3:
                        this.character.Armor++;
                        Console.WriteLine("Vous avez gagné 1 point d'armure !");
                        points--;
                        break;
                    default:
                        Console.WriteLine("Entrée non valide, veuillez réessayer.");
                        break;
                }
            }
        }
    }
}