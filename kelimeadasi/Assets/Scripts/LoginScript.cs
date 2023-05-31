using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using System;

public class LoginScript : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;

    public void Login()
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
                command.CommandText = "SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    Debug.Log("Giriþ baþarýlý!");
                }
                else
                {
                    Debug.Log("Giriþ baþarýsýz!");
                }
            }
        }
    }
}