using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SaveName : MonoBehaviour
{
    public TMP_InputField InputField;

    public void SaveData()
    {
        PlayerPrefs.SetString("Input", InputField.text);
        //Debug.Log("Your Name is" + PlayerPrefs.GetString("name"));
    }

    public void LoadData()
    {
        InputField.text = PlayerPrefs.GetString("Input");
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("Input");
        PlayerPrefs.DeleteAll();
    }
}

