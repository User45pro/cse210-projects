using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    string dateText = DateTime.Now.ToShortDateString();
                    Entry newEntry = new Entry(dateText, prompt, response);
                    theJournal.AddEntry(newEntry);
                    Console.WriteLine("Entry recorded!\n");
                    break;

                case "2":
                    theJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFileName = Console.ReadLine();
                    theJournal.LoadFromFile(loadFileName);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFileName = Console.ReadLine();
                    theJournal.SaveToFile(saveFileName);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.\n");
                    break;
            }
        }
    }
}
