using System;
using System.Collections;
using System.Collections.Generic;
 //using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField idField;
    public InputField pwField;

    public Button loginButton;

    public Button registration;

    public string un;
    public string pw;

    public Login() {
        
    }

    public void Register() {
        SceneManager.LoadScene("Registration");
    }
    void Start()
    {
        
        idField.text = "Enter Your ID Here...";
        pwField.text = "";
        loginButton.onClick.AddListener(() => logInFunction(un, pw));
    }
/** 
    public void connect() {
        var connection;
        try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "tcp:disk1.database.windows.net,1433";
                cb.UserID = "apollo78124";
                cb.Password = "bcitGroup4$";
                cb.InitialCatalog = "DISK1";

                using (connection = new SqlConnection(cb.ConnectionString))
                {
                    connection.Open();
                }
                print("connected");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
    }
*/
    void Update() {
        un = idField.text;
        pw = pwField.text;
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (pw != "" && un != "")
                logInFunction(un, pw);

        }
    }

    public void logInFunction(string name, string password)
    {   
        print("Login");
        SceneManager.LoadScene("Food");
        //connect();
    }

    public Boolean authenticate() {
        return true;
    }
}
