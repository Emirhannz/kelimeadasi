using UnityEngine;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public UserListUI userListUI;

    public void OnLoginButtonClicked()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (DatabaseManager.Instance.LoginUser(username, password))
        {
            Debug.Log("Login successful!");
            userListUI.DisplayUserList(DatabaseManager.Instance.GetUserList());
        }
        else
        {
            Debug.Log("Login failed!");
        }
    }
}
