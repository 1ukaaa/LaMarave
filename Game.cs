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
        
       private Stack<State> states;

        // Private Methods

        private void InitVariables()
        {
            this.endGame = false;
        
        }

        private void InitStates()
        {
            this.states = new Stack<State>();

            this.states.Push(new StateMainMenu(this.states));
        }

        // Constructor and Destructor
        public Game()
        {
            this.InitVariables();
            this.InitStates();
        }

        public void Run()
        {
            while (this.states.Count > 0)
            {
                this.states.Peek().Update();
                if (this.states.Peek().RequestEndGame())
                {
                    this.states.Pop();
                }        
            }
            Console.WriteLine("Ending game...");
        }
    }
}