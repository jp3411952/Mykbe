using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour
{
    public Text userName;
    public Text passWord;
    public Button loginBtn;
    public Button registerBtn;

    public void SetUserName(string name)
    {
        if (userName != null)
        {
            userName.text = name;
        }
    }
    public void SetPassWord(string password)
    {
        if (userName != null)
        {
            passWord.text = password;
        }
    }
    public string GetPassWord()
    {
        if (passWord != null)
        {
            return passWord.text;
        }
        return "";
    }
    public string GetUserName()
    {
        if (userName != null)
        {
            return userName.text;
        }
        return "";
    }
}
