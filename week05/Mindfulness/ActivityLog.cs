using System;
using System.Collections.Generic;
using System.IO;

// Keeps track of the activities done in this session and saves each one
// to a text file, so the history is still there the next time.
public class ActivityLog
{
    private string _fileName;
    private Dictionary<string, int> _sessionCounts;

    public ActivityLog(string fileName)
    {
        _fileName = fileName;
        _sessionCounts = new Dictionary<string, int>();
    }

    public void Record(Activity activity)
    {
        string name = activity.GetName();
        if (_sessionCounts.ContainsKey(name))
        {
            _sessionCounts[name]++;
        }
        else
        {
            _sessionCounts[name] = 1;
        }

        string line = $"{DateTime.Now:yyyy-MM-dd HH:mm}|{name}|{activity.GetDuration()}";
        File.AppendAllText(_fileName, line + Environment.NewLine);
    }

    public void Display()
    {
        Console.WriteLine("This session:");
        if (_sessionCounts.Count == 0)
        {
            Console.WriteLine("  No activities yet.");
        }
        foreach (KeyValuePair<string, int> pair in _sessionCounts)
        {
            Console.WriteLine($"  {pair.Key}: {pair.Value} time(s)");
        }

        Console.WriteLine();
        Console.WriteLine("All saved history:");
        if (!File.Exists(_fileName))
        {
            Console.WriteLine("  Nothing saved yet.");
            return;
        }

        Dictionary<string, int> totalTimes = new Dictionary<string, int>();
        Dictionary<string, int> totalSeconds = new Dictionary<string, int>();
        foreach (string line in File.ReadAllLines(_fileName))
        {
            string[] parts = line.Split('|');
            if (parts.Length != 3 || !int.TryParse(parts[2], out int seconds))
            {
                continue;
            }

            string name = parts[1];
            if (!totalTimes.ContainsKey(name))
            {
                totalTimes[name] = 0;
                totalSeconds[name] = 0;
            }
            totalTimes[name]++;
            totalSeconds[name] += seconds;
        }

        foreach (string name in totalTimes.Keys)
        {
            Console.WriteLine($"  {name}: {totalTimes[name]} time(s), {totalSeconds[name]} seconds in total");
        }
    }
}
