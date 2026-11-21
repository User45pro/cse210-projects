using System;
using System.Collections.Generic;

// Gives a random item from a list, but does not repeat any item
// until all of them have been used once in this session.
public class PromptPicker
{
    private List<string> _items;
    private List<string> _unused;
    private Random _random;

    public PromptPicker(List<string> items)
    {
        _items = items;
        _unused = new List<string>();
        _random = new Random();
    }

    public string GetNext()
    {
        if (_unused.Count == 0)
        {
            _unused.AddRange(_items);
        }

        int index = _random.Next(_unused.Count);
        string item = _unused[index];
        _unused.RemoveAt(index);
        return item;
    }
}
