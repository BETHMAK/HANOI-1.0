using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANOI_1._0
{
    using System;
    using System.Data.SqlClient;

    class LeaderboardManager
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;;";

        public void AddToLeaderboard(string playerName, int score)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"INSERT INTO Leaderboard (PlayerName, Score) VALUES (@PlayerName, @Score)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlayerName", playerName);
                    command.Parameters.AddWithValue("@Score", score);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<PlayerScore> GetLeaderboard()
        {
            List<PlayerScore> leaderboard = new List<PlayerScore>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TOP 10 PlayerName, Score FROM Leaderboard ORDER BY Score ASC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        leaderboard.Add(new PlayerScore
                        {
                            Name = reader["PlayerName"].ToString(),
                            Score = Convert.ToInt32(reader["Score"])
                        });
                    }
                }
            }
            return leaderboard;
        }
    }

}