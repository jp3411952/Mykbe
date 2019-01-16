using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AccountModel
{
    public string _username { get; set; }
    public string _password { get; set; }

    void InitModel(string username, string password)
    {
        _username = username;
        _password = password;
    }
}
