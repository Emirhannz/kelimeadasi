using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterScript : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public UserListUI userListUI;

    private DatabaseManager databaseManager;

    private void Start()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();
    }

    public void OnRegisterButtonClicked()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            bool success = databaseManager.RegisterUser(username, password);

            if (success)
            {
                UpdateUserList();
                Debug.Log("User registered successfully!");
            }
            else
            {
                Debug.Log("Failed to register user. Username may already exist.");
            }
        }
        else
        {
            Debug.Log("Please enter a username and password.");
        }
    }

    private void UpdateUserList()
    {
        List<User> userList = new List<User>();
        List<string> usernames = databaseManager.GetUserList();

        foreach (string username in usernames)
        {
            User user = new User(username, "password"); // Burada gerçek bir parolayý kullanmalýsýnýz
            userList.Add(user);
        }

        userListUI.UpdateUserList(userList);
    }
}
