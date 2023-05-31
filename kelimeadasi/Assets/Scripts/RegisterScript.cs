using UnityEngine;
using UnityEngine.UI;

public class RegisterScript : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public UserListUI userListUI;

    public void OnRegisterButtonClicked()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (DatabaseManager.Instance.RegisterUser(username, password))
        {
            Debug.Log("Registration successful!");
            userListUI.DisplayUserList(DatabaseManager.Instance.GetUserList());
        }
        else
        {
            Debug.Log("Registration failed!");
        }
    }
}
