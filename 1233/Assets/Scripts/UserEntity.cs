using System.Collections;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
using UnityEngine;

public class UserEntity : TableEntity
{
    public string TableName = "LoginTable";


    // Your entity type must expose a parameter-less constructor
    public UserEntity() { }

    // Define the PK and RK
    public UserEntity(string email, string pass)
    {
        this.PartitionKey = "login";
        this.RowKey = "001";
        this.Password = pass;
        this.Email = email;
    }

    //For any property that should be stored in the table service, the property must be a public property of a supported type that exposes both get and set.        
    public string Password { get; set; }
    public string Email { get; set; }
}