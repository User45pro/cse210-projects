using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        ClearScreen();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        _duration = AskForDuration();

        ClearScreen();
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(4);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> frames = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = (i + 1) % frames.Count;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string number = i.ToString();
            Console.Write(number);
            Thread.Sleep(1000);
            Console.Write(new string('\b', number.Length));
            Console.Write(new string(' ', number.Length));
            Console.Write(new string('\b', number.Length));
        }
    }

    protected void ClearScreen()
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
    }

    private int AskForDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string answer = Console.ReadLine();
            if (int.TryParse(answer, out int seconds) && seconds > 0)
            {
                return seconds;
            }
            Console.WriteLine("Please enter a whole number greater than zero.");
        }
    }
}
