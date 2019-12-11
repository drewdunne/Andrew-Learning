using System;

namespace TTO2
{
    abstract class State
    {
        public State()
        {
            
        }

        public virtual State Run(Input reader, Output renderer)
        {
            throw new NotImplementedException();
        }
    }
}