using System;
using System.Collections.Generic;

namespace TTO2
{
    class GameState : State
    {

        #region Public : VARIABLES
        Player player1;
        Player player2;
        Gameboard board;
        #endregion
        #region Public : CONSTRUCTORS
        public GameState(Input areader, Output arenderer) : base(areader, arenderer)
        {
            
        }
        #endregion
        #region Public : METHODS
        public override State Run()
        {
            player1 = CreatePlayer(1);
            player2 = CreatePlayer(2);
            board = new Gameboard();
            bool gameOver = false;

            PrintWelcomeMessages();
            board.PrintBoard(renderer);
            Player activePlayer = DetermineFirstToAct(); //Player Symbols are set by this method

            do {
                ExecuteTurn(activePlayer);
                gameOver = IsGameOver(board, activePlayer);
            } while (!gameOver);

            // TODO : Add Play Again Functionality

            State _nextState = new MenuState(reader, renderer);
            return _nextState;
        }
        #endregion

        #region Private : VARIABLES - IO, returns
        
        #endregion
        #region Private : VARIABLES - String Data
                
        enum StringID
        {
            word_Player,
            InputNamePrompt,
            WelcomeMessage1,
        };

        string[] Strings =
        {
            "Player",
            ", please input your name!",
            "Welcome to the game! Ready to battle?"
        };

        #endregion
        #region Private : METHODS - Create Players
        private Player CreatePlayer(int Player1_or_2)
        {
            renderer.Render($"{Strings[(int)StringID.word_Player]} {Player1_or_2} {Strings[(int)StringID.InputNamePrompt]}" );
            string aplayerName = reader.GetInput();
            if (DoesPlayerExistAlready(aplayerName))
            {
                Player existingPlayer = GetPlayerRecord(aplayerName);
                return existingPlayer;
            }
            else
            {
                Player newPlayer = new Player(aplayerName);
                return newPlayer;
            }
        }

        private bool DoesPlayerExistAlready(string nameToCheck)
        {
            return false;
        }

        private Player GetPlayerRecord(string aplayerName)
        {
            throw new NotImplementedException();
        }

    #endregion
        #region Private : METHODS - Game Setup
        private Player DetermineFirstToAct()
        {
            throw new NotImplementedException();
        }

        private void PrintWelcomeMessages()
        {
            renderer.PrintMessage(Strings[(int)StringID.WelcomeMessage1]);
        }
    
        private void ExecuteTurn(Player aplayer)
        {
            throw new NotImplementedException();
        }
        private bool IsGameOver(Gameboard aboard, Player aplayer)
        {
            throw new NotImplementedException();
        }
    #endregion
    }
}