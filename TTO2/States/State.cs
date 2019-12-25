
using System;

namespace TTO2
{
    public abstract class State
    {

        #region Public : CONSTRUCTORS

        public State(Input areader, Output arenderer)
        {
            reader = areader;
            renderer = arenderer;
        }

        #endregion
        public abstract State Run();
        
        #region Private : VARIABLES
        protected Input reader;
        protected Output renderer;

        protected State _nextState;
        #endregion

    }
}