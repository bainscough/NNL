using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace MTCars_Console_App
{
    class CSVManager
    {
        const string kFilePath = "F:/NNL/mtcars.csv"; //Path to csv file
      
        public static int ReadCSV()
        {
            int count = 0;
            int[] spacing = {19, 5, 3, 6, 4, 5, 6, 6, 2, 2, 4, 2};

            using (StreamReader fileReader = new StreamReader(kFilePath))
            {
                //Read row by row until end
                while (!fileReader.EndOfStream)
                {
                    //Split into array of strings
                    string entity = fileReader.ReadLine();
                    string[] attributes = entity.Split(',');

                    if (count < 10)
                    {
                        Console.Write(count + "  | ");
                    }
                    else
                    {
                        Console.Write(count + " | ");
                    }

                    //Display row of data
                    for (int i = 0; i < attributes.Length - 1; i++)
                    {
                        Console.Write(attributes[i]);

                        int space = spacing[i] - attributes[i].Length;
                        for (int j = 0; j < space; j++)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(" | ");
                    }
                    Console.Write(attributes[attributes.Length - 1]);
                    Console.WriteLine();

                    if (count == 0)
                    {
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                    }
                    count++;
                }
            }
            return count;
        }

        public static string[] ReadRow(int index)
        {
            string[] row;

            using (StreamReader fileReader = new StreamReader(kFilePath))
            {
                for (int i = 0; i < index; i++)
                {
                    fileReader.ReadLine();
                }
                string line = fileReader.ReadLine();
                row = line.Split(',');
            }
            
            return row;
        }

        public static bool SaveToCSV(string newRow, int rowIndex)
        {
            bool status = true;
            List<string> toSave = new List<string>();

            try
            {
                using (StreamReader fileReader = new StreamReader(kFilePath))
                {
                    for (int i = 0; i < rowIndex; i++)
                    {
                        toSave.Add(fileReader.ReadLine());
                    }
                    fileReader.ReadLine();
                    toSave.Add(newRow);
                    while (!fileReader.EndOfStream)
                    {
                        toSave.Add(fileReader.ReadLine());
                    }
                }

                using (StreamWriter fileWriter = new StreamWriter(kFilePath))
                {
                    for (int i = 0; i < toSave.Count; i++)
                    {
                        fileWriter.WriteLine(toSave[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
            }

            return status;
        }
    }
}
