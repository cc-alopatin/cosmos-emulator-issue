using Microsoft.Azure.Cosmos;

// using uri of cosmos db emulator from docker
// the app itself is run manually
// using custom port 9091
var cosmosDbUri = "https://localhost:9091";
var client = new CosmosClient(cosmosDbUri, "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");

/********************************************same for all apps***********************************************************************************************/
var dbRes = await client.CreateDatabaseIfNotExistsAsync("TestDb");
var containerRes = await dbRes.Database.CreateContainerIfNotExistsAsync("Container1", "/partitionKey", throughput: 400);

var item = new Item(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
await containerRes.Container.CreateItemAsync(item, new PartitionKey(item.partitionKey));

var getItemRes = await containerRes.Container.ReadItemAsync<Item>(item.id, new PartitionKey(item.partitionKey));

Console.WriteLine(getItemRes.Resource);

while (true)
{
    Console.WriteLine("I am ok");
    Thread.Sleep(10_000);
}


record Item(string id, string partitionKey);