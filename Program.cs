using HANOI_1._0;
using System;

class Program
{
    private static bool playAgain;

    static void Main(string[] args)
    {
        TowerOfHanoi game = new TowerOfHanoi(3); 
        GameSerializer serializer = new GameSerializer();
        LeaderboardManager leaderboardManager = new LeaderboardManager();
        UserInterface ui = new UserInterface();

        bool quit = false;
        while (!quit)
        {
            ui.DisplayGameBoard(game);
            Console.WriteLine("Enter your move (source rod, destination rod), 'S' to save, 'L' to load, 'V' to view leaderboard, or 'Q' to quit: ");
            string input = ui.GetUserInput().ToUpper();

            if (input == "S")
            {
                serializer.SaveGame(game, "savegame.xml");
                Console.WriteLine("Game saved successfully.");
            }
            else if (input == "L")
            {
                game = serializer.LoadGame("savegame.xml");
                Console.WriteLine("Game loaded successfully.");
            }
            else if (input == "V")
            {
                var leaderboard = leaderboardManager.GetLeaderboard();
                ui.DisplayLeaderboard(leaderboard);
            }
            else if (input == "Q")
            {
                quit = true;
            }
            else
            {
                
                char sourceRod, destinationRod;
                if (input.Length >= 2)
                {
                    sourceRod = input[0];
                    destinationRod = input[1];
                    game.MoveDisk(sourceRod, destinationRod);
                }
                else
                {
                    Console.WriteLine("Invalid move. Please enter source and destination rods (e.g., 'AB').");
                    Console.ReadLine(); 
                }
            }

            
            if (game.IsGameWon())
            {
                Console.WriteLine($"Congratulations! You won in {game.GetMoves()} moves.");
                Console.WriteLine("Enter your name for the leaderboard: ");
                string playerName = ui.GetUserInput();
                leaderboardManager.AddToLeaderboard(playerName, game.GetMoves());
                var leaderboard = leaderboardManager.GetLeaderboard();
                ui.DisplayLeaderboard(leaderboard);
                quit = true;
            }
            
            else
                {
                    char sourceRod = input[0];
                    char destinationRod = input[1];
                    game.MoveDisk(sourceRod, destinationRod);

                    if (game.IsGameWon())
                    {
                        ui.DisplayGameBoard(game);
                        Console.WriteLine($"Congratulations! You won in {game.GetMoves()} moves.");
                        break;

                }
            }
        }

        Console.WriteLine("Do you want to play another game? (Y/N): ");
        string playAgainInput = ui.GetUserInput().ToUpper();
        playAgain = (playAgainInput == "Y");
    }
}
