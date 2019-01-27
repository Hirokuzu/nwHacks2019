using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using UnityEngine;

public class LoginTable : BaseStorage
{
    public string TableName = "Login";
    //CloudTable table;
   
   
    //public async void addUserAsync(string User, string Password, string Email)
    //{
    //    CloudTableClient tableClient = StorageAccount.CreateCloudTableClient();
    //    CloudTable table = tableClient.GetTableReference(TableName);
    //    UserEntity entity = new UserEntity(User, Password, Email);
    //    await InsertOrMergeEntityAsync(table, entity);
    //}

    public async void AuthenticateUser()
    {
        CloudTableClient tableClient = StorageAccount.CreateCloudTableClient();
        CloudTable table = tableClient.GetTableReference(TableName);
        try
        {
            if (await table.CreateIfNotExistsAsync())
            {
                WriteLine(string.Format("Created Table named: {0}", TableName));
            }
            else
            {

                WriteLine(string.Format("Table {0} already exists", TableName));
            }
        }
        catch (StorageException)
        {
            WriteLine("If you are running with the default configuration please make sure you have started the storage emulator. Press the Windows key and type Azure Storage to select and run it from the list of applications - then restart the sample.");
            throw;
        }
        await AuthenticateUserAsync(table, "avinash.ahilesan00@gmail.com", "test123");

    }

    public async void createUser()
    {
        CloudTableClient tableClient = StorageAccount.CreateCloudTableClient();
        CloudTable table = tableClient.GetTableReference(TableName);
        UserEntity entity = new UserEntity("testemail@gmail.com", "142");
        await InsertOrMergeEntityAsync(table, entity);
    }


    private async Task AuthenticateUserAsync(CloudTable table, string email, string password)
    {

        TableQuery<UserEntity> partitionScanQuery = new TableQuery<UserEntity>().Where
            (TableQuery.GenerateFilterCondition("Email", QueryComparisons.Equal, email));

        TableContinuationToken token = null;
        // Page through the results
        bool authenticated = false;
        do
        {
            TableQuerySegment<UserEntity> segment = await table.ExecuteQuerySegmentedAsync(partitionScanQuery, token);
            token = segment.ContinuationToken;
            foreach (UserEntity entity in segment)
            {
                if (entity.Password == password)
                    authenticated = true;
                WriteLine("Email: " + entity.Email + " password: " + entity.Password);
            }
        }
        while (token != null);
        if (authenticated)
            WriteLine("User has been authenticated!");
        else
            WriteLine("User could not be authenticated");
    }

    // I made this just to see if the code was actually outputting proper value's
    private async Task PartitionScanAsync(CloudTable table, string partitionKey)
    {
        TableQuery<UserEntity> partitionScanQuery = new TableQuery<UserEntity>().Where
            (TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));

        TableContinuationToken token = null;
        // Page through the results
        do
        {
            TableQuerySegment<UserEntity> segment = await table.ExecuteQuerySegmentedAsync(partitionScanQuery, token);
            token = segment.ContinuationToken;
            foreach (UserEntity entity in segment)
            {
                WriteLine(string.Format("Customer: {0},{1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey, entity.Email, entity.Password));
            }
        }
        while (token != null);
    }


    private async Task<UserEntity> InsertOrMergeEntityAsync(CloudTable table, UserEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        // Create the InsertOrReplace  TableOperation
        TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

        // Execute the operation.
        TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
        UserEntity insertedCustomer = result.Result as UserEntity;
        return insertedCustomer;
    }



}
