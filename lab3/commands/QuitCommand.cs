using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace Lab3;

public class QuitCommand : Command
{
    public QuitCommand() : base("quit", "exit the program")
    {
    }

    public override HistoryEntity Execute()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Stopping...");
        Console.ForegroundColor = ConsoleColor.White;
        Application.Stop();

        return new HistoryEntity(this, "Stop.");
    }
}