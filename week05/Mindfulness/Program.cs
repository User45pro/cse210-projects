using System;

/*
 * CSE 210 W05 Project: Mindfulness Program
 *
 * Exceeding requirements:
 * 1. Prompts and questions do not repeat until all of them have been used once
 *    in the session (PromptPicker class).
 * 2. Activity log: every finished activity is saved to mindfulness_log.txt with the
 *    date and the seconds, and the menu has an option to see how many times each
 *    activity was done in this session and the total time saved in the file
 *    (ActivityLog class).
 * 3. The program checks that the duration is a whole number greater than zero and
 *    asks again if it is not.
 */

class Program
{
    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog("mindfulness_log.txt");
        BreathingActivity breathing = new BreathingActivity();
        ReflectingActivity reflecting = new ReflectingActivity();
        ListingActivity listing = new ListingActivity();

        string choice = "";
        while (choice != "5")
        {
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View activity log");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == null)
            {
                break;
            }
            else if (choice == "1")
            {
                breathing.Run();
                log.Record(breathing);
            }
            else if (choice == "2")
            {
                reflecting.Run();
                log.Record(reflecting);
            }
            else if (choice == "3")
            {
                listing.Run();
                log.Record(listing);
            }
            else if (choice == "4")
            {
                Console.WriteLine();
                log.Display();
                Console.WriteLine();
                Console.WriteLine("Press enter to go back to the menu.");
                Console.ReadLine();
            }
        }
    }
}
