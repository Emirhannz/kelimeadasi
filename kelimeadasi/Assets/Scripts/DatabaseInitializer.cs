using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DatabaseInitializer : MonoBehaviour
{
    public string connectionString;

    void Start()
    {
        // Veritabaný dosya yolu
        string databaseName = "database.db";
        string databasePath = Application.persistentDataPath + "/" + databaseName;

        // Veritabaný baðlantý dizesi
        connectionString = "URI=file:" + databasePath;

        // Veritabanýný oluþtur
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "CREATE TABLE IF NOT EXISTS Users (id INTEGER PRIMARY KEY AUTOINCREMENT, username TEXT, password TEXT)";
                command.ExecuteNonQuery();
            }
        }
    }
}