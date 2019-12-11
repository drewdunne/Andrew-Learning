namespace TTO2
{
    class Application
    {
        Output renderer;
        Input reader;
        State _currentState;

        public Application()
        {
            renderer = new Output();
            reader = new Input();
            _currentState = new MenuState();

        }
        
        public void Run()
        {
            _currentState = _currentState.Run(reader, renderer);
        }
    }
}