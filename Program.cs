using StackExchange.Redis;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Redis Cache for Azure!");

// Exercise - Connect an app to Azure Cache for Redis by using .NET Core

// 1. Install the StackExchange.Redis NuGet package

// Create Azure resources

// 2. Create a resource group for Azure resources. Replace <myLocation> with a region near you.

// az group create --name az204-redis-rg --location <myLocation>
// az group create --name az204-redis-rg --location centralus

// 3. Create an Azure Cache for Redis instance. Replace <myLocation> with a region near you.

// Create an Azure Cache for Redis instance by using the az redis create command.
// The instance name needs to be unique and the following script attempts to generate one for you, 
// replace <myLocation> with the region you used in the previous step. This command takes a few minutes to complete.

// redisName=az204redis$RANDOM
// az redis create --location <myLocation> --resource-group az204-redis-rg --name $redisName --sku Basic --vm-size c0
// az redis create --location centralus --resource-group az204-redis-rg --name $redisName --sku Basic --vm-size c0

// 4. Get the connection string for the Azure Cache for Redis instance

string connectionString = "<your-connection-string>";
//string connectionString = "";

// 5. Connect to the Azure Cache for Redis instance
// Create a ConnectionMultiplexer object by using the ConnectionMultiplexer.Connect method.

using (var cache = ConnectionMultiplexer.Connect(connectionString))
{

    // Get a reference to the database
    IDatabase db = cache.GetDatabase();

    // Execute a ping command to check the connection
    var result = await db.ExecuteAsync("PING");
    Console.WriteLine($"PING = {result.Resp2Type} : {result}");

    // 6. Store and retrieve data
    // Use the IDatabase.StringSet and IDatabase.StringGet methods to store and retrieve data.


    bool setValue = await db.StringSetAsync("test:key", "100");
    Console.WriteLine($"SET: {setValue}");

    string? getValue = await db.StringGetAsync("test:key");
    Console.WriteLine($"GET: {getValue}");
}

// 7. Clean up resources

// az group delete --name az204-redis-rg --yes --no-wait
