using System;
using static System.Console;


    class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;


        public Menu(string prompt, string[] options)
        {
            if(prompt == "default")
            {
                prompt = "What Would You Like To Do?";

                options = new string[] {
                    "Add New Username And Password",
                    "Add New Competitor", "Exit"
                };
            }



            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }



        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if(keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if(SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }

                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if(SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            }
            while(keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }


        private void DisplayOptions()
        {
            Console.WriteLine(Prompt);
            for(int i = 0; i < Options.Length; i++)
            {
                string prefix;
                string currentOption = Options[i];

                if(i == SelectedIndex)
                {
                    prefix = ">";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine($"{prefix}[{currentOption}]");
            }
            Console.ResetColor();


        }
    }
