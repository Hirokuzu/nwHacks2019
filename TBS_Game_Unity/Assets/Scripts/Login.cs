using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class Login : MonoBehaviour
{
    public InputField idField;
    public InputField pwField;

    public void Start()
    {
        idField.text = "Enter Your ID Here...";
        pwField.text = "Enter Your Password Here...";
    }
}
