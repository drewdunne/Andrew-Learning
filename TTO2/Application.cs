using System;
using System.Collections;
using System.Linq;

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
            _currentState = new MenuState(reader, renderer);

        }
        
        public void Run()
        {
            do
            {
                _currentState = _currentState.Run();
            } while (_currentState != null);
        }
    }
}