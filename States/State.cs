namespace ConsoleRPG
{
    class State
    {
        protected Stack<State> states;
        protected bool endGame = false;
        public State(Stack<State> states)
        {
            this.states = states;
        }

        public bool RequestEndGame()
        {
            return this.endGame;
        }
        
        virtual public void Update()
        {
            
        }
    }
}