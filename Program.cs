using System;
using System.IO;
namespace dotnet_tools
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        Console.WriteLine("Wellcome to TM-Tools!");
        Console.ReadKey(true);
        var allTools = "";
        foreach (Tool item in Tools.items)
        {
          allTools += $"{item.name}: {item.id}{Environment.NewLine}";
        }
        Console.Write(allTools);
        Console.Write("Select tool: ");
        int tool = int.Parse(Console.ReadLine());
        var selected = Tools.items.Find(x => x.id == tool);
        Console.WriteLine($"Selected {tool}: {selected.name}");
        if (tool == 1)
        {
          // Input string target
          Console.Write("Input target: ");
          string target = Console.ReadLine();

          // Only get files
          string[] dirs = Directory.GetFiles(target);
          Console.WriteLine("Total file: {0}.", dirs.Length);

          // Select type rename
          Console.WriteLine($"1: All to new Name{Environment.NewLine}2: Replace with new value");
          Console.Write("Select type rename: ");
          int typeRename = int.Parse(Console.ReadLine());
          if (typeRename == 1)
          {
            Console.Write("Input new name: ");
            string newName = Console.ReadLine();
            Console.Write("Input prefix: ");
            string prefix = Console.ReadLine();
            for (int i = 0; i < dirs.Length; i++)
            {
              var fileInfo = new FileInfo(dirs[i]);
              var newNamePrefix = $"{newName}{prefix}{i + 1}{fileInfo.Extension}";
              fileInfo.MoveTo(Path.Combine(fileInfo.Directory.FullName, newNamePrefix));
              Console.WriteLine($"{dirs[i].Replace(target + "\\", "")}->{newNamePrefix}");
            }
          }
          else if (typeRename == 2)
          {
            Console.Write("Input old string: ");
            string oldString = Console.ReadLine();
            Console.Write("Input new string: ");
            string newString = Console.ReadLine();
            for (int i = 0; i < dirs.Length; i++)
            {
              var fileInfo = new FileInfo(dirs[i]);
              var newName = fileInfo.Name.Replace(oldString, newString);
              fileInfo.MoveTo(Path.Combine(fileInfo.Directory.FullName, newName));
              Console.WriteLine($"{dirs[i].Replace(target + "\\", "")}->{newName}");
            }
          }

          // Input string rename

          //   foreach (string dir in dirs)
          //   {
          //     Console.WriteLine(dir);
          //   }
        }
        else if (tool == 2)
        {
          Console.Write($"{tool}");
        }
        Console.Write($"{Environment.NewLine}Press any key to exit...");
      }
      catch (System.Exception ex)
      {
        Console.Write($"Error: {ex.Message}");
      }
      Console.ReadKey(true);
    }
  }
}
