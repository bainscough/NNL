using System;
using System.Collections.Generic;

namespace MTCars_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;

            while (!quit) //Loop for invalid inputs
            {
                //Display data
                int size = CSVManager.ReadCSV();

                //Give user options
                Console.WriteLine();
                Console.WriteLine("Enter the number of the row you wish to edit");
                Console.WriteLine("Or enter 0 to quit");

                //Take user input & validate
                bool status = int.TryParse(Console.ReadLine(), out int input);
                if (input > size || input < 0)
                {
                    status = false;
                }

                if (status) //Allow edit of row or quit
                {
                    if (input == 0) //Quit
                    {
                        quit = true;
                        break;
                    }
                    Console.WriteLine();

                    //Display attributes
                    string[] headings = CSVManager.ReadRow(0);
                    for (int i = 0; i < 12; i++)
                    {
                        Console.WriteLine((i+1) + " | " + headings[i]);
                    }
                    int rowIndex = input;
                    string[] row = CSVManager.ReadRow(rowIndex);

                    bool valid = false;
                    while (!valid) //Loop for invalid inputs
                    {
                        Console.WriteLine("Enter the number of the attribute you wish to edit");
                        Console.WriteLine("Or press 0 to cancel and quit");

                        //Take user input
                        status = int.TryParse(Console.ReadLine(), out input);
                        if (input > 12 || input < 0)
                        {
                            Console.WriteLine("Invalid input");
                            Console.WriteLine();
                        }
                        else
                        {
                            valid = true;
                            if (input == 0) //Quit
                            {
                                quit = true;
                                break;
                            }
                            input -= 1;

                            //Display current value
                            Console.WriteLine("Current value for " + headings[input] + " is " + row[input]);
                            Console.WriteLine("Enter new value: ");
                            
                            //Take user input
                            string value = Console.ReadLine();
                            string newRow = "";

                            //Create row with new value
                            for (int x = 0; x < input; x++)
                            {
                                newRow += row[x] + ",";
                            }
                            newRow += value + ",";
                            for (int x = input+1; x < 11; x++)
                            {
                                newRow += row[x] + ",";
                            }
                            newRow += row[11];

                            //Save changes to csv
                            bool save = CSVManager.SaveToCSV(newRow, rowIndex);
                            if (save)
                            {
                                Console.WriteLine("Updated successfully!");
                            }
                            else //If write fails
                            {
                                Console.WriteLine("Failed to update, check CSV file is not being used elsewhere");
                            }
                        }
                    }

                    quit = true;
                }
                else //Ask for another input
                {
                    Console.Clear();
                }
            }
        }
    }
}
