using System;
using System.Collections.Generic;

namespace TTO2
{
    
    class MenuState : State
    {
        
        public State NextState 
        {
            get => NextState;
            set 
            {
                _nextState = value; 
                NextState = value;
            }
        }
        public MenuState()
        {
            
        }

        public override State Run(Input reader, Output renderer)
        {
            PrintMenu(renderer, _menuOptions);
            NextState = GetSelection(reader, renderer);


            throw new NotImplementedException();
        }

        private State _nextState;
        private Dictionary<string, string> prompts = new Dictionary<string, string>
        {
            {"Main Prompt", "Please Make a Selection"},
            {"Invalid Selection", "That is not a valid selection"},
            {"Invalid Input", "That is not a valid input. Please type the number corresponding to your selection (ex: '4')"},
            {"Help Rejection", "The /help command cannot be used here. Please enter the selection for 'View Help Key'"}
        };

        private string[] _menuOptions = {"Play Game", "View Leaderboard", "View Help Key", "Exit Game"};
        private void Print(Output renderer, string output)
        {
            renderer.Render(output);
        }

        // Summary:
        //      Utilizes Output to render a properly-formatted menu for end-users.
        private void PrintMenu(Output renderer, string[] output)
        {
            // Make each item in _menuOptions presentable for a menu
            string[] printableMenu = new string[_menuOptions.Length];
            for (int option = 0; option < _menuOptions.Length; ++option)
            {
                printableMenu[option] = $"{option+1}. {_menuOptions[option]} \n";
            }

            // Send the resulting array to Output.Render();
            renderer.Render(printableMenu);

            
        }

        private State GetSelection(Input reader, Output renderer)
        {
            int response = GetValidMenuResponse(reader, renderer, reader.GetInput(prompts["Main Prompt"]));
            return NextState; // is it bad to return things that the methods would be able to access anyways? I figure it makes my code more flexible.
        }

        private int GetValidMenuResponse(Input reader, Output renderer, string input)
        {
            bool inputValid = false;
            int selection;

            do
            {
                input = reader.GetInput();
                try
                {
                    System.Console.WriteLine("DEBUG: Trying");
                    selection = Int32.Parse(input);
                    inputValid = true; // NEXT THING TO ADD: IF Statement to verify that input is valid (currently, we make it past parse and escape the do loop even if input is not valid.)
                    return selection;
                }   
                catch
                {
                    System.Console.WriteLine("DEBUG: InvalidInput in Exception catch ");
                    inputValid = false;
                }
            } while (inputValid =! true);

            throw new ArgumentOutOfRangeException();
        }
    }
}