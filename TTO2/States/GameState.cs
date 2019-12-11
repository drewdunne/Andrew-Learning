using System;
using System.Collections.Generic;

namespace TTO2
{
    class GameState : State
    {
        public GameState()
        {

        }

        public override State Run(Input reader, Output printer)
        {
            Player player1 = CreatePlayer(reader, printer, 1);
            Player player2 = CreatePlayer(reader, printer, 2);
            GameBoard board = new GameBoard();
            bool gameOver = false;

            PrintWelcomeMessages(player1, player2);
            Player activePlayer = DetermineFirstToAct(player1, player2); //Player Symbols are set by this method

            do {
                ExecuteTurn(activePlayer);
                gameOver = IsGameOver(board, activePlayer);
            } while (!gameOver);



            throw new NotImplementedException();
        }

        private Dictionary<string, string> prompts = new Dictionary<string, string>()
        {
            {"1_InputName", "Player 1, please input your name!"},
            {"2_InputName", "Player 2, please input your name!"}
        };

        private Player CreatePlayer(Input reader, Output printer, int Player1_or_2)
        {
            printer.Render(prompts[$"{Player1_or_2}_InputName"]);
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

        private Player DetermineFirstToAct(Player aplayer1, Player aplayer2)
        {
            throw new NotImplementedException();
        }

        private void PrintWelcomeMessages(Player aplayer1, Player aplayer2)
        {
            throw new NotImplementedException();
        }
        private bool DoesPlayerExistAlready(string nameToCheck)
        {
            throw new NotImplementedException();
        }
        private Player GetPlayerRecord(string aplayerName)
        {
            throw new NotImplementedException();
        }
        private void ExecuteTurn(Player aplayer)
        {
            throw new NotImplementedException();
        }
        private bool IsGameOver(GameBoard aboard, Player aplayer)
        {
            throw new NotImplementedException();
        }
    }
}