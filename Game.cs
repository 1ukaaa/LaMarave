using System.Collections;

namespace ConsoleRPG
{
    class Game
    {
        // Variables
        private bool endGame;

        public bool EndGame
        {
            get { return endGame; }
            set { endGame = value; }
        }
        
       private Stack<State>? states;
       private ArrayList? characterList;

        // Private Methods

        private void InitVariables()
        {
            this.endGame = false;
        
        }

        private void InitCharacterList()
        {
            this.characterList = new ArrayList();
        }
        private void InitStates()
        {
            this.states = new Stack<State>();

            this.states.Push(new StateMainMenu(this.states,this.characterList!));
        }

        // Constructor and Destructor
        public Game()
        {
            this.InitVariables();
            this.InitCharacterList();
            this.InitStates();
        }

        public void Run()
        {
            while (this.states!.Count > 0)
            {
                this.states.Peek().Update();
                if (this.states.Peek().RequestEndGame())
                {
                    this.states.Pop();
                }        
            }
            Console.WriteLine("Fin du jeu...");
        }
    }
}