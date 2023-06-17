## Kma.Economics

#### How to run

initialize dotnet user secrets and set mysql connection-string

```powershell
# init
cd <project root>
dotnet user-secrets init
dotnet user-secrets set "ConnectionString:DefaultConnection" "Server=<URL>;Port=<port>;Database=<db>;Uid=<user>;Pwd=<password>;"
```

Build and run.





