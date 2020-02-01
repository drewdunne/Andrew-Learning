using System;
using System.Collections.Generic;

namespace TTO2
{
    class GameState : State
    {

        #region Public : VARIABLES
        Player player1;
        Player player2;
        Player activePlayer;
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
            #region Variables
            player1 = CreatePlayer(1);
            player2 = CreatePlayer(2);
            board = new Gameboard();
            bool gameOver = false;
            #endregion

            PrintWelcomeMessages();
            activePlayer = DetermineFirstToAct(); //Player Symbols are set by this method

            do {
                renderer.CleanUpInterface();
                board.PrintBoard(renderer);
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


           // Let's try using this approach for our localization: https://stackoverflow.com/questions/1142802/how-to-use-localization-in-c-sharp
           // Doing it the 'proper' way which will include additional details like data/time formatting, etc.

        enum StringID
        {
            word_Player,
            InputNamePrompt,
            WelcomeMessage1,
            InputMovePrompt,
        };

        string[] Strings =
        {
            "Player",
            ", please input your name!",
            "Welcome to the game! Ready to battle?",
            "Please Input your Move."
        };

        #endregion
        #region Private : METHODS - Create Players
        private Player CreatePlayer(int Player1_or_2)
        {
]            // Print prompt using format:
            // renderer.Print(Player, PlayerNumber, InputNamePrompt)

            renderer.Render($"{Strings[(int)StringID.word_Player]} {Player1_or_2} {Strings[(int)StringID.InputNamePrompt]}" );
            
            // Get player's input
            string aplayerName = reader.GetInput();

            // Check if player's name already exists in database
            if (DoesPlayerExistAlready(aplayerName))
            {
                // Confirm that player is existing player

                ConfirmPlayerIdentity(aplayerName);

                // Retrieve player's records
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
            var random = new Random();
            var result = random.Next(1);
            
            if (result == 0)
            {
                return player1;
            }
            if (result == 1)
            {
                return player2;
            }
            else
            {
                throw new Exception();
            }
        }

        private void PrintWelcomeMessages()
        {
            renderer.PrintMessage(Strings[(int)StringID.WelcomeMessage1]);
        }
    
        private void ExecuteTurn(Player aplayer)
        {
            // Print Board
            // Print Prompt
            // Accept Input
            // Swap Player Turn
            renderer.PrintMessage(Strings[(int)StringID.InputMovePrompt]);
            SwapActivePlayer();
        }

        private void SwapActivePlayer()
        {
            if (activePlayer == player1)
            {
                activePlayer = player2;
            }
            else if (activePlayer == player2)
            {
                activePlayer = player1;
            }
        }
        private bool IsGameOver(Gameboard aboard, Player aplayer)
        {
            throw new NotImplementedException();
        }
    #endregion
    }
}