using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class TaskSeven
{
    public string inputPath;
    public int partTwoRes = 0;

    public string[] GetData()
    {
        return System.IO.File.ReadAllLines(inputPath);
    }

    /// <summary>
    /// Načte a zpracuje vstupní data, navrátí directory s velikostmi jednotlivích adresářů
    /// </summary>
    /// <returns></returns>
    private Dictionary<string, int> GetInput()
    {
        var stack = new Stack<string>();
        var sizes = new Dictionary<string, int>();

        foreach (var item in GetData())
        {
            if (item.StartsWith("$ ls") || item.StartsWith("dir"))
                continue;

            if (item.StartsWith("$ cd"))
            {
                string dest = item.Split()[2];
                if (dest == "..")
                {
                    stack.Pop();
                }
                else
                {
                    string path = (stack.Count > 0) ? $"{stack.Peek()}_{dest}" : dest;
                    stack.Push(path);
                }
            }
            else
            {
                string[] parts = item.Split();
                int value = int.Parse(parts[0]);
                string file = parts[1];

                foreach (string path in stack)
                {
                    if (!sizes.ContainsKey(path))
                        sizes[path] = 0;
                    sizes[path] += value;
                }
            }
        }

        return sizes;
    }

    /// <summary>
    /// Navrátí nejmenší možný adresář ke smazání pro update
    /// </summary>
    /// <returns></returns>
    public string GetDeleted()
    {
        var input = GetInput();

        int neededSize = 30000000 - (70000000 - input["/"]);

        List<int> bigEnough = new List<int>();

        foreach (int s in input.Values)
        {
            if (s >= neededSize)
            {
                bigEnough.Add(s);
            }
        }

        partTwoRes = 0;
        foreach (int s in bigEnough)
        {
            if (partTwoRes == 0)
                partTwoRes = s;
            else if (s < partTwoRes)
                partTwoRes = s;
        }

        return $"{partTwoRes}";
    }

    /// <summary>
    /// Navrátí součet velikostí všech directories o maximální velikotsi 100000
    /// </summary>
    /// <returns></returns>
    public string GetTotalSize()
    {
        int result = 0;

        foreach (var item in GetInput())
        {
            if (item.Value <= 100000)
                result += item.Value;
        }

        return $"{result}";
    }
}
