using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Make Tacos al Pastor at Home", "Cocina con Rosa", 845);
        video1.AddComment(new Comment("Mike R.", "I tried this last weekend and my family loved it."));
        video1.AddComment(new Comment("Laura G.", "What can I use if I don't have a trompo?"));
        video1.AddComment(new Comment("Daniel", "The pineapple part is the best."));
        videos.Add(video1);

        Video video2 = new Video("10 English Phrases for Your First Job Interview", "English with Sam", 612);
        video2.AddComment(new Comment("Ana P.", "This helped me a lot, I have an interview tomorrow."));
        video2.AddComment(new Comment("Carlos M.", "Can you make one about phone calls?"));
        video2.AddComment(new Comment("Jenny", "Number 7 is so useful."));
        video2.AddComment(new Comment("Tom B.", "Great tips, thank you."));
        videos.Add(video2);

        Video video3 = new Video("Best Budget Phones of the Year", "TechCheck", 978);
        video3.AddComment(new Comment("Kevin L.", "I bought the second one and I'm happy with it."));
        video3.AddComment(new Comment("Sofia", "You forgot to talk about the battery."));
        video3.AddComment(new Comment("Marco T.", "Good review, very honest."));
        videos.Add(video3);

        Video video4 = new Video("Morning Routine for Busy Parents", "Family Time Daily", 430);
        video4.AddComment(new Comment("Emily S.", "Getting everything ready the night before really works."));
        video4.AddComment(new Comment("Jorge", "My kids wake up at 6, this is real life."));
        video4.AddComment(new Comment("Rachel K.", "Love the idea of the checklist on the fridge."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            video.DisplayInfo();
            Console.WriteLine();
        }
    }
}
