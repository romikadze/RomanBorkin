using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References : MonoBehaviour
{
    private int _id = 1;
    private string _name = "User";
    private Data _data = new Data();

    private void Start()
    {
        int newId = _id;
        _id = 5;
        Debug.Log("ID: " + _id);
        Debug.Log("new ID: " + newId);


        string newName = _name;
        _name = "User123";
        Debug.Log("Name: " + _name);
        Debug.Log("new Name: " + newName);

        _data.Id = _id;

        Data newData = _data;
        _data.Id = 10;
        Debug.Log("Data ID: " + _data.Id);
        Debug.Log("newData ID: " + newData.Id);

        CreateLogin(newId, newName, out string login);
        Debug.Log("Login " + login);
    }

    private void CreateLogin(int id, string name, out string login)
    {
        login = name + id;
    }
}

class Data
{
    public int Id { get; set; }
}
