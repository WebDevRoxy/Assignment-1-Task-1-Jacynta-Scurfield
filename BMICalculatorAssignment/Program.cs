using System;

namespace BMICalculator
{
    class Program
    {
        /// <summary>
        /// Calls to Main Menu to start program
        /// </summary>
        static void Main(string[] args)
        {
            MainMenu();
        }

        /// <summary>
        /// Shows and gets user to select a valid menu option
        /// </summary>
        static void MainMenu()
        {
            Console.WriteLine("Press c to calculate your BMI");
            Console.WriteLine("Press t to view membership rates");
            Console.WriteLine("Press m to return to the main menu");
            Console.WriteLine("Press x to exit the program");

            Boolean validInput = false;

            while (!validInput)
            {
                string userInput = Console.ReadLine();
                validInput = ExecuteMenuOption(userInput);
                if (!validInput)
                {
                    Console.WriteLine("Please input a valid choice: ");
                }
            }
        }

        /// <summary>
        ///  Runs the menu option selected by the user
        /// </summary>
        /// <param name="userInput">The menu option selected by the user</param>
        /// <returns>A boolean value to indicate that a menu option was run</returns>
        static Boolean ExecuteMenuOption(string userInput)
        {
            if (userInput.ToLower() == "x")
            {
                Exit();
            }
            else if (userInput.ToLower() == "m")
            {
                MainMenu();
                return true;
            }
            else if (userInput.ToLower().Trim() == "c")
            {
                CalculateBMI();
                return true;
            }
            else if (userInput.ToLower() == "t")
            {
                Membership();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets user to input numerical value and then calculates user BMI based on the values
        /// </summary>
        static void CalculateBMI()
        {
            double userHeight = ReadNumeric("Please enter your height in meters:");
            double userWeight = ReadNumeric("Please enter your weight in KG:");

            double BMI = (userWeight / (userHeight * userHeight));
            Console.WriteLine("Your BMI is: " + BMI);
            MainMenu();
        }

        /// <summary>
        /// Shows user gym membership options
        /// </summary>
        static void Membership()
        {
            Console.WriteLine("Our membership options are:");
            Console.WriteLine("Basic");
            Console.WriteLine("Regular");
            Console.WriteLine("Premium");
            ReadMembershipInput();
        }

        /// <summary>
        /// Ends program
        /// </summary>
        static void Exit()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Catches if the user's numerical value is valid
        /// </summary>
        /// <param name="prompt">The text printed on the screen to tell the user what to do</param>
        /// <returns>The number input by the user</returns>
        static double ReadNumeric(string prompt)
        {
            Console.WriteLine(prompt);
            double inputValue = 0;
            Boolean validInput = false;

            while (!validInput)
            {
                string userInput = Console.ReadLine();
                ExecuteMenuOption(userInput);

                try
                {
                    inputValue = double.Parse(userInput);
                    validInput = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please input a valid number: ");
                    validInput = false;
                }
            }
            return inputValue;
        }

        /// <summary>
        /// Checks if user input is valid for the membership function
        /// </summary>
        /// <param name="membershipCosts"></param>
        /// <returns>Boolean</returns>
        static void ReadMembershipInput()
        {
            Console.WriteLine("Press b to see the Basic membership price");
            Console.WriteLine("Press r to see the Regular membership price");
            Console.WriteLine("Press p to see the Premium membership price");

            Boolean validInput = false;

            while (!validInput)
            {
                validInput = true;
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "x")
                {
                    Exit();
                }
                else if (userInput.ToLower() == "m")
                {
                    MainMenu();
                }
                else if (userInput.ToLower() == "b")
                {
                    Console.WriteLine("Basic costs $10");
                    MainMenu();
                }
                else if (userInput.ToLower() == "r")
                {
                    Console.WriteLine("Regular costs $15");
                    MainMenu();
                }
                else if (userInput.ToLower() == "p")
                {
                    Console.WriteLine("Premium costs $20");
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Please input a valid choice:");
                    validInput = false;
                }
            }
        }
    }
}