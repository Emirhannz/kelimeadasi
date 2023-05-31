using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UserListUI : MonoBehaviour
{
    public Text userListText;

    private void Start()
    {
        // Text bileþenini al
        userListText = GetComponent<Text>();

        // Eðer userListText null ise hata ver
        if (userListText == null)
        {
            Debug.LogError("UserListUI: userListText is not assigned. Make sure the Text component is attached to the same GameObject.");
        }
    }

    public void DisplayUserList(List<string> userList)
    {
        // userListText null ise hata ver ve iþlemi sonlandýr
        if (userListText == null)
        {
            Debug.LogError("UserListUI: userListText is not assigned. Make sure the Text component is attached to the same GameObject.");
            return;
        }

        // Kullanýcý listesini birleþtirerek userListText'e atama yap
        userListText.text = string.Join("\n", userList);
    }
}
