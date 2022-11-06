using System;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Anything
{
  internal class Program
  {
    private const string SearchPattern = "*.cs";

    // 2 250 325  = D:\Projects\master\DbForge
    // 170 891    = D:\Projects\master\Shell
    // 5 018      = C:\Users\Jhayphal\source\repos\framework
    
    private static void Main(string[] args)
    {
      Console.WriteLine("{0:### ### ###}", WalkFiles("C:\\Users\\Jhayphal\\source\\repos\\framework"));

      Console.ReadLine();
    }

    private static bool HasExpression(string text) =>
      !(string.IsNullOrEmpty(text = text.Trim())
        || text.StartsWith("using")
        || text.StartsWith("namespace")
        || text.StartsWith("//")
        || text == "{"
        || text == "}");

    private static int LinesCount(string file) 
      => File
        .ReadAllLines(file)
        .Where(HasExpression).Count();

    private static int WalkFiles(string folder) 
      => Directory
        .EnumerateFiles(folder, SearchPattern, SearchOption.AllDirectories)
        .Sum(f => LinesCount(f));
  }
}
