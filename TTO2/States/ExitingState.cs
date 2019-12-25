using System;

namespace TTO2
{
    public class ExitingState : State
    {

        #region Public : VARIABLES
        #endregion
        #region Public : CONSTRUCTORS
        public ExitingState(Input areader, Output arenderer) : base(areader, arenderer)
        {

        }
        #endregion
        #region Public : METHODS
        public override State Run()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Private : METHODS
        #endregion
    }
}