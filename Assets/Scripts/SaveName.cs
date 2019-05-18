using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    public InputField usernameInput;
    public static string username;

    void Start()
    {
        if (username != null)
            usernameInput.text = username;
    }

    public void SaveUsername()
    {
        username = usernameInput.text;
        Debug.Log(username);
    }
}
