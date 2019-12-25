using System.Collections.Generic;
using System;

namespace TTO2
{
    
    class MenuState : State
    {

        #region Public : VARIABLES,: IO + Return vars
        #endregion
        #region Public : VARIABLES, Properties
        public State NextState 
                {
                    get => _nextState;
                    set => _nextState = value;
                }
        #endregion
        #region Public : CONSTRUCTORS
        public MenuState(Input areader, Output arenderer) : base(areader, arenderer)
        {
        }
        #endregion
        #region Public : METHODS, Primary
            
                public override State Run()
                {
                    PrintMenu();
                    NextState = GetSelection();

                    return NextState;
                }
        #endregion

        #region Private : VARIABLES, List of Printable Strings
                protected enum StringID
                {
                    initialPrompt,
                    exitPrompt,
                    invalidSelection,
                    invalidInput,
                    rejectHelp
                };
                protected string[] Strings =
                {
                    "Please Make a Selection",
                    "Are you sure you want to exit the game?",
                    "That is not a valid selection",
                    "That is not a valid input. Please type the number corresponding to your selection (ex: '4')",
                    "The /help command cannot be used here. Please enter the selection for 'View Help Key'"
                };
                private string[] _menuOptions = {"Play Game", "View Leaderboard", "View Help Key", "Exit Game"};

        #endregion    
        #region Private : METHODS, Print Functions
                // Summary:
                //      Utilizes Output to render a properly-formatted menu for end-users.
                private void PrintMenu()
                {
                    
                    // Appends numeric prefix to each menu options
                    string[] printableMenu = new string[_menuOptions.Length];
                    for (int option = 0; option < _menuOptions.Length; ++option)
                    {
                        printableMenu[option] = $"{option+1}. {_menuOptions[option]} \n";
                    }

                    renderer.Render(printableMenu);
                }
        #endregion
        #region Private : METHODS, Selection Items & Logic

        private State GetSelection()
        {
            int response = GetValidMenuResponse(reader, renderer, Strings[(int)StringID.initialPrompt]);
            
            //Translates user menu selection into proper response
            switch (response)
            {
                case 1:
                    NextState = new GameState(reader, renderer);
                    break;
                case 2:
                    NextState = new LeaderboardState(reader, renderer);
                    break;
                case 3:
                    NextState = new MenuState(reader, renderer);
                    break;
                default:
                    break;

            }
            return NextState; // is it bad to return things that the methods would be able to access anyways? I figure it makes my code more flexible.
        }

        private int GetValidMenuResponse(Input reader, Output renderer, string prompt)
        {
            bool inputValid = false;
            int selection;

            do
            {
                string input = reader.GetInput(prompt);
                try
                {
                    selection = Int32.Parse(input);
                    inputValid = true; // NEXT THING TO ADD: IF Statement to verify that input is valid (currently, we make it past parse and escape the do loop even if input is not valid.)
                    return selection;
                }   
                catch
                {
                    inputValid = false;
                }
            } while (inputValid =! true);

            throw new ArgumentOutOfRangeException();
        }
#endregion

    }
}