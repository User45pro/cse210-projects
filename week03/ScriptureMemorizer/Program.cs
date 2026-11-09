using System;
using System.Collections.Generic;

/*
 * CSE 210: Programming with Classes
 * Week 03 Project: Scripture Memorizer Program
 * Student: William Michel Borja Ornelas
 * 
 * Exceeding Requirements:
 * 1. Intelligent Hiding: The HideRandomWords method filters and only selects from words that are NOT already hidden,
 *    preventing redundant attempts and ensuring smooth progress until full completion.
 * 2. Multi-Scripture Library: Rather than hardcoding only one passage, the program maintains a library of scriptures
 *    including single-verse and multi-verse passages (Proverbs 3:5-6, John 3:16, 2 Nephi 2:25, D&C 6:36),
 *    randomly selecting one each time or cycling through them.
 * 3. Preserved Punctuation: When words are hidden, letters and numbers turn into underscores matching their length,
 *    while standard punctuation marks (periods, commas, semicolons) remain intact for better memorization cadence.
 */

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),
            new Scripture(
                new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy."
            ),
            new Scripture(
                new Reference("Doctrine and Covenants", 6, 36),
                "Look unto me in every thought; doubt not, fear not."
            )
        };

        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            try
            {
                Console.Clear();
            }
            catch (System.IO.IOException)
            {
                // Gracefully ignore if console handle is redirected
            }

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words in the scripture have been hidden. Great practice!");
                break;
            }

            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}
