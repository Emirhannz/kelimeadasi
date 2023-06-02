using UnityEngine;
using TMPro;

public class SifreGoster : MonoBehaviour
{
    public TMP_InputField targetInputField;
    public UnityEngine.UI.Button toggleButton;

    private bool isPassword;

    private void Start()
    {
        toggleButton.onClick.AddListener(ToggleContentType);
    }

    private void ToggleContentType()
    {
        isPassword = !isPassword;
        if (isPassword)
        {
            targetInputField.contentType = TMP_InputField.ContentType.Password;
        }
        else
        {
            targetInputField.contentType = TMP_InputField.ContentType.Standard;
        }
        targetInputField.ForceLabelUpdate();
    }
}
