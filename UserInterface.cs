using HANOI_1._0;
using System;
using System.Collections.Generic;

public class UserInterface
{
    public void DisplayGameBoard(TowerOfHanoi game)
    {
        Console.Clear();
        Console.WriteLine("Tower of Hanoi");
        Console.WriteLine("--------------");

        // Display the game state using ASCII art
        Console.WriteLine($"Moves: {game.GetMoves()}\n");

        // Display Rod A
        Console.Write("Rod A: ");
        DisplayRod(game.GetRodA());

        // Display Rod B
        Console.Write("Rod B: ");
        DisplayRod(game.GetRodB());

        // Display Rod C
        Console.Write("Rod C: ");
        DisplayRod(game.GetRodC());

        Console.WriteLine("\n");
    }

    private void DisplayRod(List<int> rod)
    {
        foreach (var diskSize in rod)
        {
            
            ConsoleColor color = GetDiskColor(diskSize);

            
            Console.ForegroundColor = color;

            
            Console.Write(new string('*', diskSize));
            Console.Write(new string(' ', 5 - diskSize)); 

           
            Console.ResetColor();
        }
        Console.WriteLine();
    }

    private ConsoleColor GetDiskColor(int diskSize)
    {
        
        switch (diskSize)
        {
            case 1:
                return ConsoleColor.Red; 
            case 2:
                return ConsoleColor.Green;
            case 3:
                return ConsoleColor.Blue; 
            default:
                return ConsoleColor.White; 
        }
    }
    public string GetUserInput()
    {
        return Console.ReadLine();
    }

    public void DisplayLeaderboard(List<PlayerScore> leaderboard)
    {
        Console.WriteLine("Leaderboard:");
        Console.WriteLine("Rank\tName\tMoves");
        int rank = 1;
        foreach (var playerScore in leaderboard)
        {
            Console.WriteLine($"{rank}\t{playerScore.Name}\t{playerScore.Score}");
            rank++;
        }
    }
}
