using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

public class RegisterScript : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;

    public void Register()
    {
        string username = usernameField.text;
        string password = passwordField.text;

        // DatabaseInitializer sýnýfýný örnekle
        DatabaseInitializer initializer = new DatabaseInitializer();
        string connectionString = initializer.connectionString;

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Users (username, password) VALUES (@username, @password)";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.ExecuteNonQuery();
            }
        }
    }
}