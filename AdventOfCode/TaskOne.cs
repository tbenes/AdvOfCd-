using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class TaskOne
{
    public string inputPath;

    public string[] GetData()
    {
        return System.IO.File.ReadAllLines(inputPath);
    }

    /// <summary>
    /// Načte a zpracuje vstupní data, navrátí list součtů calorii jednotlivých elfů
    /// </summary>
    /// <returns></returns>
    private List<int> ParseInput()
    {
        var finalResult = new List<int>();
        var midResult = new List<int>();

        foreach (string line in GetData())
        {
            if (line.Length > 0)
                midResult.Add(int.Parse(line));
            else
            {
                int totalCalories = 0;
                foreach (int i in midResult)
                {
                    totalCalories += i;
                }
                finalResult.Add(totalCalories);
                midResult.Clear();
            }
        }

        return finalResult;
    }

    /// <summary>
    /// Navrací elfa s nejvíce caloriemi
    /// </summary>
    /// <returns></returns>
    public int ReturnHighest()
    {
        int highest = 0;
        foreach (int i in ParseInput())
        {
            if (i > highest)
                highest = i;
        }

        return highest;
    }

    /// <summary>
    /// Navrací 3 elfy s nejvíce caloriemi
    /// </summary>
    /// <returns></returns>
    public string ReturnHighestThreeTotal()
    {
        var inputs = ParseInput();
        List<int> highest = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            int highestint = 0;
            foreach (int y in inputs)
            {
                if (y > highestint)
                    highestint = y;
            }
            highest.Add(highestint);
            inputs.Remove(highestint);
        }
        return $"Total: {highest[0] + highest[1] + highest[2]}";
    }
}
