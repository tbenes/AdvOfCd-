TaskOne instanceOne = new TaskOne();
TaskSeven instanceSeven = new TaskSeven();

instanceOne.inputPath = Path.Combine(Environment.CurrentDirectory, "input1.txt");
instanceSeven.inputPath = Path.Combine(Environment.CurrentDirectory, "input7.txt");

Console.WriteLine("/// Task 1 ///\n");
Console.WriteLine($"Highest: {instanceOne.ReturnHighest()}");
Console.WriteLine($"ThreeTotal: {instanceOne.ReturnHighestThreeTotal()}");
Console.WriteLine("\n/// Task 7 ///\n");
Console.WriteLine($"Total: {instanceSeven.GetTotalSize()}");
Console.WriteLine($"Síze: {instanceSeven.GetDeleted()}");

Console.ReadKey();
