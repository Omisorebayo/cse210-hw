using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}|{entry._mood}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');

                if (parts.Length == 4)
                {
                    Entry entry = new Entry
                    {
                        _date = parts[0],
                        _promptText = parts[1],
                        _entryText = parts[2],
                        _mood = parts[3]
                    };

                    entries.Add(entry);
                }
            }
        }
    }
}