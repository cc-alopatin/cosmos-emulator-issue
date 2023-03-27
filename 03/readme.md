# Configuration

- This version of the app uses [CosmosDb emulator as linux container](https://learn.microsoft.com/en-us/azure/cosmos-db/docker-emulator-linux?tabs=sql-api%2Cssl-netstd21)
- The emulator is run on custom port _9091_
- Cosmos db certificate is installed manually into Current User/Trusted Root Certification Authorities
- The console app is run manually (dotnet run or VS)

# Status

- App hangs forever when tries to create database.
